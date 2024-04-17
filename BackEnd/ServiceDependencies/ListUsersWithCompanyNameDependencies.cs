using System;
using BackEnd.Dto;
using BackEnd.Empresa.Services;
using BackEnd.Repositories;
using BackEnd.Usuarios.Entity;

namespace BackEnd.ServiceDependencies
{
	public class ListUsersWithCompanyNameDependencies : IListUsersWithCompanyNameDependencies
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IUsuarioRepository _userRepo;

        public ListUsersWithCompanyNameDependencies(IHttpClientFactory httpClientFactory, IUsuarioRepository userRepo)
        {
            _httpClientFactory = httpClientFactory;
            _userRepo = userRepo;
        }

        public async Task<List<UsuarioEntity>> GetAllUsers()
        {
            return await _userRepo.GetAllUsers();
        }

        public async Task<EmpresaDto> GetEmpresa(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient("EmpresaMS");
            return await client.GetFromJsonAsync<EmpresaDto>($"empresa/{id}");
        }
    }
}

