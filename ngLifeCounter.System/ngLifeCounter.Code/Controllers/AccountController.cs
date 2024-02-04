using Microsoft.AspNetCore.Mvc;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Models.Account;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ngLifeCounter.MVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{

		private IAccountUserService _accountService;

        public AccountController(IAccountUserService accountService)
        {
				_accountService = accountService;
        }

        // GET: api/<AccountController>
        [HttpGet]
		[Route("account/login")]
		public async Task<IActionResult> Get(string userName, string password)
		{
			var token = await _accountService.LoginAndRetrieveToken(userName, password);
			return Ok(new {token = token});
		}

		// GET api/<AccountController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<AccountController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] RegisterModel newRegister)
		{
			var result = await _accountService.RegisterUserAccount(newRegister);
			return Ok(result);
		}

		// PUT api/<AccountController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<AccountController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
