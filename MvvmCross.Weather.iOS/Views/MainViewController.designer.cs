// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MvvmCross.Weather.iOS
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UILabel CityNameLabel { get; set; }

		[Outlet]
		UIKit.UILabel HumidityLabel { get; set; }

		[Outlet]
		UIKit.UITapGestureRecognizer ImageClickTapRecognizer { get; set; }

		[Outlet]
		UIKit.UIButton RefreshWeatherButton { get; set; }

		[Outlet]
		UIKit.UILabel TemperatureLabel { get; set; }

		[Outlet]
		UIKit.UIImageView WeatherIconImageView { get; set; }

		void ReleaseDesignerOutlets ()
		{
		}
	}
}
