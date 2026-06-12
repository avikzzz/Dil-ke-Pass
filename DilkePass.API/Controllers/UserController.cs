using DilkePass.Application.Users.Commands.CreateUser;
using DilkePass.Application.Users.Interfaces;
using DilkePass.Application.Users.Queries.GetUser;
using DilkePass.Application.Users.Commands.CreateUser;
using DilkePass.Application.Users.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using DilkePass.Application.Users.Commands.AuthenticateUser;

namespace DilkePass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserHandler _createUserHandler;
        private readonly GetUserHandler _getUserHandler;
        private readonly AuthenticateUserHandler _authenticateUserHandler;
        public UserController(CreateUserHandler createUserHandler, GetUserHandler getUserHandler, AuthenticateUserHandler authenticateUserHandler)
        {
            _createUserHandler = createUserHandler;
            _getUserHandler = getUserHandler;
            _authenticateUserHandler = authenticateUserHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUserAsync(CreateUserCommand createUser)
        {
            if (createUser == null)
                return BadRequest("Invalid request");
            var result = await _createUserHandler.CreateUserHandle(createUser);
            return Ok(result);
        }
        [HttpGet]        
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] GetUserQuery getUser)
        {
            //if (getUser == null)  Eta kokhono null hobe naa, cause Query emnitei ekta object banabe. Better check less than 0 kina
            if (getUser.Id<=0)
                return BadRequest("Provide a valid UserId");

            var result = await _getUserHandler.GetUserbyId(getUser);
            return Ok(result);

        }




        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUserLogin([FromBody]AuthenticateUserCommand authenticateUser)
        {
            if (authenticateUser == null)
                return BadRequest("Input error");
            var result = await _authenticateUserHandler.AuthenticateUser(authenticateUser);
            return Ok(result);

        }
    }
}
