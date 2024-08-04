using ngLifeCounter.Models;
using ngLifeCounter.Models.Relapses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Backend.Infrastructure
{
	public interface IRelapseService
	{
		Task <RelapsesDataModel> GetEventRelapses(Guid counterEventID);
		List<TextValueModel> GetRelapseReasons();
	}
}
