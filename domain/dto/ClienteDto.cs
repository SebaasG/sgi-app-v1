using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app_v1.domain.dto
{
    public class ClienteDto
    {
           // Datos de Tercero
    public string Id { get; set; }             
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Email { get; set; }
    public int TipoDoc { get; set; }
    public int TipoTercero { get; set; }
    public int CiudadId { get; set; }

    // Datos de Cliente
    public DateTime FechaNac { get; set; }
    public DateTime FechaUCompra { get; set; }
    }
}