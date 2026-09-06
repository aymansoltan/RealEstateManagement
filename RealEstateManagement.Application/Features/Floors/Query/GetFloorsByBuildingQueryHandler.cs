global using RealEstateManagement.Application.Interfaces.Repository;
global using RealEstateManagement.Domain.Entities;
global using Microsoft.EntityFrameworkCore;
global using AutoMapper.QueryableExtensions;
global using MediatR;


namespace RealEstateManagement.Application.Features.Floors.Query
{
    public class GetFloorsByBuildingQueryHandler : IRequestHandler<GetFloorsByBuildingQuery, List<FloorResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Owner> _ownerRepository;
        private readonly IGenericRepository<Building> _buildingRepository;
        private readonly IGenericRepository<Floor> _floorRepository;

        public GetFloorsByBuildingQueryHandler(IMapper mapper ,
            IGenericRepository<Owner> ownerRepository ,
            IGenericRepository<Building> buildingRepository , IGenericRepository<Floor> floorRepository)
        {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            _buildingRepository = buildingRepository;
            _floorRepository = floorRepository;
        }
        public async Task<List<FloorResponseDto>> Handle(GetFloorsByBuildingQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetAllQueryableNoTracking()
                    .FirstOrDefaultAsync(o => o.IdentityUserId == request.IdentityUserId, cancellationToken);

            if (owner == null)
                throw new Exception("Owner not found.");

            var building = await _buildingRepository.GetAllQueryableNoTracking()
                .FirstOrDefaultAsync(b => b.Id == request.BuildingId && b.OwnerId == owner.Id, cancellationToken);

            if (building == null)
                throw new Exception("Building not found or unauthorized.");

            var floors = await _floorRepository.GetAllQueryableNoTracking()
                .Where(f => f.BuildingId == request.BuildingId)
                .Include(f => f.Units) 
                .ProjectTo<FloorResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return floors;
        }
    }
}
