using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Models;

namespace SimpleCQRS.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();
    }
}