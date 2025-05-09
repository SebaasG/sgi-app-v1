using System;
using sgi_app.application.services;
using sgi_app.domain.entities;

namespace MiAppConsola.ui
{
    public class ProveedorConsoleUI
    {
        private readonly ProveedorService _service;

        public ProveedorConsoleUI(ProveedorService service)
        {
            _service = service;
        }

        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         ✨ MENÚ PRINCIPAL ✨        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1️⃣  Mostrar todos los proveedores    ║");
            Console.WriteLine("║ 2️⃣  Crear un nuevo proveedor         ║");
            Console.WriteLine("║ 3️⃣  Actualizar un proveedor          ║");
            Console.WriteLine("║ 4️⃣  Eliminar un proveedor          ║");
            Console.WriteLine("║ 5️⃣  Salir                            ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarTodos();
                    break;
                case "2":
                    CrearProveedor();
                    break;
                case "3":
                    ActualizarProveedor(); 
                    break;
                case "4":
                    EliminarProveedor();
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

        private void CrearProveedor()
        {
            var proveedor = new Proveedor();

            Console.Write("Ingrese el id del tercero: ");
            proveedor.TerceroId =Console.ReadLine();

            Console.Write("Ingrese el descuento: ");
            proveedor.Dcto = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el día de pago: ");
            proveedor.DiaPago = Convert.ToInt32(Console.ReadLine());

            _service.Add(proveedor);
            Console.WriteLine("Proveedor agregado correctamente.");
        }

        private void ActualizarProveedor()
        {
            var proveedor = new Proveedor();

            Console.Write("Ingrese el id del proveedor a actualizar: ");
            proveedor.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el nuevo id del tercero: ");
            proveedor.TerceroId = Console.ReadLine();

            Console.Write("Ingrese el nuevo descuento: ");
            proveedor.Dcto = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese el nuevo día de pago: ");
            proveedor.DiaPago = Convert.ToInt32(Console.ReadLine());

            _service.Update(proveedor);
            Console.WriteLine("Proveedor actualizado correctamente.");
        }
        private void EliminarProveedor()
        {
            Console.Write("Ingrese el id del proveedor a eliminar: ");
            string id = Console.ReadLine();

            _service.Delete(id);
            Console.WriteLine("Proveedor eliminado correctamente.");
         }
}
}
