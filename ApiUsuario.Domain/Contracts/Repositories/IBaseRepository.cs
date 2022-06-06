using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiUsuario.Domain.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj, T model);
        void Delete(T obj);
        List<T> GetAll();
        T GetById(int id);
    
    }
}
