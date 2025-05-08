using System;
using Microsoft.Extensions.Configuration;
using sgi_app.domain.factory;
using sgi_app.infrastructure.mysql;

namespace MiAppConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var dbSettings = configuration.GetSection("DatabaseSettings");

            var server = dbSettings["Server"];
            var port = dbSettings["Port"];
            var database = dbSettings["Database"];
            var user = dbSettings["User"];
            var password = dbSettings["Password"];

            var connectionString = $"Server={server};Port={port};Database={database};User={user};Password={password};";


            Console.WriteLine("Cadena de conexión generada:");
            Console.WriteLine(connectionString);
            IDbFactory factory = new mysqlDbFactory(connectionString);


            // var conec = new mysqlDbFactory(connectionString);
           
            // var service = new ProveedorService(conec.CrearProveedorRepository());

            // //Para solo ejecurat el servicio de ProveedorService
            // var ui = new ProveedorConsoleUI(service);
            // ui.Ejecutar();

             
        }
    }
}
