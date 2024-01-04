namespace Asteroids.Application.AsteroidsManagement.Dto
{
	public class AsteroidResponseDto
	{
		public string? Nombre { get; set; }
		public decimal? Diametro { get; set; }
		public decimal? Velocidad { get; set; }
		public DateTime? Fecha { get; set; }
		public string? Planeta { get; set; }
	}
}
