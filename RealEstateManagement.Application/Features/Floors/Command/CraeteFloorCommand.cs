
namespace RealEstateManagement.Application.Features.Floors.Command
{
    public class CreateFloorCommand : IRequest<Guid>
    {
        public int FloorNumber { get; set; }
        public Guid BuildingId { get; set; }
        [JsonIgnore]
        public string IdentityUserId { get; set; } = string.Empty;
    }
    
}
