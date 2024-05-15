using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.Models.Relapses;

namespace ngLifeCounter.Backend.Services
{
	public class RelapseService : IRelapseService
	{
		private IHttpContextAccessor _accessor;
		private NgLifeCounterDbContext _dbContext;
		public RelapseService(IHttpContextAccessor accessor, NgLifeCounterDbContext dbContext)
		{
			_accessor = accessor;
			_dbContext = dbContext;

		}
		public async Task<RelapsesDataModel> GetEventRelapses(Guid counterEventID)
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));

			var relapseData =  new RelapsesDataModel();

			var relapsesList = await _dbContext.Relapses.Where(w=> w.UserId == currentUserID && w.EventCounterId ==  counterEventID)
				.Select(s=>  new RelapseDetailModel()
				{
					Id = s.Id,
					EventCounterID = s.EventCounterId,
					EventName = s.EventCounter.EventName,
					DateString = s.RelapseYear +  "/" + s.RelapseMonth + "/" + s.RelapseDay,
				})
				.ToListAsync();

			relapseData.Items = relapsesList;
			
			var eventCounter = _dbContext.EventCounters.First(f=> f.Id == counterEventID);

			var date = new DateTime((int)eventCounter.StartYear, eventCounter.StartMonth, eventCounter.StartDay);
			var now = DateTime.UtcNow;

			var nzTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time (Mexico)");
			DateTime nzDateTime = TimeZoneInfo.ConvertTime(now, TimeZoneInfo.Utc, nzTimeZone);

			var diffDays = (nzDateTime - date).Days;

			if (diffDays < 365)
			{
				relapseData.TimeUnit = "días";
				relapseData.TimeQuantitySinceLastIssue = diffDays;
			}
            else
            {
				var timeSpan = nzDateTime - date;
				int age = new DateTime(timeSpan.Ticks).Year - 1;
				relapseData.TimeQuantitySinceLastIssue = age;
				relapseData.TimeUnit = age == 1 ? "año" : "años";

			}

			return relapseData; 
		}
	}
}
