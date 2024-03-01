using ngLifeCounter.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Backend.Infrastructure
{
	public interface IAccountUserService
	{
		Task<LoginTokenDataModel> LoginAndRetrieveToken(string username, string password);
		Task<RegisterResultModel> RegisterUserAccount(RegisterModel newRegister);
	}
}
