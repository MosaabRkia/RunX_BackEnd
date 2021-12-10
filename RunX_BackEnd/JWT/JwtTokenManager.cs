using DataAccess.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using RunX_BackEnd.Models;
using System.Web.Http;

namespace RunX_BackEnd.JWT
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        private SymmetricSecurityKey _key;
        public JwtTokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtConfig:Key")));
            //Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JwtConfig:Key"));
        }
   

        public string Authenticate(string email)
        {
            //var key = _configuration.GetValue<string>("JwtConfig:Key");
            //var keyBytes = Encoding.ASCII.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, email)
                }),
                Expires = DateTime.UtcNow.AddYears(5),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string forgotPasswordAuth(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.NameIdentifier, email)
                }),   
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddMinutes(5)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [Authorize]
        public string DeCode(string token)
        {
           
            //var key = _configuration.GetValue<string>("JwtConfig:Key");
            try
            {
              var  tokenHandler = new JwtSecurityTokenHandler().ValidateToken(token,new TokenValidationParameters() { 
                                IssuerSigningKey= _key,
                                ValidateLifetime=true,
                                ClockSkew=TimeSpan.Zero,
                                ValidateAudience = false,
                                ValidateIssuer = false,

                            }, out SecurityToken SToken);
                return tokenHandler.Claims.First(e => e.Type == ClaimTypes.NameIdentifier).Value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "false";
            }
             
            


        }
    }
}
