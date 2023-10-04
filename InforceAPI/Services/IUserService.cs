using InforceAPI.Models;
namespace InforceAPI.Services
{
    public interface IUserService
    {
        Task<User> Register(User request);
        Task<User> Login(User request);
        Task<User> GetUser(int id);
    }
}
