using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace MvvmCross.Weather.Core.Services.Messages
{
    public class WeatherMessage : MvxMessage
    {
        public string CityName { get; private set; }
        public string Temperature { get; private set; }
        public string Humidity { get; private set; }
        public string WeatherIconUrl { get; private set; }

        public WeatherMessage(object sender, string cityName, string temperature, string humidity, string weatherIconUrl)
            :base(sender)
        {
            this.CityName = cityName;
            this.Temperature = temperature;
            this.Humidity = humidity;
            this.WeatherIconUrl = weatherIconUrl;
        }
    }
}
