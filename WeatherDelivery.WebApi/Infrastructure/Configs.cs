using System;

namespace WeatherDelivery.WebApi.Infrastructure
{
    public class ServiceBusConfig
    {
        public string Endpoint { get; set; }

        public string QueueName { get; set; }
    }

    public class ApiKey
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public string Key { get; set; }
        public DateTime Created { get; set; }
    }
}