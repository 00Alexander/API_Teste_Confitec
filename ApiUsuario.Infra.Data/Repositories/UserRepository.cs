using ApiUsuario.Domain.Contracts.Repositories;
using ApiUsuario.Domain.Entities;
using ApiUsuario.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiUsuario.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext) 
        {
            this.dataContext = dataContext;
        }

        public User GetByEmail(string email)
        {
            return dataContext.User.FirstOrDefault(f => f.Email.Equals(email));
        }


    }
}
