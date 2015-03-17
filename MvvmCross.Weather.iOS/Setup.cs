// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the Setup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using Cirrious.CrossCore;
using MvvmCross.Weather.Core.Interfaces;
using Cirrious.MvvmCross.Touch.Views;
using UIKit;


namespace MvvmCross.Weather.iOS
{
    using Cirrious.MvvmCross.Touch.Platform;
    using Cirrious.MvvmCross.Touch.Views.Presenters;
    using Cirrious.MvvmCross.ViewModels;

    /// <summary>
    ///    Defines the Setup type.
    /// </summary>
    public class Setup : MvxTouchSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="applicationDelegate">The application delegate.</param>
        /// <param name="presenter">The presenter.</param>
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

		protected override void InitializeFirstChance ()
		{
			base.InitializeFirstChance ();

			Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
		}

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of IMvxApplication</returns>
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

		protected override IMvxTouchViewsContainer CreateTouchViewsContainer ()
		{
			return new CustomStoryboardMvxTouchViewsContainer();
		}

		private class CustomStoryboardMvxTouchViewsContainer : MvxTouchViewsContainer
		{
			protected override IMvxTouchView CreateViewOfType (System.Type viewType, MvxViewModelRequest request)
			{
				return (IMvxTouchView)UIStoryboard.FromName("Storyboard", null).InstantiateViewController(viewType.Name);
			}
		}
    }
}