using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NZWalks.Api.Models.DTOs;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository context;
        private string[] allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
        public ImagesController(IImageRepository _context)
        {
            context = _context;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageRequestDTO request)
        {
            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
                ModelState.AddModelError("file", $"Unsupported file extension. Only acceptable {string.Join(",", allowedExtensions)}.");

            if (request.File.Length > 10485760) // 10 MB
                ModelState.AddModelError("file", $"File size more than 10 MB.");


            if (ModelState.IsValid)
            {
                var imageModel = new Image()
                {
                    Id = Guid.NewGuid(),
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileName = request.FileName,
                    FileSizeInByes = request.File.Length,
                    Description = request.FileDescription
                };

                await context.Upload(imageModel);

                return Ok(imageModel);
            }

            return BadRequest(ModelState);
        }
    }
}
