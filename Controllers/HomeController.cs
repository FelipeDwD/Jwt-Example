using System.Threading.Tasks;
using Jwt_Example.Models;
using Jwt_Example.Repository;
using Jwt_Example.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jwt_Example.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        
        [HttpPost]
        [Route("auth")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User user)
        {
            var userRepo = UserRepository.GetUser(user.Username, user.Password);

            if(user == null)
                return NotFound(new {message = "Usuário ou senha inválidos"});

            var token = TokenService.GenerateToken(userRepo);
            userRepo.Password = "";

            return new
            {
                user = userRepo,
                token = token
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anonymous";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => "Auth";


        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Manager";

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee")]
        public string Employee() => "Employee";
    }
}