using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.DTOs;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;
using NZWalks.Api.Repositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/Walks")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository context;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        //Get: /api/walks?filterOn=Name&filterQuery=track&sortby=Name&IsAscending=true
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool isAscending, 
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            var walks = await context.GetAllAsync(filterOn, filterQuery, sortBy, isAscending, pageNumber, pageSize);

            var walksDto = mapper.Map<List<WalkDTO>>(walks);

            throw new Exception("This is a new exception");

            return Ok(walksDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var walk = await context.GetAsync(id);

            if (walk == null)
            {
                return NotFound();
            }
            else
            {
                var walkDto = mapper.Map<WalkDTO>(walk);

                return Ok(walk);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] WalkRequestDTO walkRequest)
        {
            //Convert request to domain model
            var walkModel = mapper.Map<Walk>(walkRequest);

            //Pass domain model to repository
            walkModel = await context.AddAsync(walkModel);

            //Convert back to DTO
            var walkResponse = mapper.Map<WalkDTO>(walkModel);

            return CreatedAtAction(nameof(Get), new { id = walkResponse.Id }, walkResponse); //httpstatus code: 201
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] WalkRequestDTO request)
        {
            var walkModel = mapper.Map<Walk>(request);

            walkModel = await context.UpdateAsync(id, walkModel);

            if(walkModel == null)
            {
                return NotFound();
            }
            else
            {
                var responseDTO = mapper.Map<WalkDTO>(walkModel);

                return Ok(responseDTO);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walk = await context.DeleteAsync(id);

            if(walk == null)
            {
                return NotFound();
            }
            else
            {
                var walkDTO = mapper.Map<WalkDTO>(walk);

                return Ok(walkDTO);
            }
        }
    }
}
