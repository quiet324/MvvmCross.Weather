using System;
using System.Drawing;

using Foundation;
using UIKit;
using MvvmCross.Weather.iOS.Views;
using MvvmCross.Weather.Core.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;
using System.Collections.Generic;

namespace MvvmCross.Weather.iOS
{
	public partial class MainViewController : BaseView
	{
		public new MainViewModel ViewModel
		{
			get { return (MainViewModel) base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public MainViewController (IntPtr handle) : base(handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			MvxImageViewLoader imageViewLoader = new MvxImageViewLoader (() => this.WeatherIconImageView);

			var bindingSet = this.CreateBindingSet<MainViewController, MainViewModel> ();

			bindingSet.Bind (CityNameLabel).To ((vm) => vm.CityName);
			bindingSet.Bind (HumidityLabel).To ((vm) => vm.Humidity);
			bindingSet.Bind (TemperatureLabel).To ((vm) => vm.Temperature);

			bindingSet.Apply ();

			this.AddBindings(new Dictionary<object,string>()
			{
				{imageViewLoader, "ImageUrl WeatherIconUrl"},
				{this.RefreshWeatherButton, "TouchUpInside RefreshWeatherCommand; Enabled IsWeatherExecutable"}
			});
		}
	}
}

