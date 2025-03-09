using Moq;
using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Backend.Services;
using ngLifeCounter.Models.Profile;
using ngLifeCounter.MVC.Controllers;

namespace ngLifeCounter.UnitTests
{
	[TestClass]
	public class UnitTest1
	{


		Mock<IProfileService> _profileServiceMock;
		private ProfileController profileController;


		[TestMethod]
		public void TestMethod1()
		{
			_profileServiceMock = new Mock<IProfileService>();
			this.profileController =  new ProfileController(this._profileServiceMock.Object);
			_profileServiceMock.Setup(s => s.GetProfileData()).ReturnsAsync(new ProfileDataModel() { Email = "test@test.com" });
		    var result = this.profileController.GetProfileData().GetAwaiter().GetResult();

		}
	}
}