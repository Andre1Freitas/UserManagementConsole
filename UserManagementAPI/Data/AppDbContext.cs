using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Entities;

namespace UserManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
