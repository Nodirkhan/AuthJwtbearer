using AuthJwtbearer.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthJwtbearer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DefaultData());
        }
    }
}
