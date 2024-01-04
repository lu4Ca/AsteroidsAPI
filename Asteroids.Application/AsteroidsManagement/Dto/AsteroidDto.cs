namespace Asteroids.Application.AsteroidsManagement.Dto
{
	public class AsteroidDto
	{
		public string? Name { get; set; }
		public decimal? MinDiameter { get; set; }
		public decimal? MaxDiameter { get; set; }
		public decimal? AverageDiameter { get; set; }
		public bool? Hazardous { get; set; }
		public decimal? Velocity { get; set; }
		public DateTime? Date { get; set; }
		public string? Planet { get; set; }
	}
}
