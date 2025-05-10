using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app_v1.domain.entities
{
    public class Compras
    {
        // Datos de la compra
    public int CompraId { get; set; }
    public string IdProveedor { get; set; }      // Tercero proveedor
    public string IdEmpleado { get; set; }       // Tercero empleado
    public DateTime FechaCompra { get; set; }
    public string DescripcionCompra { get; set; }

    // Datos del detalle de compra
    public int DetalleId { get; set; }
    public DateTime FechaDetalle { get; set; }
    public string ProductoId { get; set; }
    public int Cantidad { get; set; }
    public double Valor { get; set; }
    }
}