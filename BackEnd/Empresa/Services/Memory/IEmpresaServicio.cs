using System;
using BackEnd.Dto;

namespace BackEnd.Empresa.Services.Memory
{
	public interface IEmpresaServicio
	{
        Task<EmpresaDto> GetEmpresa(int id);
    }
}

