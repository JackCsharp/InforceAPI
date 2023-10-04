using InforceAPI.Models;
namespace InforceAPI.Services.DescriptionService
{
    public interface IDescriptionService
    {
        Task<Description> GetDescription();
        Task<Description> UpdateDescription(Description description);
        Task<Description> AddDescription(Description description);
    }
}
