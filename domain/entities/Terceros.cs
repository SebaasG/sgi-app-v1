using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.entities
{
    public class Terceros
    {

        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public int TipoDoc { get; set; }
        public int TipoTercero { get; set; }
        public int CiudadId { get; set; }

    }
}