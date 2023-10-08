using AutoMapper;
using NZWalks.Api.Models.DTOs;
using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Profilers
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk, WalkDTO>()
                .ForMember(dest => dest.WalkName, options => options.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Walk, WalkRequestDTO>()
                .ForMember(dest => dest.WalkName, options => options.MapFrom(src => src.Name))
                .ReverseMap();
            
        }
    }
}
