using ApiUsuario.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Presentation.Api.Controllers.GetUserById
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult GetById([FromServices] IUserApplicationService service, int id)
        {
            try
            {
                return new OkObjectResult(service.GetById(id));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

    }
}
