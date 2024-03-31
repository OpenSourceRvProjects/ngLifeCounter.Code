using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models.Images
{
	public class ImageListModel
	{
        public ImageListModel()
        {
            this.Images = new List<string>();
        }
        public List<string> Images { get; set; }
    }
}
