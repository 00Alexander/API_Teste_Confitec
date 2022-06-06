using ApiUsuario.Domain.Contracts.Repositories;
using ApiUsuario.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiUsuario.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual void Insert(T obj)
        {
           dataContext.Entry(obj).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public virtual void Update(T obj, T model)
        {
            dataContext.Entry(model).State = EntityState.Detached;
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();

        }

        public virtual void Delete(T obj)
        {
            dataContext.Entry(obj).State = EntityState.Deleted;
            dataContext.SaveChanges();

        }

        public List<T> GetAll()
        {
            return dataContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
           return dataContext.Set<T>().Find(id);
        }

        public virtual void DetachLocal(T obj)
        {
                dataContext.Entry(obj).State = EntityState.Detached;
        }
    }
}
