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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await context.GetAsync(id);

            if(region == null)
            {
                return NotFound();
            }
            else
            {
                var regionsDto = mapper.Map<RegionDTO>(region);

                return Ok(regionsDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(RegionDTO regionDTO)
        {
            //Request(DTO) to domain model
            //var regionModel = new Region()
            //{
            //    Code = regionDTO.RegionCode,
            //    Area = regionDTO.Area,
            //    Latitude = regionDTO.Latitude,
            //    Longitude = regionDTO.Longitude,
            //    Name = regionDTO.RegionName,
            //    Population = regionDTO.Population
            //};

            var regionModel = mapper.Map<Region>(regionDTO);

            //Pass details to repository
            regionModel = await context.AddAsync(regionModel);

            //Convert back to dto
            var newRegionDTO = new Region()
            {
                Code = regionDTO.RegionCode,
                Area = regionDTO.Area,
                Latitude = regionDTO.Latitude,
                Longitude = regionDTO.Longitude,
                Name = regionDTO.RegionName,
                Population = regionDTO.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, newRegionDTO);     //httpstatus code: 201
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            //Get region from database
            var region = await context.DeleteAsync(id);

            //If null NotFound
            if(region == null)
            {
                return NotFound();
            }
            else
            {
                //Convert response to DTO
                var regionDTO = new RegionDTO()
                {
                    Id = region.Id,
                    RegionCode = region.Code,
                    Area = region.Area,
                    Latitude = region.Latitude,
                    Longitude = region.Longitude,
                    RegionName = region.Name,
                    Population = region.Population
                };

                return Ok(regionDTO);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id, [FromBody]UpdateRegionDTO updateRequest)
        {
            //Convert DTO to Domain model
            var regionModel = mapper.Map<Region>(updateRequest);

            //Update Region using repository
            regionModel = await context.UpdateAsync(id, regionModel);

            //If null then NotFound()
            if(regionModel == null)
            {
                return NotFound();
            }
            else
            {
                //Convert Domain to DTO
                var regionDTO = mapper.Map<RegionDTO>(regionModel);

                //Return Ok
                return Ok(regionDTO);
            }   
        }
    }
}
