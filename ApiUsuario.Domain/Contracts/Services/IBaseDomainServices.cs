using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Domain.Contracts.Services
{
    public interface IBaseDomainServices<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj, T model);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(int id);
    }
}
