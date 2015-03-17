using System;
using MvvmCross.Weather.Core.Interfaces;
using UIKit;

namespace MvvmCross.Weather.iOS
{
	public class DialogService : IDialogService
	{
		#region IDialogService implementation

		public void ShowError (string text)
		{
			new UIAlertView (text, "", null, "OK").Show();
		}

		#endregion
	}
}

