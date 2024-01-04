namespace Asteroids.Application.Validations
{
	public static class ServicesValidations
	{
		public static void HttpResponseValidate(HttpResponseMessage response, string content)
		{
			if (!response.IsSuccessStatusCode)
				throw new Exception(content);
		}
	}
}
