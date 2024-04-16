using System;
namespace HttpClient
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services) {
			services.AddHttpClient("BackEnd", client => {
				client.BaseAddress = new Uri("http://www.localhost:5000");
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}
			app.UseRouting();

			app.UseEndpoints(endpoints => {
				endpoints.MapGet("/", async context =>
				{
					await context.Response.WriteAsync("Hola mundo");
				});
			});

		}
	}
}

