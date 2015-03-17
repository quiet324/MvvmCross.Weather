using System;
using System.Drawing;

using Foundation;
using UIKit;
using MvvmCross.Weather.iOS.Views;
using MvvmCross.Weather.Core.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace MvvmCross.Weather.iOS
{
	public partial class MainViewController : BaseView
	{
		public new MainViewModel ViewModel
		{
			get { return (MainViewModel) base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public MainViewController () : base ("MainViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.CreateBinding(CityNameLabel).To((MainViewModel vm) => vm.CityName).Apply();
		}
	}
}

