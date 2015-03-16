using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.Weather.Core
{
    public class WeatherItem
    {
        public string Name { get; set; }

        public WeatherItem(string text)
        {
            this.Name = text;
        }
    }
}
