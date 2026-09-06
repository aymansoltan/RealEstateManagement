global using RealEstateManagement.Application.DTO.FloorDTO;


namespace RealEstateManagement.Application.Features.Floors.Query
{
    public class GetFloorsByBuildingQuery :IRequest<List<FloorResponseDto>>
    {
        public Guid BuildingId { get; set; }

        [JsonIgnore]
        public string IdentityUserId { get; set; } = string.Empty;
    }
}
