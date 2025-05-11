using System;
using sgi_app.domain.entities;
using sgi_app_v1.application.services;

namespace sgi_app_v1.application.ui
{
    public class ProductoConsoleUI
    {
        private readonly ProductosService _services;

        public ProductoConsoleUI(ProductosService services)
        {
            _services = services;
        }

        public void Ejecutar()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine("║         ✨ MENÚ Productos ✨        ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.WriteLine("║ 1️⃣  Mostrar todos los Productos      ║");
            Console.WriteLine("║ 2️⃣  Crear un nuevo Producto          ║");
            Console.WriteLine("║ 3️⃣  Actualizar un Producto           ║");
            Console.WriteLine("║ 4️⃣  Eliminar un Producto            ║");
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
                    CrearProducto();
                    break;
                case "3":
                    ActualizarProducto();
                    break;
                case "4":
                    EliminarProducto();
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

        private void CrearProducto()
        {
            var producto = new Producto();

            // Validación para el ID
            do
            {
                Console.Write("ID del producto: ");
                producto.Id = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(producto.Id))
                {
                    Console.WriteLine("El ID no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(producto.Id));

            // Validación para el nombre
            do
            {
                Console.Write("Nombre del producto: ");
                producto.Nombre = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                {
                    Console.WriteLine("El nombre del producto no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(producto.Nombre));

            // Validación para el stock
            do
            {
                Console.Write("Stock: ");
                if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                {
                    Console.WriteLine("Stock no válido, debe ser un número entero positivo. Intente de nuevo.");
                }
                else
                {
                    producto.Stock = stock;
                    break;
                }
            } while (true);

            // Validación para el stock mínimo
            do
            {
                Console.Write("Stock mínimo: ");
                if (!int.TryParse(Console.ReadLine(), out int stockMin) || stockMin < 0)
                {
                    Console.WriteLine("Stock mínimo no válido, debe ser un número entero positivo. Intente de nuevo.");
                }
                else
                {
                    producto.StockMin = stockMin;
                    break;
                }
            } while (true);

            // Validación para el stock máximo
            do
            {
                Console.Write("Stock máximo: ");
                if (!int.TryParse(Console.ReadLine(), out int stockMax) || stockMax < 0)
                {
                    Console.WriteLine("Stock máximo no válido, debe ser un número entero positivo. Intente de nuevo.");
                }
                else
                {
                    producto.StockMax = stockMax;
                    break;
                }
            } while (true);

            // Validación para el código de barras
            do
            {
                Console.Write("Código de barras: ");
                producto.harCode = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(producto.harCode))
                {
                    Console.WriteLine("El código de barras no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(producto.harCode));

            producto.CreatedAt = DateTime.Now;
            producto.UpdateAt = DateTime.Now;

            _services.Add(producto);
            Console.WriteLine("Producto ingresado correctamente.");
        }

        private void EliminarProducto()
        {
            string id;
            do
            {
                Console.Write("Ingrese el ID del producto a eliminar: ");
                id = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("El ID no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(id));

            _services.Delete(id);
            Console.WriteLine("Producto eliminado correctamente.");
        }

        private void ActualizarProducto()
        {
            var producto = new Producto();

            // Validación para el ID del producto
            do
            {
                Console.Write("Ingrese el ID del producto a actualizar: ");
                producto.Id = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(producto.Id))
                {
                    Console.WriteLine("El ID no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(producto.Id));

            // Validación para el nombre
            do
            {
                Console.Write("Nombre del producto: ");
                producto.Nombre = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                {
                    Console.WriteLine("El nombre del producto no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(producto.Nombre));

            // Validación para el stock
            do
            {
                Console.Write("Stock: ");
                if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0)
                {
                    Console.WriteLine("Stock no válido, debe ser un número entero positivo. Intente de nuevo.");
                }
                else
                {
                    producto.Stock = stock;
                    break;
                }
            } while (true);

            // Validación para el stock mínimo
            do
            {
                Console.Write("Stock mínimo: ");
                if (!int.TryParse(Console.ReadLine(), out int stockMin) || stockMin < 0)
                {
                    Console.WriteLine("Stock mínimo no válido, debe ser un número entero positivo. Intente de nuevo.");
                }
                else
                {
                    producto.StockMin = stockMin;
                    break;
                }
            } while (true);

            // Validación para el stock máximo
            do
            {
                Console.Write("Stock máximo: ");
                if (!int.TryParse(Console.ReadLine(), out int stockMax) || stockMax < 0)
                {
                    Console.WriteLine("Stock máximo no válido, debe ser un número entero positivo. Intente de nuevo.");
                }
                else
                {
                    producto.StockMax = stockMax;
                    break;
                }
            } while (true);

            // Validación para el código de barras
            do
            {
                Console.Write("Código de barras: ");
                producto.harCode = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(producto.harCode))
                {
                    Console.WriteLine("El código de barras no puede estar vacío. Intente de nuevo.");
                }
            } while (string.IsNullOrWhiteSpace(producto.harCode));

            producto.UpdateAt = DateTime.Now;

            _services.Update(producto);
            Console.WriteLine("Producto actualizado correctamente.");
        }
    }
}
