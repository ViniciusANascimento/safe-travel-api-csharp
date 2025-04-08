using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService;
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var novoUsuario = _userService.CreateUser(user);
                return Created("api/user", novoUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // [HttpPut]
        // public IActionResult UpdateUser()
        // {
        //     if (true)
        //     {
        //         return BadRequest();
        //     }
        //     return Created();
        // }

        [HttpGet("{id?}")]
        public IActionResult GetUsers(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var user = _userService.GetUsers(id.ToString());
            return Ok(user);
        }
        

        // [HttpDelete]
        // public IActionResult DeleteUser()
        // {
        //     if (true)
        //     {
        //         return BadRequest();
        //     }
        //     return Created();
        // }
    }
}