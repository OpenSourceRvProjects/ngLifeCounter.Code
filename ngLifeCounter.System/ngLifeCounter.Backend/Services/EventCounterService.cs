using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.Models.EventCounter;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

		public async Task<CounterDataModel> GetCounterData(Guid id)
		{
			var counterDB = await _dbContext.EventCounters.FirstOrDefaultAsync(f=> f.Id == id);
			CounterDataModel counterData = null;

			if (counterDB.IsPublic)
			{
				counterData = GetDataFromDBModel(counterDB);

			}
			else
			{
				var tokenHeader = _accessor.HttpContext.Request.Headers["Authorization"];
				var bearerToken = tokenHeader.FirstOrDefault();


				if (bearerToken == null)
				{
					return counterData;
				}
				var rawToken = bearerToken?.Split("Bearer ")[1];
				var handler = new JwtSecurityTokenHandler();
				var jwtSecurityToken = handler.ReadJwtToken(rawToken);

				var userID = jwtSecurityToken.Claims.Where(W => W.Type == "userID").FirstOrDefault().Value;
				var userIDGuid = Guid.Parse(userID);

				if (userIDGuid == counterDB.UserId)
				{
					counterData = GetDataFromDBModel(counterDB);
				}
			}
			return counterData;

		}

		private static CounterDataModel GetDataFromDBModel(EventCounter counterDB)
		{
			return new CounterDataModel()
			{
				CounterID = counterDB.Id,
				Name = counterDB.EventName,
				Year = (int)counterDB.StartYear,
				Month = counterDB.StartMonth,
				Day = counterDB.StartDay,
				Hour = (int)counterDB.Hour,
				Minutes = (int)counterDB.Minutes,
				IsPublicCounter = counterDB.IsPublic,
			};
		}

		public async Task<List<EventCounterItemModel>> GetCounterList()
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));
			var counters = await _dbContext.EventCounters.Where(w => w.UserId == currentUserID)
				.Select(s => new EventCounterItemModel
				{
					Id = s.Id,
					EventName= s.EventName,
					IsPublic= s.IsPublic,
					DateString = s.StartDay.ToString("00") + "/" 
					+ s.StartMonth.ToString("00") + "/"
					+ s.StartYear,
					CreationDate = s.CreationDate
				}).OrderByDescending(o=> o.CreationDate)
				.ToListAsync();

			return counters;
		}

		public async Task SetPrivacyCounter(Guid counterID, CounterPrivacySetModel setting)
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));

			var counter = await _dbContext.EventCounters.FirstOrDefaultAsync(f => f.UserId == currentUserID && f.Id == counterID);

			if(counter == null)
			{
				throw new Exception("Counter does not exist!");
			}

			counter.IsPublic = setting.IsPublicCounter;
			await _dbContext.SaveChangesAsync();
		}
	}
}
