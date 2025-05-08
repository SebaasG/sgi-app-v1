using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app.infrastructure.mysql;
using sgi_app_v1.domain.dto;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.infrastructure.repositories
{
    public class DClienteRepository : IGenericRepository<ClienteDto>, IDClienteRepository
    {
        private readonly ConexionSingleton _conexion;

        public DClienteRepository(ConexionSingleton conexion)
        {
            _conexion = conexion;
        }

        public List<ClienteDto> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<ClienteDto> Add(ClienteDto entity)
        {
            throw new NotImplementedException();
        }
        public Task<ClienteDto> Update(ClienteDto entity)
        {
            throw new NotImplementedException();
        }
        public Task<ClienteDto> Delete(ClienteDto entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<ClienteDto>.Add(ClienteDto entity)
        {
            throw new NotImplementedException();
        }

        void IGenericRepository<ClienteDto>.Update(ClienteDto entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}