
using Unit = RealEstateManagement.Domain.Entities.Unit;

namespace RealEstateManagement.Application.Features.Units.Command
{
    public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Owner> _ownerRepository;
        private readonly IGenericRepository<Floor> _floorRepository;
        private readonly IGenericRepository<Unit> _unitRepository;

        public CreateUnitCommandHandler( IUnitOfWork unitOfWork ,
            IGenericRepository<Owner> ownerRepository ,
            IGenericRepository<Floor> floorRepository,
            IGenericRepository<RealEstateManagement.Domain.Entities.Unit> unitRepository
            )
        {
            _floorRepository = floorRepository;
            _unitRepository = unitRepository;
            _unitOfWork = unitOfWork;
            _ownerRepository = ownerRepository;

        }
        public async Task<Guid> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var owner =await _ownerRepository.GetAllQueryableNoTracking()
                .FirstOrDefaultAsync(o => o.IdentityUserId == request.IdentityUserId, cancellationToken);

            if(owner == null)
                throw new Exception("Owner not found for the given IdentityUserId.");

            var floor =await _floorRepository.GetAllQueryableNoTracking().Include(f => f.Building)
                .FirstOrDefaultAsync(f => f.Id == request.FloorId, cancellationToken);

            if(floor == null)
                throw new Exception("Floor not found for the given FloorId.");

            if(floor.Building == null)
                throw new Exception("Floor does not have an associated building.");

            if(floor.Building.OwnerId != owner.Id)
                throw new Exception("The floor does not belong to the owner associated with the given IdentityUserId.");

            var unitExists = await _unitRepository.GetAllQueryableNoTracking()
                .AnyAsync(u => u.FloorId == request.FloorId && u.UnitNumber == request.UnitNumber, cancellationToken);

            if (unitExists)
                throw new Exception("Unit number already exists on this floor.");
            var unit = new Unit
            {
                UnitNumber = request.UnitNumber,
                Area = request.Area,
                NumberOfRooms = request.NumberOfRooms,
                NumberOfBathrooms = request.NumberOfBathrooms,
                Status = request.Status,
                FloorId = request.FloorId
            };

            await _unitRepository.AddAsync(unit);
            await _unitOfWork.CompleteAsync(cancellationToken);

            return unit.Id;


        }
    }
}
