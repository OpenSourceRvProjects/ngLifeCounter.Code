using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Data.DataAccess;
using ngLifeCounter.Models.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ngLifeCounter.Backend.Services
{
	public class ProfileService : IProfileService
	{

		private IHttpContextAccessor _accessor;
		private NgLifeCounterDbContext _dbContext;
		public ProfileService(IHttpContextAccessor accessor, NgLifeCounterDbContext dbContext)
		{
			_accessor = accessor;
			_dbContext = dbContext;

		}

		public async Task<ImageListModel> GetProfileImages()
		{
			var profile = await GetUserProfile();
			if (profile.DefaultPetPhotos == null)
				return new ImageListModel();

			return JsonSerializer.Deserialize<ImageListModel>(profile.DefaultPetPhotos);
		}

		public async Task SaveProfileImages(ImageListModel images)
		{
			var profile = await GetUserProfile();
			profile.DefaultPetPhotos = JsonSerializer.Serialize(images);
			await _dbContext.SaveChangesAsync();
		}

		private async Task<PersonalProfile> GetUserProfile()
		{
			var currentUserID = Guid.Parse(_accessor.HttpContext.Session.GetString("userID"));
			var userProfile = await _dbContext.Users.Include(i => i.PersonalProfiles).FirstOrDefaultAsync(f => f.Id == currentUserID);
			var profile = userProfile.PersonalProfiles.FirstOrDefault();

			return profile;
		}
	}
}
