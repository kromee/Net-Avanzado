using System;
using BackEnd.Dto;
using BackEnd.Usuarios.Entity;

namespace BackEnd.Empresa.Services
{
	public interface IListUsersWithCompanyNameDependencies
	{
        Task<List<UsuarioEntity>> GetAllUsers();
        Task<EmpresaDto> GetEmpresa(int id);
    }
}

