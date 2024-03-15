using ngLifeCounter.Models.EventCounter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Backend.Infrastructure
{
	public interface IEventCounterService
	{
		Task AddEventCounter(NewEventCounterModel eventCounter);
		Task <List<EventCounterItemModel>> GetCounterList();
		Task<CounterDataModel> GetCounterData(Guid id);
		Task SetPrivacyCounter(Guid counterID, CounterPrivacySetModel setting);
		Task UpdateEventCounter(Guid counterID, CounterDataModel counter, bool isRelapse = false);
	}
}
