using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.mysql;
using MySql.Data.MySqlClient;


namespace sgi_app.infrastructure.repositories
{
    public class ProveedorRepository : IGenericRepository<Proveedor>, IProveedorRepository
    {

        private readonly ConexionSingleton _conexion;


        public ProveedorRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Proveedor> GetAll()
        {
            var proveedores = new List<Proveedor>(); 
            var connec = _conexion.ObtenerConexion();

            string query = "SELECT * FROM Proveedor";
            using (var command = new MySqlCommand(query, connec))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        var proveedor = new Proveedor()
                        {
                            Id = reader.GetInt32("id"),
                            TerceroId = reader.GetString("tercero_id"),
                            Dcto = reader.GetDouble("dcto"),
                            DiaPago = reader.GetInt32("dia_pago")
                        };

                        proveedores.Add(proveedor);
                    }
                }
            }
            return proveedores;
        }


        public void Add(Proveedor entity)
        {
            var connec = _conexion.ObtenerConexion();
            string query = "INSERT INTO Proveedor (tercero_id, dcto, dia_pago) VALUES (@tercero_id, @dcto, @dia_pago)";
            using (var command = new MySqlCommand(query, connec))
            {
                command.Parameters.AddWithValue("@tercero_id", entity.TerceroId);
                command.Parameters.AddWithValue("@dcto", entity.Dcto);
                command.Parameters.AddWithValue("@dia_pago", entity.DiaPago);
                command.ExecuteNonQuery();
            }
        }
        public void Update(Proveedor entity)
        {
            var connec = _conexion.ObtenerConexion();
            string query = "UPDATE Proveedor SET tercero_id = @tercero_id, dcto = @dcto, dia_pago = @dia_pago WHERE id = @id";
            using (var command = new MySqlCommand(query, connec))
            {
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@tercero_id", entity.TerceroId);
                command.Parameters.AddWithValue("@dcto", entity.Dcto);
                command.Parameters.AddWithValue("@dia_pago", entity.DiaPago);
                command.ExecuteNonQuery();
            }
        }
        public void Delete(string id)
        {
            var connec = _conexion.ObtenerConexion();
            string query = "DELETE FROM Proveedor WHERE id = @id";
            using (var command = new MySqlCommand(query, connec))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }



}