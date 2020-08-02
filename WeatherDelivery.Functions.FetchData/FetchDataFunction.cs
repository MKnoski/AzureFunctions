using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherDelivery.Sdk.Models;

namespace WeatherDelivery.Functions.FetchData
{
    public static class FetchDataFunction
    {
        [ServiceBusAccount("ServiceBusAccount")]
        [FunctionName("FetchDataFunction")]
        public static async Task RunAsync(
            [ServiceBusTrigger("weatherdeliveryqueue")] string myQueueItem,
            [CosmosDB(
                databaseName: "weatherDelivery",
                collectionName: "FetchedWeatherData",
                ConnectionStringSetting = "DatabaseConnectionString")] IAsyncCollector<FetchedWeatherData> documents,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            var delivery = JsonConvert.DeserializeObject<Delivery>(myQueueItem);

            var weather = await FetchDataService.FetchWeatherDataAsync(delivery.Location);

            var data = new FetchedWeatherData(delivery.Id, weather);
            await documents.AddAsync(data);
        }
    }
}