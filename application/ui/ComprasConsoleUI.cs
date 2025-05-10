using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app_v1.application.services;
using sgi_app_v1.domain.entities;

namespace sgi_app_v1.application.ui
{
    public class ComprasConsoleUI
    {
         private readonly CompraServices _service;
        public ComprasConsoleUI(CompraServices service)
        {
            _service = service;
        }
        public void Ejecutar()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         ✨ MENÚ Compras ✨        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1️⃣  Mostrar todos las compras       ║");
            Console.WriteLine("║ 2️⃣  Crear un nuevo compras          ║");
            Console.WriteLine("║ 5️⃣  Salir                           ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarTodos();
                    break;
                case "2":
                    CrearCompra();
                    break;
                case "3":
                    
                    break;
                case "4":
                    
                    break;
                case "5":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

         private void MostrarTodos()
        {
            _service.ShowAll();
        }

        private void CrearCompra()
        {

            var Compra = new Compras();

            Console.WriteLine("=== Crear Compra ===");
            Console.Write("Proveedor ID: ");
             Compra.IdProveedor = Console.ReadLine();

            Console.Write("Empleado ID: ");
            Compra.IdEmpleado = Console.ReadLine();

            Console.Write("Fecha de Compra (yyyy-MM-dd): ");
            Compra.FechaCompra = DateTime.Parse(Console.ReadLine());

            Console.Write("Descripción: ");
            Compra.DescripcionCompra = Console.ReadLine();

            Console.WriteLine("--- Detalle de la Compra ---");
            Console.Write("Fecha del Detalle (yyyy-MM-dd): ");
           Compra.FechaDetalle = DateTime.Parse(Console.ReadLine());

            Console.Write("Producto ID: ");
            Compra.ProductoId = Console.ReadLine();

            Console.Write("Cantidad: ");
            Compra.Cantidad = int.Parse(Console.ReadLine());

            Console.Write("Valor: ");
            Compra.Valor = double.Parse(Console.ReadLine());


            _service.Add(Compra);
            Console.WriteLine("compra realizada correctamente.");
        }

        public void Delete()
        {
            var compra = new Compras();
            String id  = Console.ReadLine();
            _service.Delete(id);
            Console.WriteLine("Compra eliminada correctamente.");
        }

        public void Update( ){
            var compra = new Compras();

            Console.WriteLine("=== Actualizar Compra ===");
            Console.Write("ID de la Compra: ");
            compra.CompraId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Proveedor ID: ");
            compra.IdProveedor = Console.ReadLine();

            Console.Write("Empleado ID: ");
            compra.IdEmpleado = Console.ReadLine();

            Console.Write("Fecha de Compra (yyyy-MM-dd): ");
            compra.FechaCompra = DateTime.Parse(Console.ReadLine());

            Console.Write("Descripción: ");
            compra.DescripcionCompra = Console.ReadLine();

            Console.WriteLine("--- Detalle de la Compra ---");
            Console.Write("Fecha del Detalle (yyyy-MM-dd): ");
           compra.FechaDetalle = DateTime.Parse(Console.ReadLine());

            Console.Write("Producto ID: ");
            compra.ProductoId = Console.ReadLine();

            Console.Write("Cantidad: ");
            compra.Cantidad = int.Parse(Console.ReadLine());

            Console.Write("Valor: ");
            compra.Valor = double.Parse(Console.ReadLine());

             _service.Update(compra);
             Console.WriteLine("Compra actualizada correctamente.");
        }

    }
}