using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app_v1.domain.ports;
using sgi_app_v1.domain.dto;

namespace sgi_app_v1.application.services
{
    public class VentaService
    {
        private readonly IVentaDto _repo;

        public VentaService(IVentaDto repo)
        {
            _repo = repo;
        }

        public List<VentaDto> GetAll()
        {
            return _repo.GetAll();
        }

        public List<VentaDto> GetById(int id)
        {
            return _repo.GetById(id);
        }

        public async Task<bool> Add(VentaDto entity)
        {
            return await _repo.Add(entity);
        }
    }
}
