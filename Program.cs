using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using MiAppConsola.ui;
using sgi_app.application.services;
using sgi_app.domain.factory;
using sgi_app.infrastructure.mysql;
using sgi_app_v1.application.services;
using sgi_app_v1.application.ui;

namespace MiAppConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ruta a la raíz del proyecto (3 carpetas arriba desde bin/Debug/net8.0)
            var basePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
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

            var proveedorService = new ProveedorService(factory.CrearProveedorRepository());
            var DtoClienteService = new DClienteService(factory.CrearDClienteRepository());
            var empleadoService = new EmpleadosServices(factory.CrearEmpleadoRepository());


            var proveedorUI = new ProveedorConsoleUI(proveedorService);
            var empleadoUI = new EmpleadoConsoleUI(empleadoService);

            var empleadoDto = new DClienteConsoleUi(DtoClienteService);

            empleadoDto.Ejecutar();

            // Ejecutar la UI deseada
            // proveedorUI.Ejecutar();

        }
    }
}
