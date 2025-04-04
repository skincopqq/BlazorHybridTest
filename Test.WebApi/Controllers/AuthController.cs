using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Test.ApiShared.Models;
using Test.WebApi.Services;

namespace Test.WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtGenerator _jwtGenerator;

        public AuthController(JwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(ClaimTypes.Role, "User")
            };

                var token = _jwtGenerator.GenerateToken(claims);
                return Ok(new SuccessLoginDto{ AccessToken = token});
            }

            return Unauthorized();
        }


        [HttpGet("validate")]
        public IActionResult Validate(string token)
        {
            var isValid = _jwtGenerator.ValidateToken(token);
            return isValid ? Ok() : BadRequest();
        }
    }
}
