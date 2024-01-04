namespace Asteroids.Application.Validations
{
	public static class AsteroidsValidations
	{
		public static void ValidateDays(int days)
		{
			if (days == 0)
				throw new Exception("Error: El número de días es obligatorio. Contrate a este programador para resolver el error.");
		}
	}
}
