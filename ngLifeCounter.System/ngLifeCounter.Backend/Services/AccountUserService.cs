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
using ngLifeCounter.EmailSender;
using ngLifeCounter.Models.Email;
using Microsoft.AspNetCore.Http.Extensions;
using ngLifeCounter.Models.Exceptions;
using Microsoft.Extensions.Configuration;

namespace ngLifeCounter.Backend.Services
{
	public class AccountUserService : IAccountUserService
	{
		private NgLifeCounterDbContext _dbContext;
		private IEncryptCore _encryptCore;
		private IDecryptCore _decryptCore;
		private ITokenCore _tokenCore;
		private IHttpContextAccessor _accessor;
		private IEmailSender _emailSender;
		private IConfiguration _configuration;

		public AccountUserService(NgLifeCounterDbContext dbContext, IEncryptCore encryptCore,
			ITokenCore tokenCore, IDecryptCore decryptCore, IHttpContextAccessor accessor,
			IEmailSender emailSender, IConfiguration configuration)
		{
			_dbContext = dbContext;
			_encryptCore = encryptCore;
			_decryptCore = decryptCore;
			_tokenCore = tokenCore;
			_accessor = accessor;
			_emailSender = emailSender;
			_configuration = configuration;
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
				response.IsSysAdmin = user.IsSystemAdmin;


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

		public async Task<List<UsersModel>> GetAllUsersAsync()
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));
			var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == currentUserID);

			if (user.IsSystemAdmin)
			{
				return await _dbContext.Users.Select(s => new UsersModel
				{
					UserID = s.Id,
					NickName = s.UserName,
					LoginCount = s.CorrectLogins.Count,
					CounterEventsCount = s.EventCounters.Count,
					RelapsesCount = s.Relapses.Count,
					Name = s.PersonalProfiles.FirstOrDefault().Name,
					LastName = s.PersonalProfiles.FirstOrDefault().LastName1,
				}).ToListAsync();

			}

			return new List<UsersModel>();
		}

		public async Task<RegisterResultModel> RegisterUserAccount(RegisterModel newRegister)
		{
			var anonimizedRequest = new RegisterModel()
			{
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

			//var userEmail = await _dbContext.Users.FirstOrDefaultAsync(f => f.Email == newRegister.Email);
			//if (userEmail != null)
			//{
			//	_dbContext.Add(newRequest);
			//	_dbContext.SaveChanges();
			//	throw new Exception("Email already used");
			//}


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

		public async Task SendPasswordResetEmail(string email)
		{
			var userAccount = await _dbContext.Users.Where(x => x.Email == email).ToListAsync();
			if (userAccount.Count > 0)
			{
				var content = "<h1>Recupera tu contraseña</h1><br>";

				foreach (var user in userAccount)
				{

					var passwordChangeRequest = new ResetLoginPassword()
					{
						Id = Guid.NewGuid(),
						CreationDate = DateTime.Now,
						ExpirationDate = DateTime.Now.AddHours(24),
						UserId = user.Id
					};

					_dbContext.Add(passwordChangeRequest);
					await _dbContext.SaveChangesAsync();

					var request = _accessor.HttpContext.Request;
					var currentBaseURL = $"{request.Scheme}://{request.Host}/resetPassword?id=" + passwordChangeRequest.Id;

					content += $"<table style='border-collapse: collapse;width: 100%;'>" +
						$"<tr>" +
						$"<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>Usuario</th> " +
						$"<th style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>Link</th>" +
						$"</tr>" +
						$"<tr>" +
						$"<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;'>" + user.UserName + "</td>" +
						$"<td style='border: 1px solid #dddddd;text-align: left;padding: 8px;'><a href='" + currentBaseURL + "'>Link de recuperación: " + passwordChangeRequest.Id.ToString() + "</a></td>" +
						$"</tr>" +
						$"</table>";
				}

				var message = new MessageModel(new string[] { userAccount.First().Email }, "Recupera tu contraseña", content);
				_emailSender.SendEmail(message);
			}
		}

		public async Task<bool> ChangePasswordWithRequestLink(Guid requestID, string newPassword)
		{
			var request = _dbContext.ResetLoginPasswords.FirstOrDefault(f => f.Id == requestID);

			if (request != null && request.ExpirationDate > DateTime.Now)
			{
				await UpdateUserPasswordByID(newPassword, request.UserId);

				request.ExpirationDate = DateTime.Now.AddDays(-1);

				await _dbContext.SaveChangesAsync();
				return true;

			}

			return false;

		}

		private async Task UpdateUserPasswordByID(string newPassword, Guid userID)
		{
			var encryptResult = await _encryptCore.RunEncrypt(newPassword);
			var user = _dbContext.Users.FirstOrDefault(f => f.Id == userID);

			user.PasswordHash = encryptResult.EncodeddPassword;
			user.Salt = encryptResult.Salt;
			await _dbContext.SaveChangesAsync();

		}

		public async Task ChangePassword(string currentPassword, string newPassword)
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));
			var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == currentUserID);

			var isValidOldPassword = await _decryptCore.ValidatePassword(user.PasswordHash, user.Salt, currentPassword);

			if (!isValidOldPassword)
				throw new IncorrectPasswordException("Incorrect password");

			await UpdateUserPasswordByID(newPassword, user.Id);

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

		public async Task<bool> ValidateRecoveryRequestID(Guid requestID)
		{
			var result = false;
			var request = await _dbContext.ResetLoginPasswords.FirstOrDefaultAsync(f => f.Id == requestID);
			if (request == null)
			{
				return result;
			}

			if (request.ExpirationDate < DateTime.Now)
			{
				return result;
			}

			result = true;
			return result;
		}

		public async Task<LoginTokenDataModel> LoginAndRetrieveTokenForImpersonate(Guid userID)
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));
			var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == currentUserID);

			if (!user.IsSystemAdmin)
			{
				throw new Exception("User has not priviledges");
			}

			var userToImpersonate = await _dbContext.Users.Include(i => i.PersonalProfiles).FirstOrDefaultAsync(f => f.Id == userID);
			var personalProfile = userToImpersonate.PersonalProfiles.FirstOrDefault();
			var result = new LoginTokenDataModel()
			{
				IsSysAdmin = false,
				UserName = userToImpersonate.UserName,
				LastName = personalProfile.LastName1,
				Name = personalProfile.LastName1,
				Token = GenerateToken(userToImpersonate, personalProfile)
			};
			return result;
		}

		public async Task<StatusPageResponseModel> GetSystemStatus()
		{
			var result = new StatusPageResponseModel
			{
				ConnectionDB = await _dbContext.Users.CountAsync() >= 0,
				ServerDate = DateTime.Now,
			};

			return result;
		}

		public bool GetMaintenancePageFlag()
		{
			var boolMaintenanceFlag = bool.Parse(_configuration["promtMaintenancePage"]);
			return boolMaintenanceFlag;
		}

		public async Task SetMaintenacePage(bool showMaintacePage)
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));
			var user = await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == currentUserID);

			if (!user.IsSystemAdmin)
			{
				throw new Exception("Only sysadmin can perform this action");
			}

			await ModifyServerMaintenanceFile(showMaintacePage);

		}

		public async Task SetMaintenancePageWithKey(MaintenanceKeyInputModel input)
		{
			var base64InputKey = Base64Encode(input.ServerKey);
			var currentServerKey = _configuration["maintenanceActivationKey"];

			if (base64InputKey == currentServerKey)
			{
				await ModifyServerMaintenanceFile(input.ShowMaintacePage);
			}
			else
				throw new Exception("Not valid server key was provided");
		}

		private async Task ModifyServerMaintenanceFile(bool showMaintacePage)
		{
			if (File.Exists("maitenancePageValue.txt"))
				File.Delete("maitenancePageValue.txt");

			await File.AppendAllTextAsync("maitenancePageValue.txt", showMaintacePage.ToString());

		}

		private static string Base64Encode(string plainText)
		{
			var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
			return System.Convert.ToBase64String(plainTextBytes);
		}

		private static string Base64Decode(string base64EncodedData)
		{
			var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
			return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
		}
	}
}
