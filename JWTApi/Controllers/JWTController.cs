using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTApi.Controllers
{
    [Route("api/[controller]")]
    public class JWTController : Controller
    {
        // GET: api/<controller>
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public bool Test([FromBody] string message)
        {
            return true;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Generate()
        {
            var secKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("%D*G-KaPdSgUkXp2"));
            var creds = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Halff.com",
                audience: "Halff.com",
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
