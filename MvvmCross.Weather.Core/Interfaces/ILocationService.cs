using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCross.Weather.Core.Interfaces
{
    public interface ILocationService
    {
        void StartLocationUpdates();

        void StopLocationUpdates();

    }
}
