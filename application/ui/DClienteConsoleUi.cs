using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
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
            Console.Clear();

            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         ✨ MENÚ Clientes ✨        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1️⃣  Mostrar todos los clientes      ║");
            Console.WriteLine("║ 2️⃣  Crear un nuevo cliente          ║");
            Console.WriteLine("║ 3️⃣  Actualizar un cliente           ║");
            Console.WriteLine("║ 4️⃣ Eliminar un cliente              ║");
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

        try
        {
            _service.Add(cliente);
            Console.WriteLine("Cliente creado exitosamente.");
        }       
        catch (System.Exception e)
        {
            Console.WriteLine("Error al crear el cliente. Verifique los datos ingresados."+ e);
           throw;
        }
         
    }

        private void ActualizarCliente()
        {   

            var cliente = new ClienteDto();
            Console.Write("Ingrese el id del cliente a actualizar: ");
            cliente.Id = Console.ReadLine();
            Console.Write("Ingrese el nuevo nombre: ");
            cliente.Nombre = Console.ReadLine();
            Console.Write("Ingrese los nuevos apellidos: ");
            cliente.Apellidos = Console.ReadLine();
            Console.Write("Ingrese el nuevo email: ");
            cliente.Email = Console.ReadLine();
            Console.Write("Ingrese el nuevo tipo de documento: ");
            cliente.TipoDoc = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nuevo tipo de tercero: ");
            cliente.TipoTercero = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese la nueva ciudad: ");
            cliente.CiudadId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese la nueva fecha de nacimiento (yyyy-mm-dd): ");
            cliente.FechaNac = DateTime.Parse(Console.ReadLine());
            Console.Write("Ingrese la nueva fecha de última compra (yyyy-mm-dd): ");
            cliente.FechaUCompra = DateTime.Parse(Console.ReadLine());
            try
            {
                _service.Update(cliente);
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Error al actualizar el cliente. Verifique los datos ingresados." + e);
                throw;
            }
                  Console.WriteLine("Cliente actualizado exitosamente.");
      
        }

        private void EliminarCliente()
        {
            Console.Write("Ingrese el id del cliente a eliminar: ");
            string id_tercero = Console.ReadLine();
            try
            {
                _service.Delete(id_tercero);
             
        }   
            catch (MySqlException e)
            {
                Console.WriteLine("Error al eliminar el cliente. Verifique el id ingresado." + e);
                throw;
            }
               Console.WriteLine("Cliente eliminado exitosamente.");
    }
    }


}