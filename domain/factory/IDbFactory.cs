using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;


namespace sgi_app.domain.factory
{
    public interface IDbFactory
    {
        IProveedorRepository CrearProveedorRepository();
    }
}