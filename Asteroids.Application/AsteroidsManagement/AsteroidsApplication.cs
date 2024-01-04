using Asteroids.Application.AsteroidsManagement.Converters;
using Asteroids.Application.AsteroidsManagement.Dto;
using Asteroids.Application.Infrastructure.Exceptions;
using Asteroids.Application.ServicesManagement;
using Asteroids.Application.ServicesManagement.Constants;
using Asteroids.Application.Validations;



namespace Asteroids.Application.AsteroidsManagement
{
	public class AsteroidsApplication : IAsteroidsApplication
	{
		private readonly IAsteroidConverter _asteroidConverter;
		private readonly IAsteroidServices _servicesApplication;
		public AsteroidsApplication(IAsteroidConverter asteroidConverter, IAsteroidServices servicesApplication)
		{
			_asteroidConverter = asteroidConverter;
			_servicesApplication = servicesApplication;
		}

		public async Task<List<AsteroidResponseDto>> AsteroidsByDays(int days)
		{
			try
			{
				AsteroidsValidations.ValidateDays(days);
				var startDate = DateTime.Now.ToString("yyyy-MM-dd");
				var endDate = DateTime.Now.AddDays(days).ToString("yyyy-MM-dd");
				var serviceResponse = await _servicesApplication.AsteroidsByDates(startDate, endDate);
				var asteroidsData = _asteroidConverter.AsAsteroids(serviceResponse.ContentAsJson);
				var topHazardousAsteroids = asteroidsData.Where(l => l.Hazardous.HasValue && l.Hazardous.Value).OrderByDescending(l => l.AverageDiameter).Take(AsteroidConfiguration.TopSize).ToList();
				var topAsteroids = _asteroidConverter.AsAsteroidsResponse(topHazardousAsteroids);
				return topAsteroids;
			}
			catch (HttpException ex)
			{
				throw new HttpException(ex.Messages, ex.ErrorCode);
			}
			catch (Exception ex)
			{
				throw new HttpException(new List<string> { ex.Message });
			}
		}
	}
}
