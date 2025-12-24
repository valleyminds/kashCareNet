using Asp.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace KashCareService
{
	public  class KashCareProgram
	{
		public static void KashCareStart()
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddApiVersioning(options =>
			{
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.ReportApiVersions = true;
			});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "KashCareNet API v1");
					c.RoutePrefix = "swagger"; // default swagger path
				});
			}

			app.UseAuthorization();
			app.MapControllers();
			app.MapGet("/", context =>
			{
				context.Response.Redirect("/swagger");
				return Task.CompletedTask;
			});
			app.Run();
		}
	}
}