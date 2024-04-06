using Microsoft.EntityFrameworkCore;
using ngLifeCounter.Backend.Services;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.Models.Account;
using ngLifeCounter.Security.Core;
using System.Text.Json;

namespace ngLifeCounter.Tests.Stress
{
	[TestClass]
	public class UnitTest1
	{
		private NgLifeCounterDbContext _dbContext;
		[TestInitialize]
		public void SetContexts()
		{
			var connectionStrings = "workstation id=dev-NgLifeCounterDB.mssql.somee.com;packet size=4096;user id=dev-nglifecount_SQLLogin_1;pwd=nxicab5sa6;data source=dev-NgLifeCounterDB.mssql.somee.com;persist security info=False;initial catalog=dev-NgLifeCounterDB;Encrypt=False";
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

			var baseUser = _dbContext.Users.Include(i => i.PersonalProfiles).FirstOrDefault();
			var userQty = 100;

			for (int currentUser = 0; currentUser < userQty; currentUser++)
			{
				var user = new User()
				{
					Id = Guid.NewGuid(),
					AllowSysAdminAccess = true,
					CreationDate = DateTime.Now,
					Email = "test@mail.com",
					Salt = baseUser.Salt,
					PasswordHash = baseUser.PasswordHash,
					UserName = "rolando_" + (_dbContext.Users.Count()),

				};

				_dbContext.Add(user);

				var personalProfile = new PersonalProfile()
				{
					Address = "False street #123, Springfield, California, United States of America",
					CreationDate = DateTime.Now,
					LastName1 = "GenericLastName1",
					LastName2 = "GenericLastName2",
					Id = Guid.NewGuid(),
					Name = "GenericName1",
					Pohone = "812488583812",
					UserId = user.Id,
					DefaultPetPhotos = baseUser.PersonalProfiles.First().DefaultPetPhotos,
					
					/*currentUser % 2 != 0 ? "" :*/
					//Guid.NewGuid().ToString()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
					//+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()


				};

				_dbContext.Add(personalProfile);

			var anonimizedRequest = new RegisterModel()
			{
				Email = user.Email + Guid.NewGuid(),
				LastName1 = personalProfile.LastName1,
				LastName2 = personalProfile.LastName2,
				Name = personalProfile.Name,
				Password = "******************"
			};

			var requestAccount = new SignUpRequest()
			{
				CreationDate = DateTime.Now,
				RequestObject = JsonSerializer.Serialize(anonimizedRequest),
				Id = Guid.NewGuid(),
				Ip = "192.168.0.112",
				UserId = user.Id

			};

			_dbContext.Add(requestAccount);

			for (int login = 0; login < 200; login++)
			{
				var newLogin = new CorrectLogin()
				{
					Id = Guid.NewGuid(),
					IpAddress = "192.168.0.112",
					LoginDate = DateTime.Now,
					UserId = user.Id
				};
				_dbContext.Add(newLogin);
			}

			_dbContext.SaveChanges();
			Random r = new Random();
			for (var i = 0; i < 150; i++)
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
					CustomEventImageCollection = i % 2 != 0 ? "" : Guid.NewGuid().ToString()
				};
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//	+ Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid() + Guid.NewGuid()
				//};
				_dbContext.Add(eventCounter);


				if (i >= 25)
					for (var j = 0; j < 3; j++)
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
}