using Microsoft.EntityFrameworkCore;

namespace Google_Docs_Clone.Models
{
    public class AppDbContext:DbContext
    {
        private readonly IConfiguration _config;

        public AppDbContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Document> Documents { get; set; }
    }
}
