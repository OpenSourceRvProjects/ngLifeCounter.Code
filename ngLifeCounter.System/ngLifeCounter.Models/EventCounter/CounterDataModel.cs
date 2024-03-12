using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.EventCounter
{
	public class CounterDataModel
	{
        public string Name { get; set; }
        public Guid CounterID { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }  
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minutes { get; set; }
		public bool IsPublicCounter { get; set; }
	}
}
