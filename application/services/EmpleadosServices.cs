using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sgi_app.domain.entities;
using sgi_app_v1.domain.ports;

namespace sgi_app_v1.application.services
{
    public class EmpleadosServices
    {
         private readonly IEmpleadosRepository _repo;


        public EmpleadosServices(IEmpleadosRepository repo){
            _repo = repo;
        }

        public void ShowAll(){
            var empleados = _repo.GetAll();
            foreach(var Empleado in empleados){
                Console.WriteLine("Empleados :");
                Console.WriteLine($"Id: {Empleado.Id}, nombre: {Empleado.Nombre}, apellidos: {Empleado.Apellidos}" +
                    $", email: {Empleado.Email}, tipoDoc: {Empleado.TipoDoc}, TipoTercero: {Empleado.TipoTercero}" +
                    $", ciudad: {Empleado.CiudadId}, Fecha_Ingreso: {Empleado.FechaIngreso} , SalarioBase: {Empleado.SalarioBase}, EPSId: {Empleado.EpsId}, ArlId: {Empleado.ArlId}" );
            }
        }
        public void Add(Empleado empleado){
            _repo.Add(empleado);
        }

        public void Update(Empleado empleado){
            _repo.Update(empleado);
        } 

        public void Delete(string id){
            _repo.Delete(id);
        }
    }
}