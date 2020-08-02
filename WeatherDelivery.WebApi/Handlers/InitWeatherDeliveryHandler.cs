using MediatR;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WeatherDelivery.Sdk.Helpers;
using WeatherDelivery.Sdk.Models;

namespace WeatherDelivery.WebApi.Handlers
{
    public class InitWeatherDeliveryHandler : AsyncRequestHandler<Delivery>
    {
        private readonly IQueueClient _queueClient;
        private readonly ILogger<InitWeatherDeliveryHandler> _logger;

        public InitWeatherDeliveryHandler(IQueueClient queueClient, ILogger<InitWeatherDeliveryHandler> logger)
        {
            _queueClient = queueClient;
            _logger = logger;
        }

        protected override async Task Handle(Delivery delivery, CancellationToken cancellationToken)
        {
            var message = delivery.ToMessage();

            _logger.LogInformation($"Sending delivery - id: {delivery.Id}");

            await _queueClient.SendAsync(message);
        }
    }
}