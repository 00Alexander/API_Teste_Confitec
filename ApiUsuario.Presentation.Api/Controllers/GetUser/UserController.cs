using ApiUsuario.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuario.Presentation.Api.Controllers.GetUser
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll([FromServices] IUserApplicationService service)
        {
            try
            {
                return new OkObjectResult(service.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}
