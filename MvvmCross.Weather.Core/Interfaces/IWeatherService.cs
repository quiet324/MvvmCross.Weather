using System.Threading.Tasks;

namespace MvvmCross.Weather.Core.Services
{
    public interface IWeatherService
    {
        Task GetCurrentWeatherAsync(double lon, double lat);
    }
}