using System;
using System.Collections.Generic;
using sgi_app_v1.application.services;
using sgi_app_v1.domain.dto;
using sgi_app_v1.domain.entities;

namespace sgi_app_v1.application.ui
{
    public class VentasConsoleUI
    {
        private readonly VentaService _service;

        public VentasConsoleUI(VentaService service)
        {
            _service = service;
        }

        public void Ejecutar()
        {
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         ✨ MENÚ Ventas ✨           ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1️⃣  Mostrar todas las ventas        ║");
            Console.WriteLine("║ 2️⃣  Crear una nueva venta           ║");
            Console.WriteLine("║ 3️⃣  Mostrar venta por ID            ║");
            Console.WriteLine("║ 4️⃣  Salir                           ║");
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MostrarTodos();
                    break;
                case "2":
                    CrearVenta();
                    break;
                case "3":
                    MostrarVentaPorId();
                    break;
                case "4":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void MostrarTodos()
        {
            var ventas = _service.GetAll();
            Console.WriteLine("=== Ventas Registradas ===");
            if (ventas.Count == 0)
            {
                Console.WriteLine("No hay ventas registradas.");
            }
            else
            {
                foreach (var venta in ventas)
                {
                    Console.WriteLine($"Venta ID: {venta.Id}, Cliente ID: {venta.TerceroClienteId}, Fecha: {venta.Fecha}");
                }
            }
        }

        private void CrearVenta()
        {
            var venta = new VentaDto
            {
                Detalles = new List<DetalleVentaDto>() // Inicializamos la lista de detalles.
            };

            Console.WriteLine("=== Crear Venta ===");

            // Recopilamos la información básica de la venta.
            Console.Write("Cliente ID: ");
            venta.TerceroClienteId = Console.ReadLine();

            Console.Write("Empleado ID: ");
            venta.TerceroEmpleadoId = Console.ReadLine();

            Console.Write("Fecha de Venta (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime fecha))
            {
                Console.WriteLine("Fecha no válida. Intenta nuevamente.");
                return;
            }
            venta.Fecha = fecha;

            Console.Write("Forma de Pago: ");
            venta.FormaPago = Console.ReadLine();

            // Ahora, vamos a agregar los detalles a la venta.
            bool agregarDetalles = true;
            while (agregarDetalles)
            {
                var detalle = new DetalleVentaDto();

                Console.WriteLine("--- Detalle de la Venta ---");
                Console.Write("Producto ID: ");
                detalle.ProductoId = Console.ReadLine();

                Console.Write("Cantidad: ");
                if (!int.TryParse(Console.ReadLine(), out int cantidad))
                {
                    Console.WriteLine("Cantidad no válida.");
                    continue; // Continuamos al siguiente ciclo si la cantidad es incorrecta
                }
                detalle.Cantidad = cantidad;

                Console.Write("Valor: ");
                if (!double.TryParse(Console.ReadLine(), out double valor))
                {
                    Console.WriteLine("Valor no válido.");
                    continue; // Continuamos al siguiente ciclo si el valor es incorrecto
                }
                detalle.Valor = valor;

                // Agregamos el detalle a la lista de detalles de la venta
                venta.Detalles.Add(detalle);

                // Preguntar si quiere agregar otro detalle
                Console.Write("¿Desea agregar otro detalle? (s/n): ");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() != "s")
                {
                    agregarDetalles = false; // Salimos del ciclo si la respuesta no es 's'
                }
            }

            // Llamamos al servicio para agregar la venta con sus detalles
            _service.Add(venta);
            Console.WriteLine("Venta realizada correctamente.");
        }


        private void MostrarVentaPorId()
        {
            Console.Write("Ingrese el ID de la venta: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var ventas = _service.GetById(id);

            if (ventas.Count == 0)
            {
                Console.WriteLine("Venta no encontrada.");
            }
            else
            {
                foreach (var venta in ventas)
                {
                    Console.WriteLine($"Venta ID: {venta.Id}, Cliente ID: {venta.TerceroClienteId}, Fecha: {venta.Fecha}");
                    // Mostrar detalles adicionales si es necesario
                }
            }
        }
    }
}
