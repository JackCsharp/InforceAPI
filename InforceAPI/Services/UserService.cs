using InforceAPI.Models;
using InforceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace InforceAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<User> GetUser(int id)
        {
            var response = await _context.Users.FindAsync(id);
            if (response == null) return null;
            return response;
        }
        public async Task<User> Login(User request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username);
            if (user == null||user.Password!=request.Password)
            {
                return null;
            }
            return user;

        }

        public async Task<User> Register(User request)
        {
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Username == request.Username);
            if (existingUser != null)
            {
                return null;
            }
            User user = new User();
            user.Username = request.Username;
            user.Password = request.Password;
            if (request.Status == "Admin") user.Status = request.Status;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
