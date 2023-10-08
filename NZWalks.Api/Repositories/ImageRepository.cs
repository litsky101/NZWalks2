using Microsoft.AspNetCore.Hosting.Server;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Entities;
using NZWalks.Api.Models.IRepositories;

namespace NZWalks.Api.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly NZWalksDbContext context;

        public ImageRepository(IWebHostEnvironment _webHostEnvironment, 
            IHttpContextAccessor _httpContextAccessor,
            NZWalksDbContext _context)
        {
            webHostEnvironment = _webHostEnvironment;
            httpContextAccessor = _httpContextAccessor;
            context = _context;
        }
        public async Task<Image> Upload(Image image)
        {
            var localFolder = Path.Combine(webHostEnvironment.ContentRootPath, "Images");

            if (!Directory.Exists(localFolder))
                Directory.CreateDirectory(localFolder);

            var filePath = Path.Combine(localFolder, $"{image.FileName}{image.FileExtension}");


            //Upload image
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.File.CopyToAsync(stream);
            }

            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;


            await context.Images.AddAsync(image);
            await context.SaveChangesAsync();

            return image;
        }
    }
}
