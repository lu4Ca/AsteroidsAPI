using Asteroids.Application.AsteroidsManagement.Dto;

namespace Asteroids.Application.AsteroidsManagement.Converters
{
	public interface IAsteroidConverter
	{
		public List<AsteroidDto> AsAsteroids(string jsonAsteroidData);
		public List<AsteroidResponseDto> AsAsteroidsResponse(List<AsteroidDto> asteroidsData);
	}
}
