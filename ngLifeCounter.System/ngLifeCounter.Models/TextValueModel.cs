using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ngLifeCounter.Models
{
	public class TextValueModel
	{
        public TextValueModel(object value, string text)
        {
            this.Text = text;
            this.Value = value;
        }
        public string Text { get; set; }
        public object Value { get; set; }
    }
}
