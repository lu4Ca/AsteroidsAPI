using Asteroids.Application.AsteroidsManagement.Dto;

namespace Asteroids.Application.AsteroidsManagement
{
	public interface IAsteroidsApplication
	{
		public Task<List<AsteroidResponseDto>> AsteroidsByDays(int days);
	}
}
