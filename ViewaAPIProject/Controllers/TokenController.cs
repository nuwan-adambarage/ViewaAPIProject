using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ViewaAPIProject.Models;

namespace ViewaAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public IConfiguration _configuration;

        public TokenController(IConfiguration config, ApplicationDbContext context)
        {
            _configuration = config;
            _context = context;
        }        

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Post(UserInformation userInfo)
        {            
            if (userInfo == null)
            {
                return BadRequest("Invalid client request");
            }

            var userInDb = await _context.UserInformations.FirstOrDefaultAsync(u => u.Email == userInfo.Email && u.Password == userInfo.Password);

            if (userInDb == null)
                return Unauthorized();

            if (userInDb.Email == userInfo.Email && userInDb.Password == userInfo.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44344",
                    audience: "http://localhost:44344",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}