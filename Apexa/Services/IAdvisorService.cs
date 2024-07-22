using Apexa.Models;

namespace Apexa.Services
{
    public interface IAdvisorService
    {
        Task<IEnumerable<Advisor>> GetAdvisors();
        Task<Advisor> GetAdvisor(int id);
        Task<Advisor> CreateAdvisor(Advisor advisor);
        Task<Advisor> UpdateAdvisor(Advisor advisor);
        Task DeleteAdvisor(int id);
    }
}
