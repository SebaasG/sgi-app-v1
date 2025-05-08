using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.application.services;
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
            Console.WriteLine("1. Mostrar todos los proveedores");
            Console.WriteLine("2. Crear un nuevo proveedor");
            Console.WriteLine("3. Actualizar un proveedor");
            Console.WriteLine("4. Eliminar un proveedor");
            Console.WriteLine("5. Salir");
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
                    // ActualizarProveedor(); 
                    break;
                case "4":
                    // EliminarProveedor();
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

            Console.Write("Ingrese el id del tercero: ");
            cliente.Id = Console.ReadLine();

            Console.Write("Ingrese el nombre: ");
            cliente.Nombre = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            cliente.Apellidos = Console.ReadLine();

            Console.Write("Ingrese el email: ");
            cliente.Email = Console.ReadLine();

            Console.Write("Ingrese el tipo de documento: ");
            cliente.TipoDoc =Convert.ToInt32(Console.ReadLine()) ;

            Console.Write("Ingrese el tipo de tercero: ");
            cliente.TipoTercero =Convert.ToInt32(Console.ReadLine()) ;

            Console.Write("Ingrese la ciudad: ");
            cliente.CiudadId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese la fecha de nacimiento (yyyy-mm-dd): ");
            cliente.FechaNac = DateTime.Parse(Console.ReadLine());

            Console.Write("Ingrese la fecha de última compra (yyyy-mm-dd): ");
            cliente.FechaUCompra = DateTime.Parse(Console.ReadLine());

            _service.Add(cliente);
    }
    }
}