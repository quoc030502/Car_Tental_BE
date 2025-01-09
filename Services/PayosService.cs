using basic_api.Constants;
using basic_api.Interfaces;
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


        public async Task<CreatePaymentResult> CreatePayment(long orderCode, string carName, double amount, int punishment, string type, int drivingCost)
        {
            PayOS payOS = new(_clientID, _apiKey, _checksumKey);
            string typeString = type == PaymentType.CarDeposit ? "tiền cọc" : "tổng";
            int intAmount = (int)amount;
            List<ItemData> items = [new($"{carName} + ({typeString})", 1, intAmount)];

            if (punishment != 0)
            {
                items.Add(new ItemData("Punishment", 1, punishment));
            }

            if (drivingCost != 0)
            {
                items.Add(new ItemData("Driving Cost (Thanh toán khi trả xe)", 1, drivingCost));
            }

            PaymentData paymentData = new(orderCode, (int)Math.Round(amount, 0) + punishment, type,
                 items, _cancelURL, _returnURL);

            return await payOS.createPaymentLink(paymentData);
        }
    }
}