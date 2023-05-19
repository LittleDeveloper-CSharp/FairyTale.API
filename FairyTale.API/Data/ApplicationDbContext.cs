using FairyTale.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FairyTale.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Dwarf> Dwarfs { get; set; }

        public DbSet<SnowWhite> SnowWhites { get; set; }

        public DbSet<DwarfTransferRequest> Requests { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
