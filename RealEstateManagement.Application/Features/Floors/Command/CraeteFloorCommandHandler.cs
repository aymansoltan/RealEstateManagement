

namespace RealEstateManagement.Application.Features.Floors.Command
{
    public class CraeteFloorCommandHandler : IRequestHandler<CreateFloorCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Owner> _ownerRepository;
        private readonly IGenericRepository<Building> _buildingRepository;
        private readonly IGenericRepository<Floor> _floorRepository;

        public CraeteFloorCommandHandler(IUnitOfWork unitOfWork ,
            IGenericRepository<Owner> ownerRepository ,
            IGenericRepository<Building> buildingRepository,
            IGenericRepository<Floor> floorRepository)
        {
            _buildingRepository = buildingRepository;
            _floorRepository = floorRepository;
            _unitOfWork = unitOfWork;
            _ownerRepository = ownerRepository;
        }
        public async Task<Guid> Handle(CreateFloorCommand request, CancellationToken cancellationToken)
        {

            var owner =await _ownerRepository.GetAllQueryableNoTracking()
                .FirstOrDefaultAsync(o => o.IdentityUserId == request.IdentityUserId , cancellationToken);

            if (owner == null)
                throw new Exception("Owner not found for the given IdentityUserId.");
            var building = await _buildingRepository.GetAllQueryableNoTracking()
                .FirstOrDefaultAsync(b => b.Id == request.BuildingId, cancellationToken);

            if (building == null)
                throw new Exception("Building not found.");

            if (building.OwnerId != owner.Id)
                throw new Exception("Unauthorized: This building does not belong to this owner.");

            var floorExists = await _floorRepository.GetAllQueryableNoTracking()
                .AnyAsync(f => f.BuildingId == request.BuildingId && f.FloorNumber == request.FloorNumber, cancellationToken);

            if (floorExists)
                throw new Exception("Floor number already exists in this building.");

            var floor = new Floor
            {
                FloorNumber = request.FloorNumber,
                BuildingId = request.BuildingId
            };

            await _floorRepository.AddAsync(floor);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return floor.Id;
        }
    }
}
