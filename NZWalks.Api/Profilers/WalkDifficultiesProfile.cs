using AutoMapper;
using NZWalks.Api.Models.DTOs;
using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Profilers
{
    public class WalkDifficultiesProfile : Profile
    {
        public WalkDifficultiesProfile()
        {
            CreateMap<WalkDifficulty, WalkDifficultyResponseDTO>().ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyRequestDTO>().ReverseMap();
        }
    }
}
