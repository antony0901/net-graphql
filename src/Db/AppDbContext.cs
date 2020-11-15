using Microsoft.EntityFrameworkCore;
using src.Models;

namespace src.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}