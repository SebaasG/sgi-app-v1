using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sgi_app.domain.entities;
using sgi_app.domain.ports;
using sgi_app.infrastructure.mysql;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.infrastructure.repositories
{
    public class EmpleadoRepository: IGenericRepository<Empleado>, IEmpleadosRepository
    {
        private readonly ConexionSingleton _conexion;
        public EmpleadoRepository(string connectionString){
            _conexion = ConexionSingleton.Instancia(connectionString);
        }

        public List<Empleado> GetAll()
        {
            var empleados = new List<Empleado>();
            var connec = _conexion.ObtenerConexion();

            string query = "SELECT * FROM Empleado";
            using (var command = new MySqlCommand(query, connec))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var empleado = new Empleado()
                        {
                            Id = reader.GetInt32("id"),
                            TerceroId = reader.GetString("tercero_id"),
                            FechaIngreso = reader.GetDateTime("fecha_ingreso"),
                            SalarioBase = reader.GetDouble("salario_base"),
                            EpsId = reader.GetInt32("eps_id"),
                            ArlId = reader.GetInt32("arl_id")
                        };
                        empleados.Add(empleado);
                    }
                }
            }
            return empleados;
        }

        public void Add(Empleado entity)

        {

            try {

                var connec = _conexion.ObtenerConexion();
            string query = "INSERT INTO Empleado (tercero_id, fecha_ingreso, salario_base, eps_id, arl_id) VALUES (@tercero_id, @fecha_ingreso, @salario_base, @eps_id, @arl_id)";
            using (var command = new MySqlCommand(query, connec))
            {
                command.Parameters.AddWithValue("@tercero_id", entity.TerceroId);
                command.Parameters.AddWithValue("@fecha_ingreso", entity.FechaIngreso);
                command.Parameters.AddWithValue("@salario_base", entity.SalarioBase);
                command.Parameters.AddWithValue("@eps_id", entity.EpsId);
                command.Parameters.AddWithValue("@arl_id", entity.ArlId);
                command.ExecuteNonQuery();
            }

            }catch( MySqlException e){
                Console.WriteLine("error",e);
            }
        }

        public void Update(Empleado entity)
        {
            var connec = _conexion.ObtenerConexion();
            string query = "UPDATE Empleado SET tercero_id = @tercero_id,  fecha_ingreso = @fecha_ingreso, salario_base = @salario_base, eps_id = @eps_id,  arl_id = @arl_id WHERE id = @id";
            using (var command = new MySqlCommand(query, connec))
            {
                command.Parameters.AddWithValue("@id", entity.Id);
                command.Parameters.AddWithValue("@tercero_id", entity.TerceroId);
                command.Parameters.AddWithValue("@fecha_ingreso", entity.FechaIngreso);
                command.Parameters.AddWithValue("@salario_base", entity.SalarioBase);
                command.Parameters.AddWithValue("@eps_id", entity.EpsId);
                command.Parameters.AddWithValue("@arl_id", entity.ArlId);
                command.ExecuteNonQuery();
            }
        }

    public void Delete(int id)
    {
            var connec = _conexion.ObtenerConexion();
            string query = "DELETE FROM Empleado WHERE id = @id";
            using (var command = new MySqlCommand(query, connec))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}