using Microsoft.EntityFrameworkCore;
using Apexa.Models;
namespace Apexa.Data
{
    public class AdvisorContext : DbContext
    {
        public DbSet<Advisor> Advisors { get; set; }

        public AdvisorContext(DbContextOptions<AdvisorContext> options) : base(options) { }
    }
}
