using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app.domain.ports;

namespace sgi_app.application.services
{
    public class ProveedorService
    {
        private readonly IProveedorRepository _repo;

        public ProveedorService(IProveedorRepository repo)
        {
            _repo = repo;
        }

        public void ShowAll()
        {
            var proveedores = _repo.GetAll();
            foreach (var proveedor in proveedores)
            {
                Console.WriteLine("si entra aqui");
                Console.WriteLine($"Id: {proveedor.Id}, TerceroId: {proveedor.TerceroId}, Dcto: {proveedor.Dcto}, DiaPago: {proveedor.DiaPago}");
            }
        }

        public void Add(Proveedor proveedor)
        {
            _repo.Add(proveedor);
        }

        public void Update(Proveedor proveedor)
        {
            _repo.Update(proveedor);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}