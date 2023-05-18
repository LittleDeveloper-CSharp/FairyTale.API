using FairyTale.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FairyTale.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dwarf> Dwarfs { get; set; }

        public DbSet<SnowWhite> SnowWhites { get; set; }

        public DbSet<DwarfTransferRequest> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SnowWhite>()
                .HasData(new SnowWhite
                {
                    Id = 1,
                    FullName = "Белоснежка"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
