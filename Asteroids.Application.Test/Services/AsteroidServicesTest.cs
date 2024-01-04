using Asteroids.Application.Infrastructure.Exceptions;
using Asteroids.Application.ServicesManagement;
using FluentAssertions;
using Moq;

namespace Asteroids.Application.Test.Services
{
	[TestFixture]
	public class AsteroidServicesTest
	{
		private Mock<HttpClient> httpClientMok;

		[SetUp]
		public void Setup()
		{
			httpClientMok = new();
		}

		[Test]
		public async Task StatusCodeOK()
		{
			var startDate = DateTime.Now.ToString("yyyy-MM-dd");
			var endDate = DateTime.Now.ToString("yyyy-MM-dd");
			var asteroidService = new AsteroidServices(httpClientMok.Object);
			var result = await asteroidService.AsteroidsByDates(startDate, endDate);
			result.Should().NotBeNull();
		}

		[Test]
		public async Task StatusCodeError()
		{
			var startDate = DateTime.Now.ToString("yyyy-MM-dd");
			var endDate = DateTime.Now.AddDays(13).ToString("yyyy-MM-dd");
			var asteroidService = new AsteroidServices(httpClientMok.Object);
			Func<Task> action = () => asteroidService.AsteroidsByDates(startDate, endDate);
			var httpException = await action.Should().ThrowAsync<HttpException>();
		}
	}
}
