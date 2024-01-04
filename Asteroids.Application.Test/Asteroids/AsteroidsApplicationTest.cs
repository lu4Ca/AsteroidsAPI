using Asteroids.Application.AsteroidsManagement;
using Asteroids.Application.AsteroidsManagement.Converters;
using Asteroids.Application.AsteroidsManagement.Dto;
using Asteroids.Application.Infrastructure.Exceptions;
using Asteroids.Application.ServicesManagement;
using Asteroids.Application.ServicesManagement.Dto;
using FluentAssertions;
using Moq;
using System.Net;

namespace Asteroids.Application.Test.Asteroids
{
	[TestFixture]
	public class AsteroidsApplicationTest
	{
		private Mock<IAsteroidConverter> converterMok;
		private Mock<IAsteroidServices> asteroidServices;

		[SetUp]
		public void Setup()
		{
			converterMok = new();
			asteroidServices = new();
			asteroidServices.Setup(l => l.AsteroidsByDates(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(Mock.Of<ServiceResponseDto>());
			converterMok.Setup(l => l.AsAsteroids(It.IsAny<string>())).Returns(Mock.Of<List<AsteroidDto>>());
			converterMok.Setup(l => l.AsAsteroidsResponse(It.IsAny<List<AsteroidDto>>())).Returns(Mock.Of<List<AsteroidResponseDto>>());
		}

		[Test]
		public async Task LessThanOne()
		{
			Mock<IAsteroidConverter> converterMok = new();
			Mock<IAsteroidServices> asteroidServices = new();
			var asteroidsApplication = new AsteroidsApplication(converterMok.Object, asteroidServices.Object);
			Func<Task> action = () => asteroidsApplication.AsteroidsByDays(0);
			var httpException = await action.Should().ThrowAsync<HttpException>();
			httpException.And.ErrorCode.Should().Be(HttpStatusCode.InternalServerError);
		}

		[Test]
		public async Task GreaterThanSeven()
		{
			Mock<IAsteroidConverter> converterMok = new();
			Mock<IAsteroidServices> asteroidServices = new();
			var asteroidsApplication = new AsteroidsApplication(converterMok.Object, asteroidServices.Object);
			Func<Task> action = () => asteroidsApplication.AsteroidsByDays(9);
			var httpException = await action.Should().ThrowAsync<HttpException>();
			httpException.And.ErrorCode.Should().Be(HttpStatusCode.InternalServerError);
		}

		[Test]
		public async Task DayWithinRange()
		{
			var asteroidsApplication = new AsteroidsApplication(converterMok.Object, asteroidServices.Object);
			var result = await asteroidsApplication.AsteroidsByDays(3);
			result.Should().NotBeNull();
		}
	}
}