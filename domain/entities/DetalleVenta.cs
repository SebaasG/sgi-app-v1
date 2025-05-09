using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Misc;

namespace sgi_app_v1.domain.entities
{
    public class DetalleVenta
    {
        private int id { get; set; }
        private int factura_id { get; set; }
        private string producto_id { get; set; }
        private int cantidad { get; set; }
        private Double valor { get; set; }
    }
}