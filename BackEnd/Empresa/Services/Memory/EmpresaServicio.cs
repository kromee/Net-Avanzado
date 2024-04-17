using System;
using System.Text.Json;
using BackEnd.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace BackEnd.Empresa.Services.Memory
{
   

    public class EmpresaServicio : IEmpresaServicio
    {
        private readonly MemoryCache _cache;
        private readonly IHttpClientFactory _httpClientFactory;

        public EmpresaServicio(IHttpClientFactory httpClientFactory)
		{
            _cache = new MemoryCache(new MemoryCacheOptions());
            _httpClientFactory = httpClientFactory;
        }

        public async Task<EmpresaDto> GetEmpresa(int id)
        {
            //Comprobar si existe
            if (!_cache.TryGetValue(id, out EmpresaDto empresa))
            {
                //Conslutar el elemenot en el microservicio
                empresa = await GetFromMicroservicio(id);
                _cache.Set(id, empresa);
                return empresa;
            }
       
            return empresa;

        }

        private async Task<EmpresaDto> GetFromMicroservicio(int id)
        {
            EmpresaDto empresaDto = null;

            try
            {
                HttpClient client = _httpClientFactory.CreateClient("EmpresaMS");
                empresaDto = await client.GetFromJsonAsync<EmpresaDto>($"empresa/{id}");
            }
            catch (HttpRequestException ex)
            {
                // Manejar excepciones relacionadas con la solicitud HTTP
                Console.WriteLine($"Error de solicitud HTTP: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                // Manejar excepciones relacionadas con la deserialización JSON
                Console.WriteLine($"Error de deserialización JSON: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejar cualquier otra excepción inesperada
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }

            // Retornar fuera del bloque try-catch
            return empresaDto;


        }

    }
}

