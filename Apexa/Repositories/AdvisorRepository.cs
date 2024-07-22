using Apexa.Data;
using Apexa.Models;
using Apexa.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Apexa.Repositories
{
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly AdvisorContext _context;

        public AdvisorRepository(AdvisorContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Advisor>> GetAdvisors()
        {
            return await _context.Advisors.ToListAsync();
        }

        public async Task<Advisor> GetAdvisor(int id)
        {
            return await _context.Advisors.FindAsync(id);
        }

        public async Task<Advisor> CreateAdvisor(Advisor advisor)
        {
            advisor.HealthStatus = Helpers.HealthStatusGenerator.Generate();
            _context.Advisors.Add(advisor);
            await _context.SaveChangesAsync();
            return advisor;
        }

        public async Task<Advisor> UpdateAdvisor(Advisor advisor)
        {
            _context.Entry(advisor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return advisor;
        }

        public async Task DeleteAdvisor(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor != null)
            {
                _context.Advisors.Remove(advisor);
                await _context.SaveChangesAsync();
            }
        }
    }
}

