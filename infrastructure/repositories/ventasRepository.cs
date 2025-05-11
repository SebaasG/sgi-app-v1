using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sgi_app.infrastructure.mysql;
using sgi_app_v1.domain.dto;
using sgi_app_v1.domain.ports;
using  System.Data;

namespace sgi_app_v1.infrastructure.repositories
{
    public class ventasRepository : IGenericVenta<VentaDto>, IVentaDto
    {
        private readonly ConexionSingleton _conexion;

        public ventasRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<VentaDto> GetAll()
        {
            var ventas = new List<VentaDto>();
            using var connec = _conexion.ObtenerConexion();
           
            string query = "SELECT * FROM Venta";
            using var cmd = new MySqlCommand(query, connec);
           using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                var venta = new VentaDto
                {
                    Id = reader.GetInt32("id"),
                    Fecha = reader.GetDateTime("fecha"),
                    TerceroClienteId = reader.GetString("tercero_cli_id"),
                    TerceroEmpleadoId = reader.GetString("tercero_emp_id"),
                    FormaPago = reader.GetString("forma_pago")
                };
                ventas.Add(venta);
            }
            return ventas;
        }
        }

        public List<VentaDto> GetById(int id)
        {
            var ventas = new List<VentaDto>();
            using var connec = _conexion.ObtenerConexion();
            string query = "SELECT * FROM Venta WHERE id = @id";
            using var cmd = new MySqlCommand(query, connec);
            cmd.Parameters.AddWithValue("@id", id);
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var venta = new VentaDto
                    {
                        Id = reader.GetInt32("id"),
                        Fecha = reader.GetDateTime("fecha"),
                        TerceroClienteId = reader.GetString("tercero_cli_id"),
                        TerceroEmpleadoId = reader.GetString("tercero_emp_id"),
                        FormaPago = reader.GetString("forma_pago")
                    };
                    ventas.Add(venta);
                }
            }
            return ventas;
        }

       public async Task<bool> Add(VentaDto venta)
{
    using var connection = _conexion.ObtenerConexion();

    try
    {
        // Asegúrate de que la conexión esté abierta
        var connec = _conexion.ObtenerConexion();

        using var command = new MySqlCommand("RegistrarVenta", connection);
        command.CommandType = CommandType.StoredProcedure;

        string detallesJson = System.Text.Json.JsonSerializer.Serialize(
            venta.Detalles.Select(d => new {
                productoId = d.ProductoId,
                cantidad = d.Cantidad,
                valor = d.Valor
            })
        );

        // Parámetros
        command.Parameters.AddWithValue("@p_fecha", venta.Fecha);
        command.Parameters.AddWithValue("@p_cliente", venta.TerceroClienteId);
        command.Parameters.AddWithValue("@p_empleado", venta.TerceroEmpleadoId);
        command.Parameters.AddWithValue("@p_forma_pago", venta.FormaPago);
        command.Parameters.AddWithValue("@p_detalles", detallesJson);

        await command.ExecuteNonQueryAsync();
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al ejecutar procedimiento: " + ex.Message);
        return false;
    }
}
    }
}


