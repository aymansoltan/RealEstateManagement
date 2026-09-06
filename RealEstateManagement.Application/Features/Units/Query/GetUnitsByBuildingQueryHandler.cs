using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RealEstateManagement.Application.DTO.UnitDto;
using RealEstateManagement.Application.Interfaces.Repository;
using RealEstateManagement.Domain.Entities;


namespace RealEstateManagement.Application.Features.Units.Query
{
    public class GetUnitsByBuildingQueryHandler : IRequestHandler<GetUnitsByBuildingQuery, List<UnitResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Owner> _ownerRepository;
        private readonly IGenericRepository<Building> _buildingRepository;
        private readonly IGenericRepository<Domain.Entities.Unit> _unitRepository;

        public GetUnitsByBuildingQueryHandler(
            IMapper mapper,
            IGenericRepository<Owner> ownerRepository,
            IGenericRepository<Building> buildingRepository,
            IGenericRepository<Domain.Entities.Unit> unitRepository)
        {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
            _buildingRepository=buildingRepository;
            _unitRepository=unitRepository;
        }

        public async Task<List<UnitResponseDto>> Handle(GetUnitsByBuildingQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetAllQueryableNoTracking()
                .FirstOrDefaultAsync(o => o.IdentityUserId == request.IdentityUserId, cancellationToken);

            if (owner == null)
                throw new Exception("Owner not found.");

            var building = await _buildingRepository.GetAllQueryableNoTracking()
                .FirstOrDefaultAsync(b => b.Id == request.BuildingId && b.OwnerId == owner.Id, cancellationToken);

            if (building == null)
                throw new Exception("Building not found or unauthorized.");

            var units = await _unitRepository.GetAllQueryableNoTracking()
                .Where(u => u.Floor.BuildingId == request.BuildingId)
                .ProjectTo<UnitResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return units;

        }
    }
}
