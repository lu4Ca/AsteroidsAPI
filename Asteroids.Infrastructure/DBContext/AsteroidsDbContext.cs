using Asteroids.Domain.AggregatesModels.AsteroidAggregate;
using Microsoft.EntityFrameworkCore;


namespace Asteroids.Infrastructure.DBContext
{
	public class AsteroidsDbContext : DbContext
	{
		public AsteroidsDbContext(DbContextOptions<AsteroidsDbContext> options) : base(options)
		{
		}

		public DbSet<Asteroid> Asteroid { get; set; }
		public DbSet<AsteroidDateRange> AsteroidDateRange { get; set; }
		public DbSet<AsteroidTop> AsteroidTop { get; set; }
	}
}
