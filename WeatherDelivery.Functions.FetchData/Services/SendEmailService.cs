using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherDelivery.Sdk.Models;
using WeatherDelivery.Sdk.Helpers;

namespace WeatherDelivery.Functions.Services
{
    public static class SendEmailService
    {
        private static readonly string ApiKey = Environment.GetEnvironmentVariable("SendGridApiKey");

        public static async Task SendMailAsync(string emailAddress, string location, WeatherApiResponse weather)
        {
            var sendGridClient = new SendGridClient(ApiKey);

            var from = new EmailAddress("maks.knoski@gmail.com", "Maks");
            var subject = $"Your weather for {location}";
            var to = new EmailAddress(emailAddress);
            var plainTextContent = "";
            var htmlContent = $"<h1>{location} - {weather.weather.FirstOrDefault().main}</h1>" +
                $"<strong>Temp: {weather.main.temp.ToInt()}°C</strong>" + "<br><br>" +
                $"<strong>Temp feels like: {weather.main.feels_like.ToInt()}°C</strong>" + "<br><br>" +
                $"<strong>Temp min: {weather.main.temp_max.ToInt()}°C</strong>" + "<br><br>" +
                $"<strong>Temp min: {weather.main.temp_max.ToInt()}°C</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            await sendGridClient.SendEmailAsync(msg);
        }
    }
}