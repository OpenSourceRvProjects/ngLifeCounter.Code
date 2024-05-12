using ngLifeCounter.Models.Images;
using ngLifeCounter.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Backend.Infrastructure
{
	public interface IProfileService
	{
		Task SaveProfileImages(ImageListModel images);
		Task<ImageListModel> GetProfileImages();
		Task<ProfileDataModel> GetProfileData();
	}
}
