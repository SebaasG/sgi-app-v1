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
            while (string.IsNullOrWhiteSpace(venta.TerceroClienteId)) // Validación
            {
                Console.Write("Cliente ID es obligatorio. Ingrese nuevamente: ");
                venta.TerceroClienteId = Console.ReadLine();
            }

            Console.Write("Empleado ID: ");
            venta.TerceroEmpleadoId = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(venta.TerceroEmpleadoId)) // Validación
            {
                Console.Write("Empleado ID es obligatorio. Ingrese nuevamente: ");
                venta.TerceroEmpleadoId = Console.ReadLine();
            }

            Console.Write("Fecha de Venta (yyyy-MM-dd): ");
            DateTime fecha;
            while (!DateTime.TryParse(Console.ReadLine(), out fecha)) // Validación
            {
                Console.Write("Fecha no válida. Intenta nuevamente (yyyy-MM-dd): ");
            }
            venta.Fecha = fecha;

            Console.Write("Forma de Pago: ");
            venta.FormaPago = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(venta.FormaPago)) // Validación
            {
                Console.Write("Forma de pago es obligatoria. Ingrese nuevamente: ");
                venta.FormaPago = Console.ReadLine();
            }

            // Ahora, vamos a agregar los detalles a la venta.
            bool agregarDetalles = true;
            while (agregarDetalles)
            {
                var detalle = new DetalleVentaDto();

                Console.WriteLine("--- Detalle de la Venta ---");
                Console.Write("Producto ID: ");
                detalle.ProductoId = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(detalle.ProductoId)) // Validación
                {
                    Console.Write("Producto ID es obligatorio. Ingrese nuevamente: ");
                    detalle.ProductoId = Console.ReadLine();
                }

                Console.Write("Cantidad: ");
                int cantidad;
                while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0) // Validación
                {
                    Console.Write("Cantidad no válida o menor a 1. Ingrese nuevamente: ");
                }
                detalle.Cantidad = cantidad;

                Console.Write("Valor: ");
                double valor;
                while (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0) // Validación
                {
                    Console.Write("Valor no válido o menor a 1. Ingrese nuevamente: ");
                }
                detalle.Valor = valor;

                venta.Detalles.Add(detalle);

                Console.Write("¿Desea agregar otro detalle? (s/n): ");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() != "s")
                {
                    agregarDetalles = false;
                }
            }

            _service.Add(venta);
            Console.WriteLine("Venta realizada correctamente.");
        }

        private void MostrarVentaPorId()
        {
            Console.Write("Ingrese el ID de la venta: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0) 
            {
                Console.Write("ID no válido. Ingrese nuevamente: ");
            }

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
