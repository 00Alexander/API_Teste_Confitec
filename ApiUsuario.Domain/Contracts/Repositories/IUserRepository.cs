using ApiUsuario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Domain.Contracts.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByEmail(string email);
    }
}
