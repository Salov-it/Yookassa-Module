using Yookassa.Domain.CancellationPayment;

namespace Yookassa.Application.Interface
{
    public interface ICancellationPayment
    {
        Task<string> CancelAsync(CancellationPaymentModel cancellationPaymentModel);
    }
}
