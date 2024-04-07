using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.Account
{
	public class UsersModel
	{
		public string NickName { get; set; }
		public int LoginCount { get; set; }
		public Guid UserID { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public int CounterEventsCount { get; set; }
		public int RelapsesCount { get; set; }
	}
}
