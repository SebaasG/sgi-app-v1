using System;
using sgi_app.domain.entities;
using sgi_app_v1.application.services;

namespace sgi_app_v1.application.ui
{
    public class EmpleadoConsoleUI
    {
        private readonly EmpleadosServices _services;

        public EmpleadoConsoleUI(EmpleadosServices services)
        {
            _services = services;
        }

        public void Ejecutar()
        {
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

        private void MostrarTodos()
        {
            _services.ShowAll();
        }

        private void CrearEmpleado()
        {
            var empleado = new Empleado();

            // Validación para el ID del tercero
            do
            {
                Console.Write("Ingrese el id del tercero: ");
                empleado.Id_Tercero = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Id_Tercero))
                {
                    Console.WriteLine("El id del tercero no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Id_Tercero));

            // Validación para el nombre
            do
            {
                Console.Write("Ingrese el nombre: ");
                empleado.Nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Nombre));

            // Validación para los apellidos
            do
            {
                Console.Write("Ingrese los apellidos: ");
                empleado.Apellidos = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Apellidos))
                {
                    Console.WriteLine("Los apellidos no pueden estar vacíos. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Apellidos));

            // Validación para el email
            do
            {
                Console.Write("Ingrese el email: ");
                empleado.Email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Email))
                {
                    Console.WriteLine("El email no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Email));

            // Validación para el tipo de documento
            int tipoDoc;
            do
            {
                Console.Write("Ingrese el tipo de documento: ");
                if (!int.TryParse(Console.ReadLine(), out tipoDoc))
                {
                    Console.WriteLine("El tipo de documento debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.TipoDoc = tipoDoc;
                    break;
                }
            } while (true);

            // Validación para el tipo de tercero
            int tipoTercero;
            do
            {
                Console.Write("Ingrese el tipo de tercero: ");
                if (!int.TryParse(Console.ReadLine(), out tipoTercero))
                {
                    Console.WriteLine("El tipo de tercero debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.TipoTercero = tipoTercero;
                    break;
                }
            } while (true);

            // Validación para la ciudad
            int ciudadId;
            do
            {
                Console.Write("Ingrese la ciudad: ");
                if (!int.TryParse(Console.ReadLine(), out ciudadId))
                {
                    Console.WriteLine("La ciudad debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.CiudadId = ciudadId;
                    break;
                }
            } while (true);

            empleado.FechaIngreso = DateTime.Now;

            // Validación para el salario base
            double salarioBase;
            do
            {
                Console.WriteLine("Salario Base: ");
                if (!double.TryParse(Console.ReadLine(), out salarioBase) || salarioBase <= 0)
                {
                    Console.WriteLine("El salario base debe ser un número positivo. Intente de nuevo.");
                }
                else
                {
                    empleado.SalarioBase = salarioBase;
                    break;
                }
            } while (true);

            // Validación para el EPS
            int epsId;
            do
            {
                Console.WriteLine("Ingrese EPS: ");
                if (!int.TryParse(Console.ReadLine(), out epsId))
                {
                    Console.WriteLine("El EPS debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.EpsId = epsId;
                    break;
                }
            } while (true);

            // Validación para el ARL
            int arlId;
            do
            {
                Console.WriteLine("Ingrese ARL: ");
                if (!int.TryParse(Console.ReadLine(), out arlId))
                {
                    Console.WriteLine("El ARL debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.ArlId = arlId;
                    break;
                }
            } while (true);

            _services.Add(empleado);
            Console.WriteLine("Empleado ingresado correctamente.");
        }

        private void EliminarEmpleado()
        {
            string id;
            do
            {
                Console.Write("Ingrese el id del empleado a eliminar: ");
                id = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("El id no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(id));

            _services.Delete(id);
            Console.WriteLine("Empleado eliminado correctamente.");
        }

        private void ActualizarEmpleado()
        {
            var empleado = new Empleado();

            // Validación para el ID del tercero
            do
            {
                Console.Write("Ingrese el id del tercero: ");
                empleado.Id_Tercero = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Id_Tercero))
                {
                    Console.WriteLine("El id del tercero no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Id_Tercero));

            // Validación para el nombre
            do
            {
                Console.Write("Ingrese el nombre: ");
                empleado.Nombre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Nombre))
                {
                    Console.WriteLine("El nombre no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Nombre));

            // Validación para los apellidos
            do
            {
                Console.Write("Ingrese los apellidos: ");
                empleado.Apellidos = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Apellidos))
                {
                    Console.WriteLine("Los apellidos no pueden estar vacíos. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Apellidos));

            // Validación para el email
            do
            {
                Console.Write("Ingrese el email: ");
                empleado.Email = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(empleado.Email))
                {
                    Console.WriteLine("El email no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(empleado.Email));

            // Validación para el tipo de documento
            int tipoDoc;
            do
            {
                Console.Write("Ingrese el tipo de documento: ");
                if (!int.TryParse(Console.ReadLine(), out tipoDoc))
                {
                    Console.WriteLine("El tipo de documento debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.TipoDoc = tipoDoc;
                    break;
                }
            } while (true);

            // Validación para el tipo de tercero
            int tipoTercero;
            do
            {
                Console.Write("Ingrese el tipo de tercero: ");
                if (!int.TryParse(Console.ReadLine(), out tipoTercero))
                {
                    Console.WriteLine("El tipo de tercero debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.TipoTercero = tipoTercero;
                    break;
                }
            } while (true);

            // Validación para la ciudad
            int ciudadId;
            do
            {
                Console.Write("Ingrese la ciudad: ");
                if (!int.TryParse(Console.ReadLine(), out ciudadId))
                {
                    Console.WriteLine("La ciudad debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.CiudadId = ciudadId;
                    break;
                }
            } while (true);

            empleado.FechaIngreso = DateTime.Now;

            // Validación para el salario base
            double salarioBase;
            do
            {
                Console.WriteLine("Salario Base: ");
                if (!double.TryParse(Console.ReadLine(), out salarioBase) || salarioBase <= 0)
                {
                    Console.WriteLine("El salario base debe ser un número positivo. Intente de nuevo.");
                }
                else
                {
                    empleado.SalarioBase = salarioBase;
                    break;
                }
            } while (true);

            // Validación para el EPS
            int epsId;
            do
            {
                Console.WriteLine("Ingrese EPS: ");
                if (!int.TryParse(Console.ReadLine(), out epsId))
                {
                    Console.WriteLine("El EPS debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.EpsId = epsId;
                    break;
                }
            } while (true);

            // Validación para el ARL
            int arlId;
            do
            {
                Console.WriteLine("Ingrese ARL: ");
                if (!int.TryParse(Console.ReadLine(), out arlId))
                {
                    Console.WriteLine("El ARL debe ser un número válido. Intente de nuevo.");
                }
                else
                {
                    empleado.ArlId = arlId;
                    break;
                }
            } while (true);

            _services.Update(empleado);
            Console.WriteLine("Empleado actualizado correctamente.");
        }
    }
}
