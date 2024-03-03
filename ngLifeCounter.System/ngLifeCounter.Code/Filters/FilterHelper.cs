using System.IdentityModel.Tokens.Jwt;

namespace ngLifeCounter.MVC.Filters
{
	public class FilterHelper
	{

		public static JwtSecurityToken GetTokenDataByStringValue(string rawToken)
		{
			var token = rawToken;
			var handler = new JwtSecurityTokenHandler();
			var jwtSecurityToken = handler.ReadJwtToken(token);
			return jwtSecurityToken;
		}
	}
}
