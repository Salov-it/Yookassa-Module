using System.Text.Json;
using Yookassa.Domain.Check;

namespace Yookassa.Application.Interface
{
    public interface ICreateReceiptOnPayment
    {
        Task<string> CreateReceiptOnPayments(CheckPayment.PaymentRequestModel checkPayment, string idempotenceKey);
    }
}
