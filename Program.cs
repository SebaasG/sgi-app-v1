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
            var service3 = new ProductosService(factory.CrearProductoRepository());
            var compraService = new CompraServices(factory.CrearComprasRepository());
            var ventaService = new VentaService(factory.CrearVentaRepository());

            var proveedorUI = new ProveedorConsoleUI(proveedorService);
            var empleadoUI = new EmpleadoConsoleUI(empleadoService);
            var ClienteDto = new DClienteConsoleUi(DtoClienteService);
            var uiproductos = new ProductoConsoleUI(service3);
            var comprasUI = new ComprasConsoleUI(compraService);
            var ventasUI = new VentasConsoleUI(ventaService);




            
             string opcion = "";

                    while (opcion != "5")
                    {
                        Console.Clear();
                        Console.WriteLine("╔══════════════════════════════════════╗");
                        Console.WriteLine("║         ✨ MENÚ PRINCIPAL ✨          ║");
                        Console.WriteLine("╠══════════════════════════════════════╣");
                        Console.WriteLine("║ 1️⃣  Gestión de Empleados            ║");
                        Console.WriteLine("║ 2️⃣  Gestión de Proveedores          ║");
                        Console.WriteLine("║ 3️⃣  Gestión de Productos            ║");
                        Console.WriteLine("║ 4️⃣  Gestión de Clientes             ║");
                        Console.WriteLine("║ 5️⃣ Compras y Detalles              ║");
                        Console.WriteLine("║ 6   Venta y Detalles                 ║");
                        Console.WriteLine("║ 7    Salir                           ║");
                        Console.WriteLine("╚══════════════════════════════════════╝");
                        Console.ResetColor();
                        Console.Write("Seleccione una opción: ");
                        opcion = Console.ReadLine();

                        switch (opcion)
                        {
                            case "1":
                                empleadoUI.Ejecutar();
                                break;
                            case "2":
                                proveedorUI.Ejecutar();
                                break;
                            case "3":
                                uiproductos.Ejecutar();
                                break;
                            case "4":
                                ClienteDto.Ejecutar();
                                break;
                            case "5":
                                comprasUI.Ejecutar();
                                break;
                            case "6":
                                 ventasUI.Ejecutar();
                                break;
                            case "7":
                                Console.WriteLine("👋 ¡Hasta pronto!");
                                break;
                            default:

                                Console.WriteLine("⚠️  Opción no válida.");
                                break;
                        }

                        if (opcion != "7")
                        {
                            Console.WriteLine("\nPresione una tecla para volver al menú...");
                            Console.ReadKey();
                        }
                    }


        }
    }
}
