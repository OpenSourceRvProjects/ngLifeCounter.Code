using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.Relapses
{
	public class RelapseDetailModel
	{
        public string EventName { get; set; }
        public Guid Id { get; set; }
        public Guid EventCounterID { get; set; }
        public string DateString { get; set; }
    }

    public class RelapsesDataModel
    {
        public RelapsesDataModel()
        {
             this.Items = new List<RelapseDetailModel>();   
        }

        public List<RelapseDetailModel> Items { get; set; }
        public string TimeUnit { get; set; }
        public decimal TimeQuantitySinceLastIssue { get; set; }
    }
}
