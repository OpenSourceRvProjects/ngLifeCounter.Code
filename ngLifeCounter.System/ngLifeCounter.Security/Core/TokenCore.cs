using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ngLifeCounter.Models;
using ngLifeCounter.Security.Infraestructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Security.Core
{
    public class TokenCore : ITokenCore
	{

		private IConfiguration _configuration;

		public TokenCore(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		public string RunTokenGeneration(List<KeyValuePair<string, string>> tokenInfo, Guid userID)
        {

            var permClaims = new List<Claim>();

            tokenInfo.ForEach(fe => permClaims.Add(new Claim(fe.Key, fe.Value)));

            //permClaims.Add(new Claim("companyId", userInfo.CompanyId.ToString()));
            //permClaims.Add(new Claim("email", userInfo.Email));


            var tokenAudience = _configuration["security:audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["security:JWT_PrivateKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expiration = permClaims.Any(a => a.Type == "allowDeleteActionToken" && a.Value == "true") ?
                DateTime.Now.AddSeconds(30) : new DateTime(9999,12,31);

            var token = new JwtSecurityToken(_configuration["security:issuer"],
              tokenAudience, claims: permClaims,
              null,
              expires: expiration,
              signingCredentials: credentials);



            //TODO: get time from token object
            //expiration = !generateSpecialToken ? DateTime.Now.AddMinutes(60) : DateTime.Now.AddSeconds(30);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
