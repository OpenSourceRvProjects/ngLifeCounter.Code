using Microsoft.AspNetCore.Http;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.Models.EventCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Backend.Services
{
	public class EventCounterService : IEventCounterService
	{

		private IHttpContextAccessor _accessor;
		private NgLifeCounterDbContext _dbContext;
		public EventCounterService(IHttpContextAccessor accessor, NgLifeCounterDbContext dbContext)
		{
			_accessor = accessor;
			_dbContext = dbContext;

		}

		public async Task AddEventCounter(NewEventCounterModel eventCounter)
		{

			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));
			var personalProfileID = _dbContext.PersonalProfiles.FirstOrDefault(f => f.UserId == currentUserID).Id;

			try
			{
				var dateTimeEvent = new DateTime(eventCounter.Year, eventCounter.Month, eventCounter.Day, eventCounter.Hour, eventCounter.Minutes, 0);
			}
			catch (Exception ex)
			{
				throw new Exception("Date is not valid");
			}

			try
			{
				var newEventCounterDB = new EventCounter()
				{
					Id = Guid.NewGuid(),
					CreationDate = DateTime.Now,
					CustomEventImageCollection = eventCounter.ImageCollection,
					CustomMessage = eventCounter.CustomMessage,
					EventName = eventCounter.EventName,
					StartYear = eventCounter.Year,
					StartMonth = eventCounter.Month,
					StartDay = eventCounter.Day,
					Hour = eventCounter.Hour,
					Minutes = eventCounter.Minutes,
					IsPublic = eventCounter.IsPublic,
					UserId = currentUserID,
					PersonalProfileId = personalProfileID,
					Status = true
				};
				
				await _dbContext.AddAsync(newEventCounterDB);
				await _dbContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception("DB error: " + ex.Message);
			}
		}
	}
}
