

global using RealEstateManagement.Application.DTO.BuildingDTO;

namespace RealEstateManagement.Application.Features.Buildings.Query
{
    public class GetAllBuildingQuery : IRequest<List<BuildingResponseDto>>
    {
        [JsonIgnore]
        public string IdentityUserId { get; set; } = string.Empty;
    }
}
