

namespace RealEstateManagement.Application.DTO.FloorDTO
{
    public class FloorResponseDto
    {
        public Guid Id { get; set; }
        public int FloorNumber { get; set; }
        public Guid BuildingId { get; set; }
        public int UnitsCount { get; set; }
    }
}
