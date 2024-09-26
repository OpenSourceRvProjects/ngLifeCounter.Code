using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Models.Account;
using ngLifeCounter.MVC.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ngLifeCounter.MVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private IHttpContextAccessor _accessor;
		private IAccountUserService _accountService;

		private readonly IWebHostEnvironment _hostingEnv;

		public AccountController(IAccountUserService accountService, IWebHostEnvironment hostingEnvironment)
		{
			_accountService = accountService;
			_hostingEnv = hostingEnvironment;

		}

		[HttpGet]
		[Route("validateRecoveryRequestID")]
		public async Task<ActionResult> ResetPassword(Guid requestID)
		{
			var isValidID = await _accountService.ValidateRecoveryRequestID(requestID);
			return Ok(isValidID);
		}


		[HttpGet]
		[Route("resetPassword")]
		public async Task<ActionResult> ResetPassword(string email)
		{
			try
			{
				await _accountService.SendPasswordResetEmail(email);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("changePasswordWithURL")]
		public async Task<ActionResult> ChangePasswordURL(Guid id, string password)
		{
			var result = await _accountService.ChangePasswordWithRequestLink(id, password);
			return Ok(result);
		}

		// GET: api/<AccountController>
		[HttpGet]
		[Route("loginURL")]
		public async Task<IActionResult> Get(string userName, string password)
		{
			var token = await _accountService.LoginAndRetrieveToken(userName, password);
			return Ok(token);
		}

		[HttpGet]
		[Route("getSystemStatus")]
		public async Task<IActionResult> GetSystemStatus()
		{
			try
			{
				var response = await _accountService.GetSystemStatus();
				response.Environment = _hostingEnv.EnvironmentName;
				return Ok(response);
			}
			catch (Exception ex) {
				return StatusCode(500, "Error getting health");
			}
		}


		[HttpGet]
		[Route("getSystemStatusFailedAssert")]
		public async Task<IActionResult> GetSystemStatusFailedAssert()
		{
			try
			{
				throw new Exception("Error");
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Error getting health: " + ex.Message);
			}
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> GetToken([FromBody] LoginModel loginModel)
		{
			var token = await _accountService.LoginAndRetrieveToken(loginModel.UserName, loginModel.Password);
			return Ok(token);
		}


		[HttpPost]
		[Route("changePassword")]
		[LoggedUserDataFilter]
		[ExceptionManager]
		[Authorize]
		public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
		{
			await _accountService.ChangePassword(changePasswordModel.OldPassword, changePasswordModel.NewPassword);
			return Ok();
		}

		[HttpGet]
		[Route("impersonate")]
		[LoggedUserDataFilter]
		public async Task<IActionResult> Impersonate(Guid userID)
		{
			var token = await _accountService.LoginAndRetrieveTokenForImpersonate(userID);
			return Ok(token);
		}

		// POST api/<AccountController>
		[HttpPost]
		[Route("signUp")]
		public async Task<IActionResult> Post([FromBody] RegisterModel newRegister)
		{
			try
			{
				var result = await _accountService.RegisterUserAccount(newRegister);
				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


	}
}
