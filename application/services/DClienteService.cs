using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app_v1.domain.dto;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.application.services
{
    public class DClienteService
    {
        private readonly IDClienteRepository _repo;

        public DClienteService(IDClienteRepository repo)
        {
            _repo = repo;
        }
        
        public void ShowAll(){
            var Dclientes = _repo.GetAll();
            foreach (var cliente in Dclientes)
            {
                Console.WriteLine("si entra aqui");
                Console.WriteLine($"Id: {cliente.Id}, nombre: {cliente.Nombre}, apellidos: {cliente.Apellidos}" +
                    $", email: {cliente.Email}, tipoDoc: {cliente.TipoDoc}, TipoTercero: {cliente.TipoTercero}" +
                    $", ciudad: {cliente.CiudadId}, fechaNac: {cliente.FechaNac}, fechaUcompra: {cliente.FechaUCompra}");

            }
        }

        public void Add(ClienteDto cliente)
        {
            _repo.Add(cliente);
        }

        public void Update(ClienteDto cliente)
        {
            _repo.Update(cliente);
        }

        public void Delete(string id)
        {
            _repo.Delete(id);
        }
    }   
}