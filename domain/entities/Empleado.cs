using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Empleado
    {

        public string Id_Tercero { get; set; }             
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int TipoDoc { get; set; }
        public int TipoTercero { get; set; }
        public int CiudadId { get; set; }


// datos empelado

        public int Id { get; set; } 

        public DateTime FechaIngreso { get; set; }
        public double SalarioBase { get; set; }
        public int EpsId { get; set; }
        public int ArlId { get; set; }
    }
}