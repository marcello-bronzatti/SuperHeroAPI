using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Models.SuperHeroModel;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
