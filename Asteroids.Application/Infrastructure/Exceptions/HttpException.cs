using System.Net;

namespace Asteroids.Application.Infrastructure.Exceptions
{
	public class HttpException : Exception
	{
		public List<string> Messages { get; internal set; }

		public HttpStatusCode ErrorCode { get; internal set; }

		public HttpException()
		{
			Messages = new List<string>();
		}


		public HttpException(HttpStatusCode errorCode = HttpStatusCode.InternalServerError) : this()
		{
			ErrorCode = errorCode;
		}

		public HttpException(List<string> messages, HttpStatusCode errorCode = HttpStatusCode.InternalServerError)
		{
			Messages = messages ?? new List<string>();
			ErrorCode = errorCode;
		}
	}
}