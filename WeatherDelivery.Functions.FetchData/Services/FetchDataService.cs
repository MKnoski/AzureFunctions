using Flurl;
using Flurl.Http;
using System;
using System.Threading.Tasks;
using WeatherDelivery.Sdk.Models;

namespace WeatherDelivery.Functions.Services
{
    public static class FetchDataService
    {
        private const string FetchDataHost = "http://api.openweathermap.org/data/2.5";

        private static readonly string ApiKey = Environment.GetEnvironmentVariable("OpenWeatherMapApiKey");

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