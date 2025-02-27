﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Models.Account;
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

		[HttpGet]
		[LoggedUserDataFilter]
		[Route("setMaintenancePage")]
		public async Task<IActionResult> setMaintenancePage(bool showMaintenancePage)
		{
			try
			{
				await _accountService.SetMaintenacePage(showMaintenancePage);
				return Ok();
			}
			catch (Exception ex) {
				return StatusCode(500, new { errorMsg = ex.Message});
			}
		}


		[HttpPost]
		[Route("turnMaintenancePageWithKey")]
		[AllowAnonymous]
		public async Task<IActionResult> TurnMaintenancePageWithKey([FromBody] MaintenanceKeyInputModel input)
		{
			try
			{
				await _accountService.SetMaintenancePageWithKey(input);
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, new { errorMsg = ex.Message });
			}
		}

	}
}
