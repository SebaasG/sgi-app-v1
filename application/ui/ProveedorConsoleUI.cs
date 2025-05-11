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
            Console.WriteLine("║         ✨ MENÚ Proveedores ✨        ║");
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

            // Validación simple para el ID del tercero
            Console.Write("Ingrese el id del tercero: ");
            proveedor.TerceroId = Console.ReadLine();

            // Validación para el descuento
            Console.Write("Ingrese el descuento: ");
            string dctoInput = Console.ReadLine();
            if (double.TryParse(dctoInput, out double descuento))
            {
                proveedor.Dcto = descuento;
            }
            else
            {
                Console.WriteLine("Descuento no válido, se asignará 0.");
                proveedor.Dcto = 0;
            }

            // Validación para el día de pago
            Console.Write("Ingrese el día de pago: ");
            string diaPagoInput = Console.ReadLine();
            if (int.TryParse(diaPagoInput, out int diaPago) && diaPago > 0 && diaPago <= 31)
            {
                proveedor.DiaPago = diaPago;
            }
            else
            {
                Console.WriteLine("Día de pago no válido, se asignará 1.");
                proveedor.DiaPago = 1;
            }

            _service.Add(proveedor);
            Console.WriteLine("Proveedor agregado correctamente.");
        }

        private void ActualizarProveedor()
        {
            var proveedor = new Proveedor();

            // Validación simple para el ID del proveedor
            Console.Write("Ingrese el id del proveedor a actualizar: ");
            string idInput = Console.ReadLine();
            if (int.TryParse(idInput, out int id) && id > 0)
            {
                proveedor.Id = id;
            }
            else
            {
                Console.WriteLine("ID no válido.");
                return;
            }

            // Validación para el ID del tercero
            Console.Write("Ingrese el nuevo id del tercero: ");
            proveedor.TerceroId = Console.ReadLine();

            // Validación para el descuento
            Console.Write("Ingrese el nuevo descuento: ");
            string dctoInput = Console.ReadLine();
            if (double.TryParse(dctoInput, out double descuento))
            {
                proveedor.Dcto = descuento;
            }
            else
            {
                Console.WriteLine("Descuento no válido, se asignará 0.");
                proveedor.Dcto = 0;
            }

            // Validación para el día de pago
            Console.Write("Ingrese el nuevo día de pago: ");
            string diaPagoInput = Console.ReadLine();
            if (int.TryParse(diaPagoInput, out int diaPago) && diaPago > 0 && diaPago <= 31)
            {
                proveedor.DiaPago = diaPago;
            }
            else
            {
                Console.WriteLine("Día de pago no válido, se asignará 1.");
                proveedor.DiaPago = 1;
            }

            _service.Update(proveedor);
            Console.WriteLine("Proveedor actualizado correctamente.");
        }

        private void EliminarProveedor()
        {
            // Validación para el ID del proveedor
            Console.Write("Ingrese el id del proveedor a eliminar: ");
            string idInput = Console.ReadLine();
            if (int.TryParse(idInput, out int id) && id > 0)
            {
                _service.Delete(id.ToString());
                Console.WriteLine("Proveedor eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("ID no válido.");
            }
        }
    }
}
