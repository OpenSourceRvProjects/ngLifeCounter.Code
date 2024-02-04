using ngLifeCounter.Backend.Infrastructure;
using ngLifeCounter.Backend.Services;
using ngLifeCounter.Security.Core;
using ngLifeCounter.Security.Infraestructure;

namespace ngLifeCounter.MVC
{
	public static class ServiceInjector
	{

		public static void InjectServices(this IServiceCollection services)
		{
			services.AddTransient<IAccountUserService, AccountUserService>();
			services.AddTransient<IEncryptCore, EncryptCore>();
			services.AddTransient<IDecryptCore, DecryptCore>();
			services.AddTransient<ITokenCore, TokenCore>();
		}

	}
}
