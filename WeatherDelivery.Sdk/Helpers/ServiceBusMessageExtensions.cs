using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Text;

namespace WeatherDelivery.Sdk.Helpers
{
    public static class ServiceBusMessageExtensions
    {
        public static Message ToMessage<T>(this T @this)
            where T : class
        {
            var body = JsonConvert.SerializeObject(@this);

            var message = new Message(Encoding.UTF8.GetBytes(body));
            message.UserProperties.Add("Type,", nameof(T));
            message.MessageId = Guid.NewGuid().ToString();

            return message;
        }
    }
}