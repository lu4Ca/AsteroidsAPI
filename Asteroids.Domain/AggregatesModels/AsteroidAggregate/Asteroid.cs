namespace Asteroids.Domain.AggregatesModels.AsteroidAggregate
{
	public class Asteroid
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public decimal MinDiameter { get; set; }
		public decimal MaxDiameter { get; set; }
		public decimal AverageDiameter { get; set; }
		public required decimal Velocity { get; set; }
		public DateTime CloseApproachDate { get; set; }
		public required string Planet { get; set; }
		public bool IsPotentiallyHazardous { get; set; }

	}
}
