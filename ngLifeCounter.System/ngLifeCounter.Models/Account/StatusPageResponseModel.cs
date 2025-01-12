using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.Account
{
	public class StatusPageResponseModel
	{
		public bool ConnectionDB { get; set; }
		public DateTime ServerDate { get; set; }
		public string Environment { get; set; }
	}
}
