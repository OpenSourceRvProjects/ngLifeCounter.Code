using Microsoft.EntityFrameworkCore;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.Models.Account;
using ngLifeCounter.Security.Core;
using ngLifeCounter.Security.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Backend.Services
{
	public class AccountUserService : IAccountUserService
	{
		private NgLifeCounterDbContext _dbContext;
		private IEncryptCore _encryptCore;
		private ITokenCore _tokenCore;

		public AccountUserService(NgLifeCounterDbContext dbContext, IEncryptCore encryptCore, ITokenCore tokenCore)
		{
			_dbContext = dbContext;
			_encryptCore = encryptCore;
			_tokenCore = tokenCore;
		}

		public async Task<RegisterResultModel> RegisterUserAccount(RegisterModel newRegister)
		{
			var result = new RegisterResultModel();
			var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.UserName == newRegister.UserName);
			if (user == null)
			{

				var encryptResult = await _encryptCore.RunEncrypt(newRegister.Password);
				var newUser = new User()
				{
					Id = Guid.NewGuid(),
					UserName = newRegister.UserName,
					PasswordHash = encryptResult.EncodeddPassword,
					Email = newRegister.Email,
					Salt = encryptResult.Salt,
					CreationDate = DateTime.Now,
				};

				_dbContext.Add(newUser);
				_dbContext.SaveChanges();

				var tokenInfo = new List<KeyValuePair<string, string>>()
				{
					new KeyValuePair<string, string>("userID", newUser.Id.ToString()),
					new KeyValuePair<string, string>("userName", newUser.UserName),
					new KeyValuePair<string, string>("allowSysAdminAccess", newUser.AllowSysAdminAccess.ToString()),
				};
				result.UserToken = _tokenCore.RunTokenGeneration(tokenInfo, newUser.Id);
			}


			return result;
		}

	}
}
