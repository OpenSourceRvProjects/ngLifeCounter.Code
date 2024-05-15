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
	[LoggedUserDataFilter]

	public class RelapsesController : ControllerBase
	{
		private readonly IRelapseService _relapseService;
        public RelapsesController(IRelapseService relapseService)
        {
			_relapseService = relapseService;
        }
        // GET api/<RelapsesController>/5
        [HttpGet]
		[Route("getEventCounterRelapses")]
		public async Task<IActionResult> Get(Guid eventCounterId)
		{
			var relapses = await _relapseService.GetEventRelapses(eventCounterId);
			return Ok(relapses);
		}

	}
}
