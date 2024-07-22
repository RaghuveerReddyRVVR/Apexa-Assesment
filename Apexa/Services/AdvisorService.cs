using Apexa.Models;
using Apexa.Repositories;

namespace Apexa.Services
{
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository _repository;
        private readonly Helpers.MruCache<int, Advisor> _cache = new Helpers.MruCache<int, Advisor>();
        public AdvisorService(IAdvisorRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Advisor>> GetAdvisors()
        {
            return _repository.GetAdvisors();
        }

        public Task<Advisor> GetAdvisor(int id)
        {
            return _repository.GetAdvisor(id);
        }

        public Task<Advisor> CreateAdvisor(Advisor advisor)
        {
            return _repository.CreateAdvisor(advisor);
        }

        public Task<Advisor> UpdateAdvisor(Advisor advisor)
        {
            return _repository.UpdateAdvisor(advisor);
        }

        public Task DeleteAdvisor(int id)
        {
            return _repository.DeleteAdvisor(id);
        }
    }
}
