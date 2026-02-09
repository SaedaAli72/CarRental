using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalBLL.Services
{
    public class StripeService
    {
        private readonly string _secretKey;
        public StripeService( IConfiguration configuration)
        {
            _secretKey = configuration["Stripe:SecretKey"];
           StripeConfiguration.ApiKey = _secretKey;

        }
        public string CreatePaymentIntent(decimal amount)
        {
            long amountInCents = (long)(amount * 100);

            var options = new PaymentIntentCreateOptions
            {
                Amount = amountInCents,
                Currency = "usd",
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            return paymentIntent.ClientSecret;
        }



        public bool ConfirmPayment(string paymentIntentId)
        {
            var service = new PaymentIntentService();
            var paymentIntent = service.Get(paymentIntentId);

            return paymentIntent.Status == "succeeded";
        }
    }
}
