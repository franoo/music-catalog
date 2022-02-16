using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService, IUserService userService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginRequest login)
        {
            if (string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                return BadRequest();
            }

            var validUser = _userService.GetUser(login);

            if(validUser != null)
            {
                var generatedToken = _tokenService.BuildToken(validUser);
                Console.Write(generatedToken);
            }
            return Ok(null);
        }

        [AllowAnonymous]//test method
        [Route("generateHash")]
        [HttpPost]
        public IActionResult GenerateHash(LoginRequest login)
        {
            var password = _userService.HashPassword(login.Password);

            return Ok(password);
        }
    }
}
