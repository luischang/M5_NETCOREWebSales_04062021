using M5_NETCOREWEBSales.Core.DTOs;
using M5_NETCOREWEBSales.Core.Enttites;
using M5_NETCOREWEBSales.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace M5_NETCOREWebSales.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IConfiguration _configuration;

        public TokenController(IUsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> Authentication(UsersAuthDTO userAuthDTO)
        {
            var userAuth = await _usersRepository.Authentication(userAuthDTO.Username, userAuthDTO.Password);
            if (userAuth != null)
            {
                var token = GenerarToken(userAuth);
                return Ok(token);
            }

            return NotFound();

        }


        private string GenerarToken(Users users)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));

            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var claims = new[] {
                new Claim(ClaimTypes.Name, users.Fullname),
                new Claim(ClaimTypes.Email, "luis.chang@qboinstitute.com"),
                new Claim(ClaimTypes.Role, users.Role),
                new Claim("UserId",users.Id.ToString())
            };

            var payload = new JwtPayload(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(5)
                );


            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }




    }
}
