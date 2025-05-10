using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using sgi_app.domain.ports;
using sgi_app.infrastructure.mysql;
using sgi_app_v1.domain.entities;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.infrastructure.repositories
{
    public class ComprasRepository : IGenericRepository<Compras>, IComprasRepository
    {
        private readonly ConexionSingleton _conexion;

        public ComprasRepository(string connectionString)
        {
            _conexion = ConexionSingleton.Instancia(connectionString);
        }   
       public List<Compras> GetAll()
{
    var compras = new List<Compras>();
    var connec = _conexion.ObtenerConexion();

    var query = @"
        SELECT 
            c.id AS CompraId,
            c.tercero_prov_id AS IdProveedor,
            c.tercero_empl_id AS IdEmpleado,
            c.fecha AS FechaCompra,
            c.desc_compra AS DescripcionCompra,
            dc.id AS DetalleId,
            dc.fecha AS FechaDetalle,
            dc.producto_id AS ProductoId,
            dc.cantidad AS Cantidad,
            dc.valor AS Valor
        FROM Compras c
        JOIN Detalle_Compra dc ON dc.compra_id = c.id;
    ";

    using (var command = new MySqlCommand(query, connec))
    {
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var compra = new Compras()
                {
                    CompraId = reader.GetInt32("CompraId"),
                    IdProveedor = reader.GetString("IdProveedor"),
                    IdEmpleado = reader.GetString("IdEmpleado"),
                    FechaCompra = reader.GetDateTime("FechaCompra"),
                    DescripcionCompra = reader.GetString("DescripcionCompra"),
                    DetalleId = reader.GetInt32("DetalleId"),
                    FechaDetalle = reader.GetDateTime("FechaDetalle"),
                    ProductoId = reader.GetString("ProductoId"),
                    Cantidad = reader.GetInt32("Cantidad"),
                    Valor = reader.GetDouble("Valor")
                };
                compras.Add(compra);
            }
        }
    }

    return compras;
}
public void Add(Compras entity)
{
    var connec = _conexion.ObtenerConexion();
    string query = "CALL insertar_compra_y_detalle(@p_proveedor_id, @p_empleado_id, @p_fecha_compra, @p_descripcion, @p_fecha_detalle, @p_producto_id, @p_cantidad, @p_valor)";

    using (var command = new MySqlCommand(query, connec))
    {
        command.Parameters.AddWithValue("@p_proveedor_id", entity.IdProveedor);
        command.Parameters.AddWithValue("@p_empleado_id", entity.IdEmpleado);
        command.Parameters.AddWithValue("@p_fecha_compra", entity.FechaCompra);
        command.Parameters.AddWithValue("@p_descripcion", entity.DescripcionCompra);

        command.Parameters.AddWithValue("@p_fecha_detalle", entity.FechaDetalle);
        command.Parameters.AddWithValue("@p_producto_id", entity.ProductoId);
        command.Parameters.AddWithValue("@p_cantidad", entity.Cantidad);
        command.Parameters.AddWithValue("@p_valor", entity.Valor);

        command.ExecuteNonQuery();
    }
}

public void Update(Compras entity)
{
    var connec = _conexion.ObtenerConexion();
    string query = "CALL actualizar_compra_y_detalle(@p_compra_id, @p_proveedor_id, @p_empleado_id, @p_fecha_compra, @p_descripcion, @p_fecha_detalle, @p_producto_id, @p_cantidad, @p_valor)";

    using (var command = new MySqlCommand(query, connec))
    {
        command.Parameters.AddWithValue("@p_compra_id", entity.CompraId);
        command.Parameters.AddWithValue("@p_proveedor_id", entity.IdProveedor);
        command.Parameters.AddWithValue("@p_empleado_id", entity.IdEmpleado);
        command.Parameters.AddWithValue("@p_fecha_compra", entity.FechaCompra);
        command.Parameters.AddWithValue("@p_descripcion", entity.DescripcionCompra);

        command.Parameters.AddWithValue("@p_fecha_detalle", entity.FechaDetalle);
        command.Parameters.AddWithValue("@p_producto_id", entity.ProductoId);
        command.Parameters.AddWithValue("@p_cantidad", entity.Cantidad);
        command.Parameters.AddWithValue("@p_valor", entity.Valor);

        command.ExecuteNonQuery();
    }

       
}

public void Delete(String id)
{
    var connec = _conexion.ObtenerConexion();
    string query = "CALL eliminar_compra_y_detalle(@p_compra_id)";

    using (var command = new MySqlCommand(query, connec))
    {
        command.Parameters.AddWithValue("@p_compra_id", id);
        command.ExecuteNonQuery();  
    } 
}   


}	
}