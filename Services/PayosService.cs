﻿using basic_api.Interfaces;
using basic_api.Models;
using Net.payOS;
using Net.payOS.Types;

namespace basic_api.Services
{
    public class PayOsService : IPayOsInterface
    {
        private readonly string _clientID = Environment.GetEnvironmentVariable("CLIENT_ID") ?? "";
        private readonly string _apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? "";
        private readonly string _checksumKey = Environment.GetEnvironmentVariable("CHECKSUM_KEY") ?? "";
        private readonly string _cancelURL = Environment.GetEnvironmentVariable("CANCEL_URL") ?? "";
        private readonly string _returnURL = Environment.GetEnvironmentVariable("RETURN_URL") ?? "";


        public async Task<CreatePaymentResult> CreatePayment(long orderCode, string carName, double amount, string type)
        {
            PayOS payOS = new(_clientID, _apiKey, _checksumKey);

            int intAmount = (int)amount;

            ItemData item = new(carName, 1, intAmount);

            PaymentData paymentData = new(orderCode, (int)Math.Round(amount, 0), type,
                 [item], _cancelURL, _returnURL);

            return await payOS.createPaymentLink(paymentData);
        }
    }
}