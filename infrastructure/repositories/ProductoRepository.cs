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
    public class ProductoRepository:IGenericRepository<Producto>, IProductoRepository
    {
        private readonly ConexionSingleton _conexion;

    public ProductoRepository(string connectionString)
    {
        _conexion = ConexionSingleton.Instancia(connectionString);
    }

    public List<Producto> GetAll()
    {
        var productos = new List<Producto>();
        var connec = _conexion.ObtenerConexion();

        string query = "SELECT * FROM Productos";
        using (var command = new MySqlCommand(query, connec))
        {
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var producto = new Producto()
                    {
                        Id = reader.GetString("id"),
                        Nombre = reader.GetString("nombre"),
                        Stock = reader.GetInt32("stock"),
                        StockMin = reader.GetInt32("stock_min"),
                        StockMax = reader.GetInt32("stock_max"),
                        harCode = reader.GetString("barcode"),
                        CreatedAt = reader.GetDateTime("created_at"),
                        UpdateAt = reader.GetDateTime("updated_at")
                    };
                    productos.Add(producto);
                }
            }
        }

        return productos;
    }

    public void Add(Producto entity)
    {
        var connec = _conexion.ObtenerConexion();
        string query = @"INSERT INTO Productos (id, nombre, stock, stock_min, stock_max, barcode, created_at, updated_at) 
                         VALUES (@id, @nombre, @stock, @stock_min, @stock_max, @barcode, @created_at, @updated_at)";

        using (var command = new MySqlCommand(query, connec))
        {
            command.Parameters.AddWithValue("@id", entity.Id);
            command.Parameters.AddWithValue("@nombre", entity.Nombre);
            command.Parameters.AddWithValue("@stock", entity.Stock);
            command.Parameters.AddWithValue("@stock_min", entity.StockMin);
            command.Parameters.AddWithValue("@stock_max", entity.StockMax);
            command.Parameters.AddWithValue("@barcode", entity.harCode);
            command.Parameters.AddWithValue("@created_at", entity.CreatedAt);
            command.Parameters.AddWithValue("@updated_at", entity.UpdateAt);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Producto entity)
    {
        var connec = _conexion.ObtenerConexion();
        string query = @"UPDATE Productos 
                         SET nombre = @nombre, stock = @stock, stock_min = @stock_min, 
                             stock_max = @stock_max, barcode = @barcode, updated_at = @updated_at 
                         WHERE id = @id";

        using (var command = new MySqlCommand(query, connec))
        {
            command.Parameters.AddWithValue("@id", entity.Id);
            command.Parameters.AddWithValue("@nombre", entity.Nombre);
            command.Parameters.AddWithValue("@stock", entity.Stock);
            command.Parameters.AddWithValue("@stock_min", entity.StockMin);
            command.Parameters.AddWithValue("@stock_max", entity.StockMax);
            command.Parameters.AddWithValue("@barcode", entity.harCode);
            command.Parameters.AddWithValue("@updated_at", entity.UpdateAt);
            command.ExecuteNonQuery();
        }
    }

    public void Delete(String id)
    {
        var connec = _conexion.ObtenerConexion();
        string query = "DELETE FROM Productos WHERE id = @id";
        using (var command = new MySqlCommand(query, connec))
        {
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
 
    }
}