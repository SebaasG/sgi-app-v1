using MySql.Data.MySqlClient;
using sgi_app.domain.factory;


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

        // public IProveedorRepository CrearProveedorRepository()
        // {
        //    return new ProveedorRepository(_connectionString);
        // }

        public MySqlConnection ObtenerConexion()
        {
            return ConexionSingleton.Instancia(_connectionString).ObtenerConexion();
        }
    }
}
