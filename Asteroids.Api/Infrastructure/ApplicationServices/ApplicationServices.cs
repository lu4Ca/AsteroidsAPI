using Asteroids.Application;
using Asteroids.Application.AsteroidsManagement;
using Asteroids.Application.AsteroidsManagement.Converters;
using Asteroids.Application.ServicesManagement;

namespace Asteroids.Api.Infrastructure.ApplicationServices
{
	public static class ApplicationServices
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IAsteroidsApplication, AsteroidsApplication>();
			services.AddScoped<IAsteroidConverter, AsteroidConverter>();
			services.AddScoped<IAsteroidServices, AsteroidServices>();
			services.AddScoped<ITools, Tools>();
			return services;
		}
	}
}
