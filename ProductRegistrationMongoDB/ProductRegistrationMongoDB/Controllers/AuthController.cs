using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProductRegistrationMongoDB.Domain.Entities;
using ProductRegistrationMongoDB.Domain.Interfaces;
using ProductRegistrationMongoDB.Models;

namespace ProductRegistrationMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _authService.AuthenticateAsync(model.Email, model.Password);

            if (user == null)
                return Unauthorized();

            // Pode retornar o token JWT ou outras informações do usuário
            return Ok(new { Token = user.JwtToken });
        }
    }
}
