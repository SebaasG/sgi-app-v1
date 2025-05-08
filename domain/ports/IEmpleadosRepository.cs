using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app_v1.domain.ports
{
    public interface IEmpleadosRepository:IGenericRepository<Empleado>
    {
        
    }
}