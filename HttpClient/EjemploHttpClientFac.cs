using System;
namespace HttpClient
{
	public class EjemploHttpClientFac
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public EjemploHttpClientFac(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task Test(string usuario) {
			var cliente = _httpClientFactory.CreateClient("BackEnd");
			var result = await cliente.GetAsync($"/api/perfil/{usuario}");
			Console.WriteLine(result.StatusCode);
		}


	}
}

