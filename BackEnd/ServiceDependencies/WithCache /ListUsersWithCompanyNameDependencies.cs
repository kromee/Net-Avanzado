using System;
using BackEnd.Dto;
using BackEnd.Empresa.Services.Memory;
using BackEnd.Repositories;
using BackEnd.Services.WithCache;
using BackEnd.Usuarios.Entity;

namespace BackEnd.ServiceDependencies.WithCache
{
	public class ListUsersMemoryCacheServiceDependencies : IListUsersWithMemoryCache
    {
        private readonly IEmpresaServicio _empersaServicio;
        private readonly IUsuarioRepository _userRepo;

        public ListUsersMemoryCacheServiceDependencies(IEmpresaServicio empersaServicio, IUsuarioRepository userRepo)
        {
            _empersaServicio = empersaServicio;
            _userRepo = userRepo;
        }

        public async Task<List<UsuarioEntity>> GetAllUsers()
        {
            return await _userRepo.GetAllUsers();
        }

        public async Task<EmpresaDto> GetEmpresa(int id)
        {
            return await _empersaServicio.GetEmpresa(id);
        }
    }
}

