using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ngLifeCounter.MVC.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ngLifeCounter.MVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class EventCounterController : ControllerBase
	{

		private IHttpContextAccessor _accessor;

        public EventCounterController(IHttpContextAccessor accessor)
        {
				_accessor = accessor;
        }
        // GET: api/<EventCounterController>
        [HttpGet]
		[LoggedUserDataFilter]
		public async Task<ActionResult> Get()
		{

			var userID = _accessor.HttpContext.Session.GetString("userID");
			return Ok(new string[] { "value1", "value2" });
		}

		// GET api/<EventCounterController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{

			return "value";
		}

		// POST api/<EventCounterController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<EventCounterController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EventCounterController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
