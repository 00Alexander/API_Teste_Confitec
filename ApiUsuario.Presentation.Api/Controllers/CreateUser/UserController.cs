using ApiUsuario.Application.Contracts;
using ApiUsuario.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ApiUsuario.Presentation.Api.Controllers.CreateUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromServices] IUserApplicationService service, [FromBody] RegisterUserModel request)
        {
            try
            {
                service.Insert(request);
                return Ok("Usuario cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
