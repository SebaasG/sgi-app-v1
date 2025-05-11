using System;
using sgi_app_v1.application.services;
using sgi_app_v1.domain.dto;

namespace sgi_app_v1.application.ui
{
    public class DClienteConsoleUi
    {
        private readonly DClienteService _service;

        public DClienteConsoleUi(DClienteService service)
        {
            _service = service;
        }

        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         ✨ MENÚ Clientes ✨        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1️⃣  Mostrar todos los clientes      ║");
            Console.WriteLine("║ 2️⃣  Crear un nuevo cliente          ║");
            Console.WriteLine("║ 3️⃣  Actualizar un cliente           ║");
            Console.WriteLine("║ 4️⃣  Eliminar un cliente             ║");
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
                    CrearClienteD();
                    break;
                case "3":
                    ActualizarCliente();
                    break;
                case "4":
                    EliminarCliente();
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

        private void CrearClienteD()
        {
            var cliente = new ClienteDto();

            // Validación para el id del tercero
            cliente.Id = PedirEntrada("Ingrese el id del tercero: ");
            while (string.IsNullOrWhiteSpace(cliente.Id))
            {
                Console.WriteLine("El id no puede estar vacío. Intente de nuevo.");
                cliente.Id = PedirEntrada("Ingrese el id del tercero: ");
            }

            // Validación para el nombre
            cliente.Nombre = PedirEntrada("Ingrese el nombre: ");
            while (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                Console.WriteLine("El nombre no puede estar vacío. Intente de nuevo.");
                cliente.Nombre = PedirEntrada("Ingrese el nombre: ");
            }

            // Validación para los apellidos
            cliente.Apellidos = PedirEntrada("Ingrese los apellidos: ");
            while (string.IsNullOrWhiteSpace(cliente.Apellidos))
            {
                Console.WriteLine("Los apellidos no pueden estar vacíos. Intente de nuevo.");
                cliente.Apellidos = PedirEntrada("Ingrese los apellidos: ");
            }

            // Validación para el email
            cliente.Email = PedirEntrada("Ingrese el email: ");
            while (string.IsNullOrWhiteSpace(cliente.Email))
            {
                Console.WriteLine("El email no puede estar vacío. Intente de nuevo.");
                cliente.Email = PedirEntrada("Ingrese el email: ");
            }

            // Validación para el tipo de documento
            cliente.TipoDoc = PedirEntradaInt("Ingrese el tipo de documento: ");
            while (cliente.TipoDoc <= 0)
            {
                Console.WriteLine("El tipo de documento debe ser un número válido.");
                cliente.TipoDoc = PedirEntradaInt("Ingrese el tipo de documento: ");
            }

            // Validación para el tipo de tercero
            cliente.TipoTercero = PedirEntradaInt("Ingrese el tipo de tercero: ");
            while (cliente.TipoTercero <= 0)
            {
                Console.WriteLine("El tipo de tercero debe ser un número válido.");
                cliente.TipoTercero = PedirEntradaInt("Ingrese el tipo de tercero: ");
            }

            // Validación para la ciudad
            cliente.CiudadId = PedirEntradaInt("Ingrese la ciudad: ");
            while (cliente.CiudadId <= 0)
            {
                Console.WriteLine("La ciudad debe ser un número válido.");
                cliente.CiudadId = PedirEntradaInt("Ingrese la ciudad: ");
            }

            // Validación para la fecha de nacimiento
            cliente.FechaNac = PedirEntradaFecha("Ingrese la fecha de nacimiento (yyyy-mm-dd): ");
            while (cliente.FechaNac == default(DateTime))
            {
                Console.WriteLine("Fecha de nacimiento no válida. Intente de nuevo.");
                cliente.FechaNac = PedirEntradaFecha("Ingrese la fecha de nacimiento (yyyy-mm-dd): ");
            }

            // Validación para la fecha de última compra
            cliente.FechaUCompra = PedirEntradaFecha("Ingrese la fecha de última compra (yyyy-mm-dd): ");
            while (cliente.FechaUCompra == default(DateTime))
            {
                Console.WriteLine("Fecha de última compra no válida. Intente de nuevo.");
                cliente.FechaUCompra = PedirEntradaFecha("Ingrese la fecha de última compra (yyyy-mm-dd): ");
            }

            try
            {
                _service.Add(cliente);
                Console.WriteLine("Cliente creado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cliente: {ex.Message}");
            }
        }

        private void ActualizarCliente()
        {
            var cliente = new ClienteDto();

            // Solicitar y validar ID del cliente
            cliente.Id = PedirEntrada("Ingrese el id del cliente a actualizar: ");
            while (string.IsNullOrWhiteSpace(cliente.Id))
            {
                Console.WriteLine("El id no puede estar vacío. Intente de nuevo.");
                cliente.Id = PedirEntrada("Ingrese el id del cliente a actualizar: ");
            }

            // Resto de los campos con validación similar a CrearClienteD...

            // Actualización en el servicio
            try
            {
                _service.Update(cliente);
                Console.WriteLine("Cliente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar cliente: {ex.Message}");
            }
        }

        private void EliminarCliente()
        {
            string id;
            // Solicitar y validar ID del cliente
            id = PedirEntrada("Ingrese el id del cliente a eliminar: ");
            while (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("El id no puede estar vacío. Intente de nuevo.");
                id = PedirEntrada("Ingrese el id del cliente a eliminar: ");
            }

            try
            {
                _service.Delete(id);
                Console.WriteLine("Cliente eliminado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
            }
        }

        private string PedirEntrada(string mensaje)
        {
            Console.Write(mensaje);
            return Console.ReadLine();
        }

        private int PedirEntradaInt(string mensaje)
        {
            int result;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine("Debe ingresar un número válido.");
                Console.Write(mensaje);
            }
            return result;
        }

        private DateTime PedirEntradaFecha(string mensaje)
        {
            DateTime result;
            Console.Write(mensaje);
            while (!DateTime.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Debe ingresar una fecha válida (yyyy-mm-dd).");
                Console.Write(mensaje);
            }
            return result;
        }
    }
}
