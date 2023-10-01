using Yookassa.Domain.Refund;

namespace Yookassa.Application.Interface
{
    public interface IRefund
    {
        Task<string> Return(RefundModel refundModel);
    }
}
