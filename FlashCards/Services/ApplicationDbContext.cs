using FlashCards.Models.FlashCards;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.Services
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration) {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (options.IsConfigured)
            {
                return;
            } else
            {
                options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FlashCardSideModel>()
                .Property(s => s.Content)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<FlashCardModel>();
        }

        public DbSet<FlashCardModel> FlashCards { get; set; }
        public DbSet<FlashCardSideModel> FlashCardSides { get; set; }
    }
}
