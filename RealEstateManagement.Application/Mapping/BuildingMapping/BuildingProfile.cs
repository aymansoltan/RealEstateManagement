using AutoMapper;
using RealEstateManagement.Application.DTO.BuildingDTO;
using RealEstateManagement.Domain.Entities;

namespace RealEstateManagement.Application.Mapping.BuildingMapping
{
    public class BuildingProfile :Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingResponseDto>()
                .ForMember(dest => dest.TotalFloors , opt => opt.MapFrom(src => src.Floors.Count()))
                .ForMember(dest => dest.TotalUnits, opt => opt.MapFrom(src => src.Floors.SelectMany(f => f.Units).Count()));
        }
    }
}
