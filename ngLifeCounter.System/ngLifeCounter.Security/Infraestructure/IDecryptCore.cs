using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Security.Infraestructure
{
	public interface IDecryptCore
	{
		Task<bool> ValidatePassword(string hashedPassword, string salt, string rawPassword);
	}
}
