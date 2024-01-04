using Asteroids.Application.Infrastructure.Exceptions;

namespace Asteroids.Application
{
	public interface ITools
	{
		public decimal Average<T>(List<T> numbers);
	}
	public class Tools : ITools
	{
		public decimal Average<T>(List<T> numbers)
		{
			List<decimal> _numbers = new();

			try
			{
				if (numbers == null || !numbers.Any())
					throw new HttpException(new List<string> { "Error. Null or empty list" });

				foreach (T number in numbers)
				{
					if (decimal.TryParse(number?.ToString(), out decimal _number))
						_numbers.Add(_number);
				}

				return _numbers.Sum() / _numbers.Count;
			}
			catch (Exception ex)
			{
				throw new HttpException(new List<string> { ex.Message });
			}
		}
	}
}
