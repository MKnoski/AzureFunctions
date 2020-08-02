using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using WeatherDelivery.Sdk.Models;

namespace WeatherDelivery.Functions.FetchData
{
    public static class FetchDataService
    {
        private const string FetchDataHost = "http://api.openweathermap.org/data/2.5";

        private const string ApiKey = "25b4d3146e296514799c8743105a1324";

        public static async Task<WeatherApiResponse> FetchWeatherDataAsync(string location)
        {
            var response = await FetchDataHost
                .AppendPathSegment("weather")
                .SetQueryParams(new
                {
                    q = location,
                    units = "metric",
                    appid = ApiKey,
                })
                .GetAsync()
                .ReceiveJson<WeatherApiResponse>();

            return response;
        }
    }
}