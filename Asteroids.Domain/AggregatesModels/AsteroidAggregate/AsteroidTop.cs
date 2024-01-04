namespace Asteroids.Domain.AggregatesModels.AsteroidAggregate
{
	public class AsteroidTop
	{
		public int Id { get; set; }
		public int AsteroidDateRangeId { get; set; }
		public virtual required AsteroidDateRange AsteroidDateRange { get; set; }
		public int AsteroidId { get; set; }
		public virtual required Asteroid Asteroid { get; set; }
		public int Order { get; set; }
	}
}
