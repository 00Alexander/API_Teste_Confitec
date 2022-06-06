using ApiUsuario.Domain.Contracts.Repositories;
using ApiUsuario.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Domain.Services
{
    public class BaseDomainService<T> : IBaseDomainServices<T> where T : class
    {
        private readonly IBaseRepository<T> repository;

        public BaseDomainService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual void Insert(T obj)
        {
            repository.Insert(obj);
        }

        public virtual void Update(T obj, T model)
        {
           repository.Update(obj, model);
        }

        public  void Delete(T obj)
        {
            repository.Delete(obj);
        }

        public List<T> GetAll()
        {
           return repository.GetAll();
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
