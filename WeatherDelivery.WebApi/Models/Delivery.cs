using MediatR;
using System;

namespace WeatherDelivery.WebApi.Models
{
    public class Delivery : IRequest
    {
        public Guid Id { get; set; }

        public string Location { get; set; }

        public string EmailAddress { get; set; }
    }
}