using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.EventCounter
{
	public class CounterResultsModel
	{
		public long EventsCount { get; set; }
		public long RelapsesCount { get; set; }
		public long TotalUserEventsCount { get; set; }
		public long TotalUserRelapsesCount { get; set; }
		public long AvailableEvents
		{
			get
			{
				return this.TotalUserEventsCount - this.EventsCount;
			}
		}
		public long AvailableRelapses
		{
			get
			{
				return this.TotalUserRelapsesCount - this.RelapsesCount;
			}
		}
	}
}
