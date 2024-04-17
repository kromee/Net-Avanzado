using System;
using BackEnd.Dto;

namespace BackEnd.Empresa.Services.Distributed
{
    public interface IDistributedEmpresaServicio
    {
        Task<EmpresaDto> GetEmpresa(int id);
    }
}

