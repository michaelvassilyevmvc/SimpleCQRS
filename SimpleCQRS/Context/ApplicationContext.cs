using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Models;

namespace SimpleCQRS.Context
{

    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}