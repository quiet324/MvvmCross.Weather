// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

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
		UIKit.UILabel TemperatureLabel { get; set; }

		[Action ("ImageClick:")]
		partial void ImageClick (Foundation.NSObject sender);

		[Action ("RefreshWeaterClick:")]
		partial void RefreshWeaterClick (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (CityNameLabel != null) {
				CityNameLabel.Dispose ();
				CityNameLabel = null;
			}

			if (TemperatureLabel != null) {
				TemperatureLabel.Dispose ();
				TemperatureLabel = null;
			}

			if (HumidityLabel != null) {
				HumidityLabel.Dispose ();
				HumidityLabel = null;
			}
		}
	}
}
