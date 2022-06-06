using ApiUsuario.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Presentation.Api.Controllers.RemoveUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpDelete("{id}")]
        public IActionResult Delete([FromServices] IUserApplicationService service, int id)
        {
            try
            {
                service.Delete(id);
                return Ok("Usuario deletado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
