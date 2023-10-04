using InforceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InforceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=inforce;Trusted_Connection=true;TrustServerCertificate=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Url> Urls { get; set; }
        public DbSet<Description> Descriptions { get; set; }

    }
}
