using ApiUsuario.Domain.Contracts.Repositories;
using ApiUsuario.Domain.Contracts.Services;
using ApiUsuario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Domain.Services
{
    public class UserDomainService : BaseDomainService<User>, IUserDomainService
    {
        private readonly IUserRepository userRepository;

        public UserDomainService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public override void Insert(User user)
        {

            var existingUser = userRepository.GetByEmail(user.Email);
            
            if(existingUser != null)
            {
                throw new Exception("Erro, Usuário já está cadastrado.");
            }
            
            userRepository.Insert(user);

        }

        public override void Update(User user, User model)
        {
            var register = userRepository.GetByEmail(user.Email);

            if(register != null && register.Id != user.Id )
            {
                throw new Exception("Erro, Usuario não encontrado");
            }
            else
            {
                userRepository.Update(user, register);
                
            }
        }
    }
}
