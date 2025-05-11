using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app_v1.domain.ports
{
    public interface IGenericVenta<T>

    {
        List<T> GetById(int id);
        List<T> GetAll();
        Task<bool> Add(T entity);
        
    }
}