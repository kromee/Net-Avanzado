using System;
using BackEnd.Dto;
using BackEnd.Empresa.Services.Distributed;
using BackEnd.Repositories;
using BackEnd.Services.WithCache;
using BackEnd.Usuarios.Entity;

namespace BackEnd.ServiceDependencies.WithDistributedCache
{
    public class ListUsersDistributedCacheServiceDependencies : IListUsersWithDistributedCache
    {
        private readonly IDistributedEmpresaServicio _empersaServicio;
        private readonly IUsuarioRepository _userRepo;

        public ListUsersDistributedCacheServiceDependencies(IDistributedEmpresaServicio empersaServicio, IUsuarioRepository userRepo)
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

