using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherDelivery.Functions.Services;
using WeatherDelivery.Sdk.Models;

namespace WeatherDelivery.Functions
{
    public static class SendEmailFunction
    {
        [FunctionName("SendEmailFunction")]
        public static async Task RunAsync([CosmosDBTrigger(
            databaseName: "weatherDelivery",
            collectionName: "FetchedWeatherData",
            ConnectionStringSetting = "DatabaseConnectionString",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "SendEmailFunction_Leases")] IReadOnlyList<Document> input, ILogger log)
        {
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }

            foreach (var item in input)
            {
                var data = JsonConvert.DeserializeObject<FetchedWeatherData>(item.ToString());
                await SendEmailService.SendMailAsync(data.Delivery.EmailAddress, data.Delivery.Location, data.Weather);
            }
        }
    }
}