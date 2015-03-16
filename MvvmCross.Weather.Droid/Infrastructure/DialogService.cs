using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidHUD;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using MvvmCross.Weather.Core.Interfaces;

namespace MvvmCross.Weather.Droid.Infrastructure
{
    public class DialogService : IDialogService
    {
        public void ShowError(string text)
        {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            AndHUD.Shared.ShowError(topActivity.Activity, text, timeout: TimeSpan.FromSeconds(3));
        }
    }
}