using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherDelivery.WebApi
{
    public static class DependencyInjection
    {
        private const string ServiceBusConnectionString = "Endpoint=sb://weatherdelivery.servicebus.windows.net/;SharedAccessKeyName=sender;SharedAccessKey=aJ1wuQsKtKTRzB6fncb91q/2d84xRwhFMwXy9siTu2U=";
        private const string QueueName = "weatherdeliveryqueue";

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IQueueClient>(c => new QueueClient(ServiceBusConnectionString, QueueName));
        }
    }
}