global using AutoMapper;
global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
using Unit = RealEstateManagement.Domain.Entities.Unit;

namespace RealEstateManagement.Application.Mapping.UnitMapping
{
    public class UnitProfile :Profile
    {
        public UnitProfile()
        {
            CreateMap< Unit , UnitResponseDto>()
                .ForMember(dest => dest.FloorNumber, opt => opt.MapFrom(src => src.Floor != null ? src.Floor.FloorNumber : 0))
                .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src => src.Floor != null && src.Floor.Building != null ? src.Floor.Building.Name : string.Empty));
        }
    }
}
