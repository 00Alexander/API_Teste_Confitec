using ApiUsuario.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Application.Contracts
{
    public interface IUserApplicationService 
    {
        void Insert(RegisterUserModel model);
        void Update(UpdateUserModel model);
        void Delete(int id);
        List<GetUserModel> GetAll();
        GetUserModel GetById(int id);

    }
}
