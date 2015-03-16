using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.Weather.Core.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private List<WeatherItem> weatherItems;

        public List<WeatherItem> WeatherItems
        {
            get { return this.weatherItems; }
            set { this.SetProperty(ref this.weatherItems, value, () => this.WeatherItems); }
        }

        public DetailViewModel()
        {
            this.WeatherItems = new List<WeatherItem> { new WeatherItem("Testical"), new WeatherItem("Testical2"), new WeatherItem("Testical3") };
        }
    }
}
