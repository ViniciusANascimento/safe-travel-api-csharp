using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateUser()
        {
            if (true)
            {
                return BadRequest();
            }
            return Created();
        }
        [HttpPut]
        public IActionResult UpdateUser()
        {
            if (true)
            {
                return BadRequest();
            }
            return Created();
        }

        [HttpGet("{id?}")]
        public IActionResult GetUsers(int? id)
        {
            if (true)
            {
                return BadRequest();
            }
            return Created();
        }
        

        [HttpDelete]
        public IActionResult DeleteUser()
        {
            if (true)
            {
                return BadRequest();
            }
            return Created();
        }
    }
}