using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherDelivery.WebApi.Infrastructure
{
    public static class Settings
    {
        public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceBusConfig>(configuration.GetSection("ServiceBus"));
            services.Configure<ApiKey>(configuration.GetSection("ApiKey"));
        }
    }
}