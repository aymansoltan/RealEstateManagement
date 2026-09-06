

using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Application.Mapping.FloorMapping
{
    public class FloorProfile :Profile
    {
        public FloorProfile()
        {
            CreateMap<Floor, FloorResponseDto>()
                .ForMember(dest => dest.UnitsCount, opt => opt.MapFrom(src => src.Units != null ? src.Units.Count : 0));
        }
    }
}
