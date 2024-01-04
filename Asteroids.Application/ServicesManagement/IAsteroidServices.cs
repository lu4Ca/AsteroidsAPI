using Asteroids.Application.ServicesManagement.Dto;

namespace Asteroids.Application.ServicesManagement
{
	public interface IAsteroidServices
	{
		public Task<ServiceResponseDto> AsteroidsByDates(string startDate, string endDate);
	}
}
