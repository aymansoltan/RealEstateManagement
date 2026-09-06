
global using RealEstateManagement.Domain.Enums;

namespace RealEstateManagement.Application.DTO.UnitDto
{
    public class UnitResponseDto
    {
        public int UnitNumber { get; set; }
        public float Area { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public UnitStatus Status { get; set; } = UnitStatus.Available;
        public int FloorNumber { get; set; }
        public string BuildingName { get; set; } = string.Empty;
    }
}
