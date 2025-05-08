using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app_v1.application.services;

namespace sgi_app_v1.application.ui
{
    public class ProductoConsoleUI
    {
        private readonly ProductosService _services;

    

        public ProductoConsoleUI(ProductosService services){
            _services = services;
        }

    public void Ejecutar (){
        Console.WriteLine("1. Mostrar todos los Productos");
        Console.WriteLine("2. Crear un nuevo Producto");
        Console.WriteLine("3. Actualizar un Producto");
        Console.WriteLine("4. Eliminar un Producto");
        Console.WriteLine("5. Salir");
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

    private void MostrarTodos(){
        _services.ShowAll();
    }

    private void CrearProducto()
    {
        var producto = new Producto();

        Console.Write("ID del producto: ");
        producto.Id = Console.ReadLine().Trim();

        Console.Write("Nombre del producto: ");
        producto.Nombre = Console.ReadLine().Trim();

        Console.Write("Stock: ");
        producto.Stock = Convert.ToInt32(Console.ReadLine());

        Console.Write("Stock mínimo: ");
        producto.StockMin = Convert.ToInt32(Console.ReadLine());

        Console.Write("Stock máximo: ");
        producto.StockMax = Convert.ToInt32(Console.ReadLine());

        Console.Write("Código de barras: ");
        producto.harCode = Console.ReadLine().Trim();

        producto.CreatedAt = DateTime.Now;
        producto.UpdateAt = DateTime.Now;

        _services.Add(producto);
        Console.WriteLine("Producto ingresado correctamente.");
    }

    private void EliminarProducto()
    {
        Console.Write("Ingrese el ID del producto a eliminar: ");
        string id = Console.ReadLine().Trim();

        _services.Delete(id);
        Console.WriteLine("Producto eliminado correctamente.");
    }

            private void ActualizarProducto()
            {
                var producto = new Producto();

                Console.Write("Ingrese el ID del producto a actualizar: ");
                producto.Id = Console.ReadLine().Trim();

                Console.Write("Nombre del producto: ");
                producto.Nombre = Console.ReadLine().Trim();

                Console.Write("Stock: ");
                producto.Stock = Convert.ToInt32(Console.ReadLine());

                Console.Write("Stock mínimo: ");
                producto.StockMin = Convert.ToInt32(Console.ReadLine());

                Console.Write("Stock máximo: ");
                producto.StockMax = Convert.ToInt32(Console.ReadLine());

                Console.Write("Código de barras: ");
                producto.harCode = Console.ReadLine().Trim();

                producto.UpdateAt = DateTime.Now;

                _services.Update(producto);
                Console.WriteLine("Producto actualizado correctamente.");
            }
    }
}