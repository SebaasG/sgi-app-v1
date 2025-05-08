using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sgi_app.domain.ports
{
    public interface IGenericRepository <T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}