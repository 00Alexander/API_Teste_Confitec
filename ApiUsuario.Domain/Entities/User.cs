using ApiUsuario.Domain.ValeuObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiUsuario.Domain.Entities
{
    public class User
    {
        public User(string name, string lastName, string email, string birthDate, string scholarity)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = DateTime.Parse(birthDate);
            Scholarity = scholarity;
            Validate();
        }

        public User(int id, string name, string lastName, string email, string birthDate, string scholarity)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = DateTime.Parse(birthDate);
            Scholarity = scholarity;
            Validate();
        }

        public User(int id, string name, string lastName, Email email, DateTime birthDate, Scholarity scholarity)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Scholarity = scholarity;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public Email Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Scholarity Scholarity { get; private set; }

        private void Validate()
        {
            if (BirthDate >= DateTime.Now.Date)
            {
                throw new Exception("Erro, Data de nascimento inválida.");
            }
        }
    }
}
