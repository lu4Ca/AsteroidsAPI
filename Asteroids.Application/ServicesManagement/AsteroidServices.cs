using Asteroids.Application.Infrastructure.Exceptions;
using Asteroids.Application.ServicesManagement.Constants;
using Asteroids.Application.ServicesManagement.Dto;
using Asteroids.Application.Validations;
using System.Net.Http.Headers;


namespace Asteroids.Application.ServicesManagement
{
	public class AsteroidServices : IAsteroidServices
	{
		private readonly HttpClient _httpClient;
		public AsteroidServices(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<ServiceResponseDto> AsteroidsByDates(string startDate, string endDate)
		{
			try
			{
				var url = string.Format(AsteroidConfiguration.UrlTopAsteroids, startDate, endDate, AsteroidConfiguration.ApiKey);
				var request = new HttpRequestMessage(HttpMethod.Get, url);

				request.Headers.Clear();
				request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				var response = await _httpClient.SendAsync(request);
				var asteroidsAsJson = await response.Content.ReadAsStringAsync();

				ServicesValidations.HttpResponseValidate(response, asteroidsAsJson);
				ServiceResponseDto result = new() { HttpRequestMessage = response, ContentAsJson = asteroidsAsJson };

				return result;
			}
			catch (Exception ex)
			{
				throw new HttpException(new List<string> { ex.Message });
			}
		}
	}
}
