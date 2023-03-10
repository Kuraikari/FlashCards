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

        public DbSet<FlashCardModel> FlashCards { get; set; }
    }
}
