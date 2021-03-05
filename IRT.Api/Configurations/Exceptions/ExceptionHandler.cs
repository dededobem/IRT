using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using Newtonsoft.Json;
using System.Diagnostics;

namespace IRT.Api.Configurations.Exceptions
{
    public static class ExceptionHandler
	{
		public static void UseDetailsExceptionHandler(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(builder =>
			{
				builder.Run(async context =>
				{
					var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

					if (exceptionHandlerFeature != null)
					{
						var exception = exceptionHandlerFeature.Error;

						var problemDetails = new ProblemDetails
						{
							Instance = context.Request.HttpContext.Request.Path
						};

						if (exception is BadHttpRequestException badHttpRequestException)
						{
							problemDetails.Title = "Requisição inválida!";
							problemDetails.Status = StatusCodes.Status400BadRequest;
							problemDetails.Detail = badHttpRequestException.Message;
						}
						else
						{
							problemDetails.Title = exception.Message;
							problemDetails.Status = StatusCodes.Status500InternalServerError;
							problemDetails.Detail = exception.Demystify().ToString();
						}

						context.Response.StatusCode = problemDetails.Status.Value;
						context.Response.ContentType = "application/problem+json";

						var json = JsonConvert.SerializeObject(problemDetails);
						await context.Response.WriteAsync(json);
					}
				});
			});
		}
	}
}
