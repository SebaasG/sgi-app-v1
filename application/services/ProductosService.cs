using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.application.services
{
    public class ProductosService
    {
        private readonly IProductoRepository _repo;

        public ProductosService(IProductoRepository repo){
            _repo = repo;
        }

        public void ShowAll(){
            var productos = _repo.GetAll();
            foreach(var producto in productos){
                Console.WriteLine("Producto:");
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Stock: {producto.Stock}, StockMin: {producto.StockMin}, StockMax: {producto.StockMax}, Barcode: {producto.harCode}, Fecha Creación: {producto.CreatedAt}, Fecha Actualización: {producto.UpdateAt}");
            }
        }

        public void Add(Producto producto){
            _repo.Add(producto);
        }

        public void Update(Producto producto){
            _repo.Update(producto);
        } 

        public void Delete(string id){
            _repo.Delete(id);
        }
    }
}