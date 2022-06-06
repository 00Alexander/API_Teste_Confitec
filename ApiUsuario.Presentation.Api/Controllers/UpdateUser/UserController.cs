using ApiUsuario.Application.Contracts;
using ApiUsuario.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Presentation.Api.Controllers.UpdateUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPut]
        public IActionResult Put([FromServices] IUserApplicationService service, UpdateUserModel model)
        {

            try
            {
                service.Update(model);
                return Ok("Usuario atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
