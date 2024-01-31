using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models
{
	public class EncryptResultModel
	{
		public bool IsError { get; set; } = false;
		public string ErrorMessage { get; set; }
        public string EncodeddPassword { get; set; }
		public string Salt { get; set; }
	}
}
