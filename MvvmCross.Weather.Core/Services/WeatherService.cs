using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using MvvmCross.Weather.Core.Services.Messages;
using RestSharp.Portable;
using System.Diagnostics;

namespace MvvmCross.Weather.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IMvxMessenger messenger;

        private const string OpenWeatherMapApiKey = "543a21df6d2a7ea192863693bc74e645";

        private const string OpenWeatherMapUrl = "http://api.openweathermap.org/data/2.5/";

        private const string OpenWeatherIconUrl = "http://openweathermap.org/img/w/{0}.png";

        private const string WeatherEndPoint = "weather";

        public WeatherService(IMvxMessenger messenger)
        {
            this.messenger = messenger;
        }

        public async Task GetCurrentWeatherAsync(double lon, double lat)
        {
            var client = new RestClient(OpenWeatherMapUrl);
            var request = new RestRequest(WeatherEndPoint, HttpMethod.Get);
            request.AddParameter("lon", lon);
            request.AddParameter("lat", lat);
            request.AddParameter("units", "metric");
            request.AddParameter("APPID", OpenWeatherMapApiKey);

			var result = await client.Execute<WeatherResponse>(request);

			string name = result.Data.Name;
			string temp = result.Data.Main.Temp.ToString("0.00") + "°C";
			string humidity = result.Data.Main.Humidity.ToString() + "%";
			string iconUrl = string.Format(OpenWeatherIconUrl, result.Data.Weather[0].Icon);

            this.messenger.Publish(new WeatherMessage(this,
                name,
                temp,
                humidity,
                iconUrl));
        }

		private class WeatherResponse : RestResponse
		{
			public WeatherResponse (IRestClient client, IRestRequest request) : base(client, request)
			{
			}

			public string Name { get; set;}
			public MainResponse Main { get; set;}
			public List<WeatherEntry> Weather { get; set;}
		}

		private class MainResponse
		{
			public float Temp { get; set;}
			public float Humidity { get; set;}
		}

		private class WeatherEntry
		{
			public string Icon { get; set;}
		}
    }
}
