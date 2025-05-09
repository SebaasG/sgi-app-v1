using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app_v1.domain.entities;

namespace sgi_app_v1.domain.ports
{
    public interface IDetalleRepository <DetalleVenta>
    {
        List<DetalleVenta> GetAll();
        void Add(DetalleVenta entity);
        void getById(int id);
    }
}