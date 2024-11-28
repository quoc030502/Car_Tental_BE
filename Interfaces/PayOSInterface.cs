using Net.payOS.Types;

namespace basic_api.Interfaces
{
    public interface IPayOsInterface
    {
        Task<CreatePaymentResult> CreatePayment(long orderCode, string carName, double deposit, string type);
    }
}
