using InforceAPI.Models;

namespace InforceAPI.Services
{
    public interface IUrlService
    {
        Task<Url> GetUrl(int id);
        Task<Url> GetUrlByShort(string shortUrl);
        Task<List<Url>> GetAllUrls();
        Task<Url> AddUrl(Url request);
        Task<Url> DeleteUrl(int id);
        Task<Url> DeleteAllUrls();
    }
}
