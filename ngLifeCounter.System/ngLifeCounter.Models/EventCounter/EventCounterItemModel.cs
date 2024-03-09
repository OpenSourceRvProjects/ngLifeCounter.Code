using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.EventCounter
{
	public class EventCounterItemModel
	{
        public Guid Id { get; set; }
        public string EventName { get; set; }
        public string DateString { get; set; }
        public bool IsPublic { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
