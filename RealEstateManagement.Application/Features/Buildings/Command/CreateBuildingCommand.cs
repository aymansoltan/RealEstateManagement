

global using System.Text.Json.Serialization;

namespace RealEstateManagement.Application.Features.Buildings.Command
{
    public class CreateBuildingCommand :IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int BuildingNumber { get; set; }
        [JsonIgnore]
        public string IdentityUserId { get; set; } = string.Empty;
    }
}
