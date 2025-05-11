using MySql.Data.MySqlClient;
using sgi_app.domain.factory;
using sgi_app.domain.ports;
using sgi_app.infrastructure.repositories;
using sgi_app_v1.domain.dto;
using sgi_app_v1.domain.ports;
using sgi_app_v1.infrastructure.repositories;


namespace sgi_app.infrastructure.mysql
{
    public class mysqlDbFactory : IDbFactory               
    {
        private readonly string _connectionString;

        public mysqlDbFactory(string connectionString)
        {
            _connectionString = connectionString;
            ObtenerConexion();
        }

        public IProveedorRepository CrearProveedorRepository()
        {
           return new ProveedorRepository(_connectionString);
        }

         public IEmpleadosRepository CrearEmpleadoRepository()
        {
           return new EmpleadoRepository(_connectionString);
        }

        public IDClienteRepository CrearDClienteRepository()
        {
            return new DClienteRepository(_connectionString);
        }
          public IProductoRepository CrearProductoRepository()
        {
            return new ProductoRepository(_connectionString);
        }
        public IComprasRepository CrearComprasRepository()
        {
            return new ComprasRepository(_connectionString);
        }

        public IVentaDto CrearVentaRepository()
        {
            return new ventasRepository(_connectionString);
        }




        public MySqlConnection ObtenerConexion()
        {
            return ConexionSingleton.Instancia(_connectionString).ObtenerConexion();
        }
    }
}
