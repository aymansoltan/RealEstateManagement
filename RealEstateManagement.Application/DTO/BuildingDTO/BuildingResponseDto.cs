

namespace RealEstateManagement.Application.DTO.BuildingDTO
{
    public class BuildingResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int BuildingNumber { get; set; }
        public int TotalFloors { get; set; }
        public int TotalUnits { get; set; }
    }
}
