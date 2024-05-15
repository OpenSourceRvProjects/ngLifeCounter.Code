using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.MVC.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ngLifeCounter.MVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AdminController : ControllerBase
	{
		// GET: api/<AdminController>
		private IAccountUserService _accountService;
        public AdminController(IAccountUserService accountService)
        {
			_accountService = accountService;
        }

        [HttpGet]
		[LoggedUserDataFilter]
		[Route("getAllUsers")]
		public async Task<IActionResult> Get()
		{
			var users = await _accountService.GetAllUsersAsync();
			return Ok(users);
		}
		
	}
}
