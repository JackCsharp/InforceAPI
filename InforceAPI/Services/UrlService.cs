using InforceAPI.Data;
using InforceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InforceAPI.Services
{
    public class UrlService : IUrlService
    {
        private readonly DataContext _context;
        public UrlService(DataContext context)
        {
            _context = context;
        }
        public async Task<Url> AddUrl(Url request)
        {
            var existingurl = await _context.Urls.SingleOrDefaultAsync(u => u.ShortUrl == request.ShortUrl);
            if (existingurl != null)
            {
                return null;
            }
            var url = new Url();
            url.ShortUrl = request.ShortUrl;
            url.LongUrl = request.LongUrl;
            url.Date = request.Date;
            url.UserId = request.UserId;

            _context.Urls.Add(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<Url> DeleteUrl(int id)
        {
            var url = await _context.Urls.FindAsync(id);
            if (url == null) return null;
            _context.Urls.Remove(url);
            await _context.SaveChangesAsync();
            return new Url();
        }

        public async Task<List<Url>> GetAllUrls()
        {
            List<Url> urls = new List<Url> { };
            urls = await _context.Urls.ToListAsync();
            return urls;
        }

        public async Task<Url> GetUrl(int id)
        {
            var url = await _context.Urls.FindAsync(id);
            if (url == null) return null;
            return url;
        }
        public async Task<Url> GetUrlByShort(string shortUrl)
        {
            var url = await _context.Urls.FirstOrDefaultAsync(u=>u.ShortUrl == shortUrl);
            if (url == null) return null;
            return url;
        }
        public async Task<Url> DeleteAllUrls()
        {
            var allUrls = await _context.Urls.ToListAsync();
            _context.Urls.RemoveRange(allUrls);
            await _context.SaveChangesAsync();
            return new Url();
        }
    }
}
