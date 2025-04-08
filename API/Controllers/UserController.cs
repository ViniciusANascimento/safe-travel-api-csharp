using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTO.User;
using API.Models;
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

        [HttpGet()]
        public async Task<IActionResult> GetUsers(string? id, int limit = 10, int offset = 0)
        {
            if (string.IsNullOrEmpty(id))
            {
                List<GetUserDTO> user = await _userService.GetUsers(limit, offset);
                return Ok(user);
            }
            else
            {
                GetUserDTO user = _userService.GetUsers(id);
                return Ok(user);
            }
            
        }
        
    }
}