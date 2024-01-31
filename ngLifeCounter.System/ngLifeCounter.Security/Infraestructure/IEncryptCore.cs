using ngLifeCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Security.Infraestructure
{
	public interface IEncryptCore
	{
		Task<EncryptResultModel> RunEncrypt(string rawPassword);
	}
}
