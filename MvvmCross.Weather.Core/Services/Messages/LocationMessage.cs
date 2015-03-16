using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace MvvmCross.Weather.Core.Services
{
    public class LocationMessage : MvxMessage
    {
        public LocationMessage(object sender, double lat, double lng)
            : base(sender)
        {
            Lat = lat;
            Lng = lng;
        }

        public double Lat { get; private set; }
        public double Lng { get; private set; }
    }
}
