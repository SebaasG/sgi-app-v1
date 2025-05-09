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

    string query = @"
        SELECT e.id AS empleado_id, e.fecha_ingreso, e.salario_base, e.eps_id, e.arl_id,
               t.id AS tercero_id, t.nombre, t.apellidos, t.email, 
               t.tipo_doc_id, t.tipo_tercero_id, t.ciudad_id
        FROM Empleado e
        INNER JOIN terceros t ON e.tercero_id = t.id";

    using (var command = new MySqlCommand(query, connec))
    {
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var empleado = new Empleado()
                {
                    Id = reader.GetInt32("empleado_id"),
                    Id_Tercero = reader.GetString("tercero_id"),
                    Nombre = reader.GetString("nombre"),
                    Apellidos = reader.GetString("apellidos"),
                    Email = reader.GetString("email"),
                    TipoDoc = reader.GetInt32("tipo_doc_id"),
                    TipoTercero = reader.GetInt32("tipo_tercero_id"),
                    CiudadId = reader.GetInt32("ciudad_id"),
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
    var connec = _conexion.ObtenerConexion();
    string query = "CALL insertar_tercero_y_empleado(@id, @nombre, @apellidos, @email, @tipo_doc_id, @tipo_tercero_id, @ciudad_id, @fecha_ingreso, @salario_base, @eps_id, @arl_id)";
    
    using (var command = new MySqlCommand(query, connec))
    {
        command.Parameters.AddWithValue("@id", entity.Id_Tercero);
        command.Parameters.AddWithValue("@nombre", entity.Nombre);
        command.Parameters.AddWithValue("@apellidos", entity.Apellidos);
        command.Parameters.AddWithValue("@email", entity.Email);
        command.Parameters.AddWithValue("@tipo_doc_id", entity.TipoDoc);
        command.Parameters.AddWithValue("@tipo_tercero_id", entity.TipoTercero);
        command.Parameters.AddWithValue("@ciudad_id", entity.CiudadId);
        command.Parameters.AddWithValue("@fecha_ingreso", entity.FechaIngreso);
        command.Parameters.AddWithValue("@salario_base", entity.SalarioBase);
        command.Parameters.AddWithValue("@eps_id", entity.EpsId);
        command.Parameters.AddWithValue("@arl_id", entity.ArlId);

        command.ExecuteNonQuery();
    }
}

        public void Update(Empleado entity)
{
    var connec = _conexion.ObtenerConexion();
    string query = "CALL actualizar_tercero_y_empleado(@id, @tercero_id, @nombre, @apellidos, @email, @tipo_doc_id, @tipo_tercero_id, @ciudad_id, @fecha_ingreso, @salario_base, @eps_id, @arl_id)";
    
    using (var command = new MySqlCommand(query, connec))
    {
        command.Parameters.AddWithValue("@id", entity.Id);
        command.Parameters.AddWithValue("@tercero_id", entity.Id_Tercero);
        command.Parameters.AddWithValue("@nombre", entity.Nombre);
        command.Parameters.AddWithValue("@apellidos", entity.Apellidos);
        command.Parameters.AddWithValue("@email", entity.Email);
        command.Parameters.AddWithValue("@tipo_doc_id", entity.TipoDoc);
        command.Parameters.AddWithValue("@tipo_tercero_id", entity.TipoTercero);
        command.Parameters.AddWithValue("@ciudad_id", entity.CiudadId);
        command.Parameters.AddWithValue("@fecha_ingreso", entity.FechaIngreso);
        command.Parameters.AddWithValue("@salario_base", entity.SalarioBase);
        command.Parameters.AddWithValue("@eps_id", entity.EpsId);
        command.Parameters.AddWithValue("@arl_id", entity.ArlId);

        command.ExecuteNonQuery();
    }
}


    public void Delete(string id)
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