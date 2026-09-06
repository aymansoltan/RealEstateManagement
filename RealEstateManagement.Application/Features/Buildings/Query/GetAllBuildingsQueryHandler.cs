
namespace RealEstateManagement.Application.Features.Buildings.Query
{
    public class GetAllBuildingsQueryHandler : IRequestHandler<GetAllBuildingQuery, List<BuildingResponseDto>>
    {
        private readonly IGenericRepository<Building> _buildingRepository;
        private readonly IGenericRepository<Owner> _ownerRepository;
        private readonly IMapper _mapper;
        public GetAllBuildingsQueryHandler(
            IGenericRepository<Building> buildingRepository,
            IGenericRepository<Owner> ownerRepository ,
            IMapper mapper
            )
        {
            _buildingRepository = buildingRepository;
            _ownerRepository = ownerRepository;
            _mapper = mapper;

        }
        public async Task<List<BuildingResponseDto>> Handle(GetAllBuildingQuery request, CancellationToken cancellationToken)
        {
            var ownerQuery = _ownerRepository.GetAllQueryableNoTracking();
            var owner =await ownerQuery.FirstOrDefaultAsync(o => o.IdentityUserId == request.IdentityUserId , cancellationToken);
            if (owner == null)
            {
                throw new Exception("Owner not found for the given IdentityUserId.");
            }
            var buildings =await _buildingRepository.GetAllQueryableNoTracking()
                .Where(b => b.OwnerId == owner.Id)
                .ProjectTo<BuildingResponseDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken); 
       

            return buildings;

        }
    }
}
