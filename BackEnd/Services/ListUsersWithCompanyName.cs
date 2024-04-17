using System;
using BackEnd.Dto;
using BackEnd.Empresa.Services;
using BackEnd.Usuarios.Entity;

namespace BackEnd.Services
{
	public class ListUsersWithCompanyName
	{
        private readonly IListUsersWithCompanyNameDependencies _dependencies;

        public ListUsersWithCompanyName(IListUsersWithCompanyNameDependencies dependencies)
        {
            _dependencies = dependencies;
        }
        public async Task<List<UsuarioDto>> GetAllUsuarioDto()
        {
            List<UsuarioDto> resultUsuariosDto = new List<UsuarioDto>();

            List<UsuarioEntity> usuarios = await _dependencies.GetAllUsers();

            foreach (var usuario in usuarios)
            {
                EmpresaDto empresa = await _dependencies.GetEmpresa(usuario.IdEmpresa);

                UsuarioDto usuarioDto = new UsuarioDto
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    NombreEmpresa = empresa.Nombre
                };
                resultUsuariosDto.Add(usuarioDto);
            }
            return resultUsuariosDto;
        }
    }
}

