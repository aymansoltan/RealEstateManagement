


namespace RealEstateManagement.Application.Features.Units.Command
{
    public class CreateUnitCommand :IRequest<Guid>
    {
        public int UnitNumber { get; set; }
        public float Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public UnitStatus Status { get; set; } = UnitStatus.Available;

        public Guid FloorId { get; set; }

        [JsonIgnore]
        public string IdentityUserId { get; set; } = string.Empty;
    }
}
