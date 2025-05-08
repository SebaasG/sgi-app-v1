using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sgi_app.domain.ports;
using sgi_app.infrastructure.mysql;
using sgi_app.infrastructure.repositories;
using sgi_app_v1.domain.dto;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.infrastructure.repositories
{
    public class DClienteRepository : IGenericRepository<ClienteDto>, IDClienteRepository
    {
        private readonly ConexionSingleton _conexion;

    public DClienteRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }


        public List<ClienteDto> GetAll()
        {
            var clientes = new List<ClienteDto>();
            var connec = _conexion.ObtenerConexion();
            var query = "SELECT t.id AS tercero_id,t.nombre,t.apellidos,t.email,t.tipo_doc_id,t.tipo_tercero_id,t.ciudad_id,c.id AS cliente_id,c.fecha_nac,c.fecha_ultima_compra FROM terceros t INNER JOIN cliente c ON c.tercero_id = t.id;";
            using (var command = new MySqlCommand(query, connec))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new ClienteDto()
                        {
                            Id = reader.GetString("tercero_id"),
                            Nombre = reader.GetString("nombre"),
                            Apellidos = reader.GetString("apellidos"),
                            Email = reader.GetString("email"),
                            TipoDoc = reader.GetInt32("tipo_doc_id"),
                            TipoTercero = reader.GetInt32("tipo_tercero_id"),
                            CiudadId = reader.GetInt32("ciudad_id"),
                            FechaNac = reader.GetDateTime("fecha_nac"),
                            FechaUCompra = reader.GetDateTime("fecha_ultima_compra")
                        };
                        clientes.Add(cliente);
                    }
        
        }    
            }
             return clientes;
        }
       
        
        public void Add(ClienteDto entity)
        {
            var connec = _conexion.ObtenerConexion();
            string query = "CALL insertar_tercero_y_cliente(@id, @nombre, @apellidos, @email, @tipo_doc_id, @tipo_tercero_id, @ciudad_id, @fecha_nac, @fecha_ultima_compra)";
            using (var command = new MySqlCommand(query, connec))
            {
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@nombre", entity.Nombre);
                command.Parameters.AddWithValue("@apellidos", entity.Apellidos);
                command.Parameters.AddWithValue("@email", entity.Email);
                command.Parameters.AddWithValue("@tipo_doc_id", entity.TipoDoc);
                command.Parameters.AddWithValue("@tipo_tercero_id", entity.TipoTercero);
                command.Parameters.AddWithValue("@ciudad_id", entity.CiudadId);
                command.Parameters.AddWithValue("@fecha_nac", entity.FechaNac);
                command.Parameters.AddWithValue("@fecha_ultima_compra", entity.FechaUCompra);
                command.ExecuteNonQuery();
            }
          
        }
        public void Update(ClienteDto entity)
        {
        
        }
        public void Delete(int id)
        {
       
        }

    }
}