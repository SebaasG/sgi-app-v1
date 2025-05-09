using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app_v1.domain.entities
{
    public class Venta
    {

        private DateTime fecha { get; set; }
        private string tercero_cli_id { get; set; }
        private string tercero_emp_id { get; set; }
        private string formapago { get; set; }
        public List<DetalleVenta> Detalle { get; set; }
    }
}