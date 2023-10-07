using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using NZWalks.Api.Models.DTOs;
using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Profilers
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Region, RegionDTO>()
                .ForMember(dest => dest.RegionName, options => options.MapFrom(src => src.Name))
                .ForMember(des => des.RegionCode, options => options.MapFrom(src => src.Code))
                .ReverseMap();

            CreateMap<Region, AddRegionDTO>()
                .ForMember(dest => dest.RegionName, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.RegionCode, options => options.MapFrom(src => src.Code))
                .ReverseMap();

            CreateMap<Region, UpdateRegionDTO>()
                .ForMember(dest => dest.RegionName, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.RegionCode, options => options.MapFrom(src => src.Code))
                .ReverseMap();
        }
    }
}
