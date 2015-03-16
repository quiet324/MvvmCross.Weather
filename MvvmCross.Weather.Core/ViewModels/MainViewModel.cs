// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the MainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Net.Http;
using Cirrious.MvvmCross.Plugins.Messenger;
using MvvmCross.Weather.Core.Interfaces;
using MvvmCross.Weather.Core.Services;
using MvvmCross.Weather.Core.Services.Messages;

namespace MvvmCross.Weather.Core.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Cirrious.MvvmCross.ViewModels;

    /// <summary>
    /// Define the MainViewModel type.
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        private readonly MvxSubscriptionToken locationMessageToken;

        private readonly MvxSubscriptionToken weatherMessageToken;

        private readonly ILocationService locationService;

        private readonly IWeatherService weatherService;

        private readonly IDialogService dialogService;


        private double lng = 0;

        private double lat = 0;

        private MvxCommand refreshWeatherCommand;

        public ICommand RefreshWeatherCommand
        {
            get
            {
                return this.refreshWeatherCommand ??
                    (this.refreshWeatherCommand = new MvxCommand(async () => await this.GetWeatherInfoAsync()));
            }
        }

        private MvxCommand showDetailCommand;

        public ICommand ShowDetailCommand
        {
            get
            {
                return this.showDetailCommand ??
                    (this.showDetailCommand = new MvxCommand(this.ShowDetailView));
            }
        }

        private bool isWeatherExecutable = false;

        public bool IsWeatherExecutable
        {
            get { return this.isWeatherExecutable; }
            set { this.SetProperty(ref this.isWeatherExecutable, value, () => this.IsWeatherExecutable); }
        }

        private string currentPositionAsString;

        public string CurrentPositionAsString
        {
            get { return this.currentPositionAsString; }
            set { this.SetProperty(ref this.currentPositionAsString, value, () => this.CurrentPositionAsString); }
        }

        private string cityName = "Refresh!";

        public string CityName
        {
            get { return this.cityName; }
            set { this.SetProperty(ref this.cityName, value, () => this.CityName); }
        }

        private string temperature = "-100°C";

        public string Temperature
        {
            get { return this.temperature; }
            set { this.SetProperty(ref this.temperature, value, () => this.Temperature); }
        }

        private string humidity = "110%";

        public string Humidity
        {
            get { return this.humidity; }
            set { this.SetProperty(ref this.humidity, value, () => this.Humidity); }
        }

        private string weatherIconUrl =
            "http://files.softicons.com/download/web-icons/android-weather-icons-by-bharath-prabhuswamy/png/256x256/Slight%20Drizzle.png";

        public string WeatherIconUrl
        {
            get { return this.weatherIconUrl; }
            set { this.SetProperty(ref this.weatherIconUrl, value, () => this.WeatherIconUrl); }
        }

        public MainViewModel(IMvxMessenger messenger,
            ILocationService locationService,
            IWeatherService weatherService,
            IDialogService dialogService)
        {
            this.locationMessageToken = messenger.Subscribe<LocationMessage>(this.OnLocationMessage);
            this.weatherMessageToken = messenger.Subscribe<WeatherMessage>(this.OnWeatherMessage);

            this.locationService = locationService;
            this.weatherService = weatherService;
            this.dialogService = dialogService;

            this.locationService.StartLocationUpdates();
        }

        private void ShowDetailView()
        {
            this.ShowViewModel<DetailViewModel>();
        }

        public async Task GetWeatherInfoAsync()
        {
            this.IsWeatherExecutable = false;
            try
            {
                await this.weatherService.GetCurrentWeatherAsync(lng, lat);
            }
            catch (HttpRequestException ex)
            {
                this.dialogService.ShowError("The OpenWeatherMapAPI is sometimes a bit problematic...");
            }
            finally
            {
                this.IsWeatherExecutable = true;
            }
        }

        private void OnLocationMessage(LocationMessage locationMessage)
        {
            this.CurrentPositionAsString = locationMessage.Lng + " : " + locationMessage.Lat;

            this.lng = locationMessage.Lng;
            this.lat = locationMessage.Lat;

            // enable GetWeatherInfoAsync Command
            this.IsWeatherExecutable = true;
        }

        private void OnWeatherMessage(WeatherMessage weatherMessage)
        {
            this.CityName = weatherMessage.CityName;
            this.Temperature = weatherMessage.Temperature;
            this.Humidity = weatherMessage.Humidity;
            this.WeatherIconUrl = weatherMessage.WeatherIconUrl;
        }
    }
}
