using System;
using BackEnd.Dto;
using BackEnd.Usuarios.Entity;

namespace BackEnd.Services.WithCache
{
	public class ListUsersWithMemoryCache
	{
		private readonly IListUsersWithMemoryCache _dependencies;

        public ListUsersWithMemoryCache(IListUsersWithMemoryCache dependencies)
		{
            _dependencies = dependencies;
        }

		public async Task<List<UsuarioDto>> GetAllUsuarioDto() {
			List<UsuarioDto> resultUsuariosDto = new List<UsuarioDto>();

			List<UsuarioEntity> usuarios = await _dependencies.GetAllUsers();

			foreach (var usuario in usuarios) {
				EmpresaDto empresa = await _dependencies.GetEmpresa(usuario.IdEmpresa);
				UsuarioDto usuariodto = new UsuarioDto
				{
					Nombre = usuario.Nombre,
					Apellido = usuario.Apellido,
					NombreEmpresa = empresa.Nombre
                };

				resultUsuariosDto.Add(usuariodto);
			}

			return resultUsuariosDto;
		}
			
	}
}

