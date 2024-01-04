using Asteroids.Application.AsteroidsManagement.Dto;
using Newtonsoft.Json.Linq;

namespace Asteroids.Application.AsteroidsManagement.Converters
{
	public class AsteroidConverter : IAsteroidConverter
	{
		private readonly ITools _tools;
		public AsteroidConverter(ITools tools)
		{
			_tools = tools;
		}

		public List<AsteroidDto> AsAsteroids(string jsonAsteroidsData)
		{
			JObject jsonResponse = JObject.Parse(jsonAsteroidsData);
			List<AsteroidDto> asteroids = new();
			var dataDates = jsonResponse["near_earth_objects"];

			if (dataDates != null)
			{
				foreach (JToken dataDate in dataDates)
				{
					var asteroidsData = dataDate.Values();
					foreach (var item in asteroidsData)
					{
						var minDiameter = item["estimated_diameter"]?["kilometers"]?.Value<decimal>("estimated_diameter_min");
						var maxDiameter = item["estimated_diameter"]?["kilometers"]?.Value<decimal>("estimated_diameter_max");
						asteroids.Add(new AsteroidDto()
						{
							Name = item.Value<string>("name"),
							MinDiameter = minDiameter,
							MaxDiameter = maxDiameter,
							AverageDiameter = _tools.Average(new List<decimal>() { minDiameter ?? 0, maxDiameter ?? 0 }),
							Velocity = item["close_approach_data"]?[0]?["relative_velocity"]?.Value<decimal>("kilometers_per_hour"),
							Date = item["close_approach_data"]?[0]?.Value<DateTime>("close_approach_date"),
							Hazardous = item.Value<bool>("is_potentially_hazardous_asteroid"),
							Planet = item["close_approach_data"]?[0]?.Value<string>("orbiting_body")
						});
					}
				}
			}
			return asteroids;
		}
		public List<AsteroidResponseDto> AsAsteroidsResponse(List<AsteroidDto> asteroidsData)
		{
			var asteroidsResponse = asteroidsData.Select(l => new AsteroidResponseDto()
			{
				Nombre = l.Name,
				Diametro = l.AverageDiameter,
				Velocidad = l.Velocity,
				Fecha = l.Date,
				Planeta = l.Planet
			}).ToList();

			return asteroidsResponse;
		}
	}
}
