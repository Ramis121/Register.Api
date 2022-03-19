using Domain.Model;
using Loregram.STS.Models;
using Microsoft.EntityFrameworkCore;

namespace Loregram.STS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; } 
    }
}
