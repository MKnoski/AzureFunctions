using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDelivery.Sdk.Models
{
    public class FetchedWeatherData
    {
        public FetchedWeatherData(Guid id, WeatherApiResponse weather)
        {
            Id = id;
            Weather = weather;
        }

        public Guid Id { get; }

        public WeatherApiResponse Weather { get; }
    }
}