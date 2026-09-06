

using RealEstateManagement.Application.DTO.UnitDto;

namespace RealEstateManagement.Application.Features.Units.Query
{
    public class GetUnitsByBuildingQuery :IRequest<List<UnitResponseDto>>
    {
        public Guid BuildingId { get; set; }

        [JsonIgnore]
        public string IdentityUserId { get; set; } = string.Empty;
    }
}
