using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace fakeLook_starter.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _config;


        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public string CreateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                //new Claim(ClaimTypes.Name, user.UserName)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(1500),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetPayload(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.ReadJwtToken(token).Claims.Where(claim => claim.Type == ClaimTypes.Name).Single().Value;
            }
            catch (Exception ex)
            {
                var notFoundResponse = new HttpResponseMessage(HttpStatusCode.NotFound);
                throw new HttpResponseException(notFoundResponse);
            }
        }

    }
}
