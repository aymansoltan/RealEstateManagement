
namespace RealEstateManagement.Application.Features.Buildings.Command
{
    public class CreateBuildingCommandHandler : IRequestHandler<CreateBuildingCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Building> _buildingRepository;
        private readonly IGenericRepository<Owner> _ownerRepository;
        public CreateBuildingCommandHandler(
            IUnitOfWork unitOfWork ,
            IGenericRepository<Building> buildingRepository ,
            IGenericRepository<Owner> ownerRepository )
        {
            _unitOfWork = unitOfWork;
            _buildingRepository = buildingRepository;
            _ownerRepository = ownerRepository;
        }
        public async Task<Guid> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var ownerQuery = _ownerRepository.GetAllQueryableNoTracking();
            var owner =await ownerQuery.FirstOrDefaultAsync(o => o.IdentityUserId == request.IdentityUserId ,cancellationToken);
            if (owner == null)
            {
                throw new Exception("Owner not found for the given IdentityUserId.");
            }
            var building = new Building
            {
                Name = request.Name,
                Address = request.Address,
                BuildingNumber = request.BuildingNumber,
                OwnerId = owner.Id
            };
            await _buildingRepository.AddAsync(building);
            await _unitOfWork.CompleteAsync(cancellationToken);
            return building.Id;
        }
    }
}
