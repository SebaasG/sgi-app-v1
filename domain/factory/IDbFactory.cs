using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.ports;
using sgi_app_v1.domain.ports;


namespace sgi_app.domain.factory
{
    public interface IDbFactory
    {
        IProveedorRepository CrearProveedorRepository();
        IEmpleadosRepository CrearEmpleadoRepository();
        IDClienteRepository CrearDClienteRepository();
        IProductoRepository CrearProductoRepository();
        IComprasRepository CrearComprasRepository();

        IVentaDto CrearVentaRepository();

    }
}