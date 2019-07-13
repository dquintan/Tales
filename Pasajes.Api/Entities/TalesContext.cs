using Microsoft.EntityFrameworkCore;

namespace Pasajes.Api.Entities
{
    public class TalesContext : DbContext
    {
        public TalesContext(DbContextOptions<TalesContext> options) : base (options)
        {
            Database.Migrate();
        }

        public DbSet<Tale> Tales { get; set; }
        public DbSet<TaleSource> TaleSources { get; set; }

    }
}
