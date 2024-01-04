using Asteroids.Application.AsteroidsManagement;
using Asteroids.Application.AsteroidsManagement.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Asteroids.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AsteroidsController : ControllerBase
	{
		private readonly ILogger<AsteroidsController> _logger;
		private readonly IAsteroidsApplication _asteroidsApplication;
		public AsteroidsController(ILogger<AsteroidsController> logger, IAsteroidsApplication asteroidsApplication)
		{
			_logger = logger;
			_asteroidsApplication = asteroidsApplication;
		}

		[HttpGet(Name = "Asteroids")]
		public async Task<List<AsteroidResponseDto>> Asteroids(int days)
		{
			var result = await _asteroidsApplication.AsteroidsByDays(days);
			return result;
		}
	}
}
