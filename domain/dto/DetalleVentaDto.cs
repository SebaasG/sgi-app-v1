using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app_v1.domain.dto
{
    public class DetalleVentaDto
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Valor { get; set; }
    }
}