using Microsoft.AspNetCore.Mvc;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Backend.Services;
using ngLifeCounter.EmailSender;
using ngLifeCounter.Models.Email;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ngLifeCounter.MVC.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmailerController : ControllerBase
	{
		private readonly IEmailSender _emailSender;
		public EmailerController(IEmailSender emailSender)
		{
			_emailSender = emailSender;
		}
		// GET: api/<EmailerController>
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var content = "<h5 style='color:red'>Hello there!</h5>";
			var message = new MessageModel(new string[] { "rolando.vr92@gmail.com" }, "Test email", content);
			_emailSender.SendEmail(message);
			return Ok();

		}

	}
}
