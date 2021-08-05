using BasicRestAPI.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicRestAPI.Database
{
    public class ProjectDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=flowerstore.db");

        public DbSet<Store> Stores { get; set; }
        public DbSet<Flower> Flowers { get; set; }
    }
}