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

		// GET api/<AdminController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<AdminController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<AdminController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<AdminController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
