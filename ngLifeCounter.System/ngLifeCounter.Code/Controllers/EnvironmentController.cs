using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ngLifeCounter.MVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EnvironmentController : ControllerBase
	{
		private readonly IWebHostEnvironment _hostingEnv;
		public EnvironmentController(IWebHostEnvironment hostingEnvironment)
        {
			_hostingEnv = hostingEnvironment;
		}

        [HttpGet]
		public IActionResult Get()
		{
			return Ok(new { _hostingEnv.EnvironmentName });
		}

	}
}
