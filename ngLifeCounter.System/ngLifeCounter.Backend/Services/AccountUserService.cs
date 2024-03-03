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
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ngLifeCounter.Backend.Services
{
	public class AccountUserService : IAccountUserService
	{
		private NgLifeCounterDbContext _dbContext;
		private IEncryptCore _encryptCore;
		private IDecryptCore _decryptCore;
		private ITokenCore _tokenCore;
		private IHttpContextAccessor _accessor;

		public AccountUserService(NgLifeCounterDbContext dbContext, IEncryptCore encryptCore,
			ITokenCore tokenCore, IDecryptCore decryptCore, IHttpContextAccessor accessor)
		{
			_dbContext = dbContext;
			_encryptCore = encryptCore;
			_decryptCore = decryptCore;
			_tokenCore = tokenCore;
			_accessor = accessor;
		}

		public async Task<LoginTokenDataModel> LoginAndRetrieveToken(string username, string password)
		{
			var response = new LoginTokenDataModel();
			var personalProfile = _dbContext.PersonalProfiles.Include(i => i.User).FirstOrDefault(f => f.User.UserName == username);
			var user = personalProfile.User;
			string token = string.Empty;

			if (user == null)
			{
				throw new Exception("User does not exist");
			}

			var isValidPassword = await _decryptCore.ValidatePassword(user.PasswordHash, user.Salt, password);

			if (isValidPassword)
			{
				response.Token = GenerateToken(user, personalProfile);
				response.UserName = user.UserName;
				response.Name = personalProfile.Name;
				response.LastName = personalProfile.LastName1 ?? string.Empty;

				

				try
				{
					_accessor.HttpContext.Session.SetString("userID", user.Id.ToString());
					var newCorrectLogin = new CorrectLogin()
					{
						Id = Guid.NewGuid(),
						UserId = user.Id,
						LoginDate = DateTime.Now,
						IpAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
					};

					_dbContext.Add(newCorrectLogin);
					_dbContext.SaveChanges();
				}
				catch (Exception ex)
				{
				}

			}

			return response;
		}

		public void Logout()
		{
			_accessor.HttpContext.Session.Remove("userID");

		}

		public async Task<RegisterResultModel> RegisterUserAccount(RegisterModel newRegister)
		{
			var anonimizedRequest = new RegisterModel() { 
				Email = newRegister.Email,
				LastName1 = newRegister.LastName1,
				LastName2 = newRegister.LastName2,
				Name = newRegister.Name,
				Password = "******************"
			};

			var newRequest = new SignUpRequest()
			{
				Id = Guid.NewGuid(),
				Ip = _accessor.HttpContext.Connection.RemoteIpAddress.ToString(),
				RequestObject = JsonSerializer.Serialize(anonimizedRequest),
				CreationDate = DateTime.Now,
			};

			var result = new RegisterResultModel();
			var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.UserName == newRegister.UserName);

			if (user != null)
			{
				_dbContext.Add(newRequest);
				_dbContext.SaveChanges();
				throw new Exception("User already exist");
			}

			var userEmail = await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == newRegister.Email);
			if (userEmail != null)
			{
				_dbContext.Add(newRequest);
				_dbContext.SaveChanges();
				throw new Exception("Email already used");
			}


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

			var newProfileUser = new PersonalProfile()
			{
				Id = Guid.NewGuid(),
				CreationDate = DateTime.Now,
				Name = newRegister.Name,
				LastName1 = newRegister.LastName1,
				LastName2 = newRegister.LastName2,
				UserId = newUser.Id,

			};

			try
			{
				newRequest.UserId = newUser.Id;
				_dbContext.Add(newUser);
				_dbContext.Add(newProfileUser);
				_dbContext.Add(newRequest);
				_dbContext.SaveChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}

			string token = GenerateToken(newUser, newProfileUser);
			result.UserToken = token;

			return result;
		}

		private string GenerateToken(User newUser, PersonalProfile newProfileUser)
		{
			var tokenInfo = new List<KeyValuePair<string, string>>()
				{
					new KeyValuePair<string, string>("userID", newUser.Id.ToString()),
					new KeyValuePair<string, string>("name", newProfileUser.Name),
					new KeyValuePair<string, string>("userName", newUser.UserName),
					new KeyValuePair<string, string>("tokenServerCreationDate", DateTime.Now.ToString()),
					new KeyValuePair<string, string>("allowSysAdminAccess", newUser.AllowSysAdminAccess.ToString()),
				};
			var token = _tokenCore.RunTokenGeneration(tokenInfo, newUser.Id);
			return token;
		}
	}
}
