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
		Task<LoginTokenDataModel> LoginAndRetrieveTokenForImpersonate(Guid userID);

		Task<RegisterResultModel> RegisterUserAccount(RegisterModel newRegister);
		Task SendPasswordResetEmail(string email);
		void Logout();
		Task<bool> ChangePasswordWithRequestLink(Guid requestID, string newPassword);
		Task<bool> ValidateRecoveryRequestID(Guid requestID);
		Task<List<UsersModel>> GetAllUsersAsync();
		Task ChangePassword(string currentPassword, string newPassword);

		Task<StatusPageResponseModel> GetSystemStatus();

	}
}
