using Yookassa.Domain.CreatePayment;
using static Yookassa.Domain.CreatePayment.CreatePaymentCheckModel;

namespace Yookassa.Application.Interface
{
    public interface ICreatePayment
    {
        Task<string> CreatePaymentAsync(CreatePaymentModel.createPaymentModel createPaymentModel,
             string _Idempotence);
        Task<string> CreatePaymentCheck(CreatePaymentCheckModel createPaymentCheckModel);
    }
}
