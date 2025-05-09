using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app_v1.application.services;

namespace sgi_app_v1.application.ui
{
    public class EmpleadoConsoleUI
    {
          private readonly EmpleadosServices _services;

        public EmpleadoConsoleUI(EmpleadosServices services){
            _services = services;
        }


        public void Ejecutar (){
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         ✨ MENÚ Empleados ✨        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1️⃣  Mostrar todos los Empleados     ║");
            Console.WriteLine("║ 2️⃣  Crear un nuevo Empleados        ║");
            Console.WriteLine("║ 3️⃣  Actualizar un Empleados         ║");
            Console.WriteLine("║ 4️⃣  Eliminar un Empleados           ║");
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
                    CrearEmpleado();
                    break;
                case "3":
                    ActualizarEmpleado(); 
                    break;
                case "4":
                    EliminarEmpleado();
                    break;
                case "5":
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void MostrarTodos(){
            _services.ShowAll();
        }

        private void CrearEmpleado()
        {
            var empleado = new Empleado();

             Console.Write("Ingrese el id del tercero: ");
            empleado.Id_Tercero = Console.ReadLine();

            Console.Write("Ingrese el nombre: ");
            empleado.Nombre = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            empleado.Apellidos = Console.ReadLine();

            Console.Write("Ingrese el email: ");
            empleado.Email = Console.ReadLine();

            Console.Write("Ingrese el tipo de documento: ");
            empleado.TipoDoc =Convert.ToInt32(Console.ReadLine()) ;

            Console.Write("Ingrese el tipo de tercero: ");
            empleado.TipoTercero =Convert.ToInt32(Console.ReadLine()) ;

            Console.Write("Ingrese la ciudad: ");
            empleado.CiudadId = Convert.ToInt32(Console.ReadLine());

            
            empleado.FechaIngreso = DateTime.Now;

            Console.WriteLine("Salario Base: ");
            empleado.SalarioBase = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese EPS : ");
            empleado.EpsId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrerse ARL: ");
            empleado.ArlId = Convert.ToInt32(Console.ReadLine());


            _services.Add(empleado);
            Console.WriteLine("Ingresado correctamente");
        }

        private void EliminarEmpleado()
        {
            Console.Write("Ingrese el id del cliente a eliminar: ");
            string id = Console.ReadLine();

            _services.Delete(id);
            Console.WriteLine("Proveedor eliminado correctamente.");
         }


         private void ActualizarEmpleado()
        {
            var empleado = new Empleado();

           Console.Write("Ingrese el id del tercero: ");
            empleado.Id_Tercero = Console.ReadLine();

            Console.Write("Ingrese el nombre: ");
            empleado.Nombre = Console.ReadLine();

            Console.Write("Ingrese los apellidos: ");
            empleado.Apellidos = Console.ReadLine();

            Console.Write("Ingrese el email: ");
            empleado.Email = Console.ReadLine();

            Console.Write("Ingrese el tipo de documento: ");
            empleado.TipoDoc =Convert.ToInt32(Console.ReadLine()) ;

            Console.Write("Ingrese el tipo de tercero: ");
            empleado.TipoTercero =Convert.ToInt32(Console.ReadLine()) ;

            Console.Write("Ingrese la ciudad: ");
            empleado.CiudadId = Convert.ToInt32(Console.ReadLine());

           
            empleado.FechaIngreso = DateTime.Now;

            Console.WriteLine("Salario Base: ");
            empleado.SalarioBase = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Ingrese EPS : ");
            empleado.EpsId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrerse ARL: ");
            empleado.ArlId = Convert.ToInt32(Console.ReadLine());


            _services.Update(empleado);
            Console.WriteLine("empleado actualizado correctamente.");
        }


    }
}