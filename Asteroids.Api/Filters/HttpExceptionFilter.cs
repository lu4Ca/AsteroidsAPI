using Asteroids.Application.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Asteroids.Api.Filters
{
	public class HttpExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			var error = new HttpException(
				new List<string> { "Error interno: No se ha podido completar la acción" },
				HttpStatusCode.InternalServerError);

			context.HttpContext.Response.StatusCode = 500;

			if (context.Exception is HttpException)
			{
				error = context.Exception as HttpException;
				context.HttpContext.Response.StatusCode = (int)error.ErrorCode;
			}

			context.Result = new JsonResult(new { errors = error.Messages });
			base.OnException(context);
		}
	}
}
