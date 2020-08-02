using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WeatherDelivery.WebApi.Infrastructure.ApiKeyAuth;

namespace WeatherDelivery.WebApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            var serviceBusConfig = services.BuildServiceProvider().GetService<IOptionsMonitor<ServiceBusConfig>>().CurrentValue;
            services.AddTransient<IQueueClient>(c => new QueueClient(serviceBusConfig.Endpoint, serviceBusConfig.QueueName));

            services.AddTransient<IGetApiKeyQuery, InMemoryGetApiKeyQuery>();
        }
    }
}