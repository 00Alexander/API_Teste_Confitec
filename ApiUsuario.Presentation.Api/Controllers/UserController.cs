using ApiUsuario.Application.Contracts;
using ApiUsuario.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace ApiUsuario.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService userApplicationService;
        public UserController(IUserApplicationService userApplicationService)
        {
            this.userApplicationService = userApplicationService;
        }

        [HttpPost]
        public IActionResult Post(RegisterUserModel model)
        {
            try
            {
                userApplicationService.Insert(model);
                return Ok("Usuario cadastrado com sucesso!");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(UpdateUserModel model)
        {
            try
            {
                userApplicationService.Update(model);
                return Ok("Usuario atualizado com sucesso!");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                userApplicationService.Delete(id);
                return Ok("Usuario deletado com sucesso!");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll( )
        {
            try
            {
                return Ok(userApplicationService.GetAll());
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(userApplicationService.GetById(id));
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

    }
}
