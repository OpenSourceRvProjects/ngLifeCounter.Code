﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Models.EventCounter;
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
		private IEventCounterService _eventService;

		public EventCounterController(IHttpContextAccessor accessor, IEventCounterService eventService)
		{
			_accessor = accessor;
			_eventService = eventService;
		}
		// GET: api/<EventCounterController>
		[HttpGet]
		[LoggedUserDataFilter]
		public async Task<ActionResult> Get()
		{
			var eventList = await _eventService.GetCounterList();
			return Ok(eventList);
		}

		// GET api/<EventCounterController>/5
		[HttpGet]
		[AllowAnonymous]
		[Route("getById")]
		public async Task<IActionResult> Get(Guid counterID)
		{
			var counterData = await _eventService.GetCounterData(counterID);
			if (counterData == null)
			{
				return Unauthorized();
			}
			return Ok(counterData);
		}

		// POST api/<EventCounterController>
		[HttpPost]
		[LoggedUserDataFilter]
		public async Task<IActionResult> Post([FromBody] NewEventCounterModel newEvent)
		{
			await _eventService.AddEventCounter(newEvent);
			return Ok();
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