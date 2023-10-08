using NZWalks.Api.Models.Entities;

namespace NZWalks.Api.Models.IRepositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
