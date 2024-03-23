using Microsoft.EntityFrameworkCore;
using ngLifeCounter.Backend.Services;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.Security.Core;

namespace ngLifeCounter.Tests.Stress
{
	[TestClass]
	public class UnitTest1
	{
		private NgLifeCounterDbContext _dbContext;
		[TestInitialize]
		public void SetContexts()
		{
			var connectionStrings  = "Server=db2558.public.databaseasp.net; Database=db2558; User Id=db2558; Password=F+x8-y4HM9%s; Encrypt=False; MultipleActiveResultSets=True;";
			_dbContext = CreateDBContext(connectionStrings);
		}

		private NgLifeCounterDbContext CreateDBContext(string connectionString)
		{
			var context = new NgLifeCounterDbContext(connectionString);

			context.Database.EnsureCreated();
			return context;
		}

		[TestMethod]
		public void TestMethod1()
		{
		
			var user = _dbContext.Users.Include(i=> i.PersonalProfiles).FirstOrDefault();
			Random r = new Random();
			for (var i = 0; i < 200; i++)
			{
				var eventCounter = new EventCounter()
				{
					UserId = user.Id,
					PersonalProfileId = user.PersonalProfiles.First().Id,
					CreationDate = DateTime.Now,
					EventName = "Test  " + Guid.NewGuid(),
					StartDay = r.Next(1, 28),
					StartMonth = r.Next(1, 12),
					StartYear = r.Next(1990, 2030),
					Hour = r.Next(2, 23),
					Minutes = 0,
					Id = Guid.NewGuid(),
					IsPublic = false,
					Status = true,
					CustomMessage = "Custom msg: " + Guid.NewGuid().ToString(),
				};
				_dbContext.Add(eventCounter);

				for (var j = 0; j < 10;  j++)
				{
					var relapse = new Relapse()
					{
						Id = Guid.NewGuid(),
						CreationDate = DateTime.Now,
						EventCounterId = eventCounter.Id,
						PersonalProfileId = user.PersonalProfiles.First().Id,
						UserId = user.Id,
						PreviousDay = r.Next(1, 28),
						PreviousMonth = r.Next(1, 12),
						PreviousHour = r.Next(2, 12),
						PreviousMinutes = 0,
						RelapseDay = r.Next(1, 28),
						RelapseMonth = r.Next(1, 12),
						RelapseYear = r.Next(1990, 2030),
						RelapseHour = r.Next(2, 23),
						RelapseMinute = r.Next(1, 50),
						PreviousYear = r.Next(1990, 2030)
					};
					_dbContext.Add(relapse);
				}

				_dbContext.SaveChanges();
			}

		}
	}
}