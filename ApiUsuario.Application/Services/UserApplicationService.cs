using ApiUsuario.Application.Contracts;
using ApiUsuario.Application.Models;
using ApiUsuario.Domain.Contracts.Services;
using ApiUsuario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserDomainService userDomainService;
        public UserApplicationService(IUserDomainService userDomainService)
        {
            this.userDomainService = userDomainService;
        }

        public void Insert(RegisterUserModel model)
        {
            var user = new User(

                model.Name,
                model.LastName,
                model.Email,
                model.BirthDate,
                model.Scholarity.ToUpper()
                
                );

            userDomainService.Insert(user);
            
        }

        public void Update(UpdateUserModel model)
        {
            var user = new User(

                    int.Parse(model.Id),
                    model.Name,
                    model.LastName,
                    model.Email,
                    model.BirthDate,
                    model.Scholarity.ToUpper()
                );

            userDomainService.Update(user, user);
        }

        public void Delete(int id)
        {
            var user = userDomainService.GetById(id);

            if(user != null)
            {
                userDomainService.Delete(user);
            }
            else
            {
                throw new Exception("Erro, Usuairo não encontrado");
            }

        }

        public List<GetUserModel> GetAll()
        {
            var users = new List<GetUserModel>();

            foreach (var item in userDomainService.GetAll())
            {
                var userModel = new GetUserModel();

                userModel.Id = item.Id.ToString();
                userModel.Name = item.Name;
                userModel.LastName = item.LastName;
                userModel.Email = item.Email;
                userModel.BirthDate = item.BirthDate.ToString("dd/MM/yyyy");
                userModel.Scholarity = item.Scholarity;

                users.Add(userModel);
            }
            return users;
        }

        public GetUserModel GetById(int id)
        {
            var user = userDomainService.GetById(id);

            if(user != null) 
            {
                var userModel = new GetUserModel();

                userModel.Id = user.Id.ToString();
                userModel.Name = user.Name;
                userModel.LastName = user.LastName;
                userModel.Email = user.Email;
                userModel.BirthDate = user.BirthDate.ToString("dd/MM/yyyy");
                userModel.Scholarity = user.Scholarity;

                return userModel;

            }
            else 
            {
                throw new Exception("Erro! Usuario não encontrado.");
            }

        }
    }
}
