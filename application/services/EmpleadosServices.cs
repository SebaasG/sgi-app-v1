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
                Console.WriteLine($"id: {Empleado.Id} ,  terceroID: {Empleado.TerceroId} , Fechaingreso: {Empleado.FechaIngreso} , salarioBase: {Empleado.SalarioBase}, EpsID: {Empleado.EpsId}, ArlID:{Empleado.ArlId}");
            }
        }
        public void Add(Empleado empleado){
            _repo.Add(empleado);
        }

        public void Update(Empleado empleado){
            _repo.Update(empleado);
        } 

        public void Delete(int id){
            _repo.Delete(id);
        }
    }
}