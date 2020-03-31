using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Account.Commands.Requests;
using Application.Account.Queries.Requests;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Presentation.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;

        public AccountController(IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var resp = await _mediator.Send(new LoginReq { Model = model });
                return Json(GenerateJwtToken(resp.Item1, resp.Item2, resp.Item3).Result);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
            
        }

        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            var resp = await _mediator.Send(new RegisterReq { Model = model });
            return Json(GenerateJwtToken(resp.Item1, resp.Item2, "HR"/*resp.Item3*/).Result);
        }

        private async Task<object> GenerateJwtToken(string email, IdentityUser user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}