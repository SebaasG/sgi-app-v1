using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app_v1.domain.dto
{
    public class VentaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TerceroClienteId { get; set; }
        public string TerceroEmpleadoId { get; set; }
        public string FormaPago { get; set; }

        // Lista de detalles de la venta
        public List<DetalleVentaDto> Detalles { get; set; } = new();
    }
}