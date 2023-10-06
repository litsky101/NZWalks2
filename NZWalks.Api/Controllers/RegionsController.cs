using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.DTOs;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/Regions")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository context;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var regions = await context.GetAllAsync();

            #region Convert Domain to DTO using ForEach Loop
            //return DTO regions
            //var regionsDto = new List<RegionDTO>();

            //regions.ToList().ForEach(r =>
            //{
            //    regionsDto.Add(new RegionDTO
            //    {
            //        Id = r.Id,
            //        Name = r.Name,
            //        Area = r.Area,
            //        Code = r.Code,
            //        Latitude = r.Latitude,
            //        Longitude = r.Longitude,
            //        Population = r.Population
            //    });
            //});
            #endregion

            var regionsDto = mapper.Map<List<RegionDTO>>(regions);


            return Ok(regionsDto);
        }
    }
}
