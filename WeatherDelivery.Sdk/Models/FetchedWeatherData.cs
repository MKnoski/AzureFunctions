using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherDelivery.Sdk.Models
{
    public class FetchedWeatherData
    {
        public FetchedWeatherData(Delivery delivery, WeatherApiResponse weather)
        {
            Id = delivery.Id;
            Weather = weather;
            Delivery = delivery;
        }

        public Guid Id { get; }

        public WeatherApiResponse Weather { get; }

        public Delivery Delivery { get; }
    }
}