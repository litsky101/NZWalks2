using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.DTOs;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/WalkDifficulties")]
    [ApiController]
    public class WalkDifficultiesController : ControllerBase
    {
        private readonly IWalkDifficultyRepository context;
        private readonly IMapper mapper;

        public WalkDifficultiesController(IWalkDifficultyRepository _context, IMapper _mapper)
        {
            context = _context;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var walkDiffModel = await context.GetAllAsync();

            var walkResponse = mapper.Map<List<WalkDifficultyResponseDTO>>(walkDiffModel);

            return Ok(walkResponse);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var walkDiffModel = await context.GetAsync(id);

            if(walkDiffModel == null)
            {
                return NotFound();
            }
            else
            {
                var walkDiffRespnse = mapper.Map<WalkDifficultyResponseDTO>(walkDiffModel);

                return Ok(walkDiffRespnse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] WalkDifficultyRequestDTO walkDiffRequest)
        {
            var walkDiffModel = mapper.Map<WalkDifficulty>(walkDiffRequest);

            walkDiffModel = await context.AddAsync(walkDiffModel);

            var response = mapper.Map<WalkDifficultyResponseDTO>(walkDiffModel);

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var walkDiffModel = await context.DeleteAsync(id);

            if(walkDiffModel == null)
            {
                return NotFound();
            }
            else
            {
                var response = mapper.Map<WalkDifficultyResponseDTO>(walkDiffModel);

                return Ok(response);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] WalkDifficultyRequestDTO walkDiffRequest)
        {
            var walkDiffModel = mapper.Map<WalkDifficulty>(walkDiffRequest);

            walkDiffModel = await context.UpdateAsync(id, walkDiffModel);

            if(walkDiffModel == null)
            {
                return NotFound();
            }

            var response = mapper.Map<WalkDifficultyResponseDTO>(walkDiffModel);

            return Ok(response);
        }
    }
}
