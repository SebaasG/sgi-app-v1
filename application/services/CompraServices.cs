using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app_v1.domain.entities;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.application.services
{
    public class CompraServices
    {
        private readonly IComprasRepository _repo;

        public CompraServices(IComprasRepository repo)
        {
            _repo = repo;
        }

        public void ShowAll()
{
    var comprasConDetalle = _repo.GetAll(); // Suponiendo que GetAll() retorna una lista de CompraConDetalle

    foreach (var compra in comprasConDetalle)
    {
        Console.WriteLine("=== COMPRA ===");
        Console.WriteLine($"Compra ID: {compra.CompraId}, Proveedor: {compra.IdProveedor}, Empleado: {compra.IdEmpleado}");
        Console.WriteLine($"Fecha Compra: {compra.FechaCompra}, Descripción: {compra.DescripcionCompra}");

        Console.WriteLine("--- DETALLE COMPRA ---");
        Console.WriteLine($"Detalle ID: {compra.DetalleId}, Producto ID: {compra.ProductoId}");
        Console.WriteLine($"Cantidad: {compra.Cantidad}, Valor: {compra.Valor}, Fecha Detalle: {compra.FechaDetalle}");

        Console.WriteLine(); // Espacio entre compras
    }
}


        public void Add(Compras compras)
        {
            _repo.Add(compras);
        }

        public void Update(Compras compras)
        {
            _repo.Update(compras);
        }

        public void Delete(string id)
        {
            _repo.Delete(id);
        }
    }
}