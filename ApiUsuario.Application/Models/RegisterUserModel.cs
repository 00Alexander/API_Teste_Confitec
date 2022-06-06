using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiUsuario.Application.Models
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome. ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, informe o sobrenome. ")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email. ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de nascimento. ")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Por favor, informe a escolaridade. ")]
        public string Scholarity { get; set; }
    }
}
