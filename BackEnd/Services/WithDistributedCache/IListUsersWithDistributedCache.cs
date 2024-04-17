using System;
using BackEnd.Dto;
using BackEnd.Usuarios.Entity;

namespace BackEnd.Services.WithCache
{
	public interface IListUsersWithDistributedCache
	{
        Task<List<UsuarioEntity>> GetAllUsers();
        Task<EmpresaDto> GetEmpresa(int id);
    }
}

