using InforceAPI.Data;
using InforceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InforceAPI.Services.DescriptionService
{
    public class DescriptionService : IDescriptionService
    {
        private readonly DataContext _context;
        public DescriptionService(DataContext context)
        {
            _context = context;
        }

        public async Task<Description> AddDescription(Description description)
        {
            _context.Descriptions.Add(description);
            await _context.SaveChangesAsync();
            return description;
        }

        public async Task<Description> GetDescription()
        {
            var description = await _context.Descriptions.FindAsync(1);
            return description;
        }

        public async Task<Description> UpdateDescription(Description request)
        {
            var description = await _context.Descriptions.FindAsync(1);
            if (description == null) return null;
            description.Text = request.Text;
            await _context.SaveChangesAsync();
            return description;
        }
    }
}
