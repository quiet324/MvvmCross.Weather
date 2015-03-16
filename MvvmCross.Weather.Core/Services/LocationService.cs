using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.Plugins.Messenger;
using MvvmCross.Weather.Core.Interfaces;

namespace MvvmCross.Weather.Core.Services
{
    public class LocationService
    : ILocationService
    {
        private readonly IMvxLocationWatcher watcher;
        private readonly IMvxMessenger messenger;

        public LocationService(IMvxLocationWatcher watcher, IMvxMessenger messenger)
        {
            this.watcher = watcher;
            this.messenger = messenger;
        }

        public void StartLocationUpdates()
        {
            this.watcher.Start(new MvxLocationOptions(), OnLocation, OnError);
        }

        public void StopLocationUpdates()
        {
            this.watcher.Stop();
        }

        private void OnLocation(MvxGeoLocation location)
        {
            var message = new LocationMessage(this,
                                              location.Coordinates.Latitude,
                                              location.Coordinates.Longitude
                );

            messenger.Publish(message);
        }

        private void OnError(MvxLocationError error)
        {
            Mvx.Error("Seen location error {0}", error.Code);
        }
    }
}
