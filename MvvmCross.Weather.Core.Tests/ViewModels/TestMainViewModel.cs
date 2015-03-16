// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the TestMainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using Moq;
using MvvmCross.Weather.Core.Interfaces;

namespace MvvmCross.Weather.Core.Tests.ViewModels
{
    using Core.ViewModels;

    using NUnit.Framework;

    /// <summary>
    /// Defines the TestMainViewModel type.
    /// </summary>
    [TestFixture]
    public class TestMainViewModel : BaseTest
    {
        /// <summary>
        /// The MainViewModel.
        /// </summary>
        private MainViewModel mainViewModel;

        /// <summary>
        /// Creates an instance of the object to test.
        /// To allow Ninja automatically create the unit tests
        /// this method should not be changed.
        /// </summary>
        public override void CreateTestableObject()
        {
            this.mainViewModel = Mvx.IocConstruct<MainViewModel>();
        }

        /// <summary>
        /// Tests my property.
        /// </summary>
        [Test]
        public void TestMyProperty()
        {
            //// arrange
            bool changed = false;

            this.mainViewModel.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "currentCity")
                    {
                        changed = true;
                    }
                };

            //// act
            this.mainViewModel.CityName = "Hello MvvmCross";

            //// assert
            Assert.AreEqual(changed, true);
        }

        /// <summary>
        /// Tests my command.
        /// </summary>
        [Test]
        public void TestMyCommand()
        {
            
        }
    }
}
