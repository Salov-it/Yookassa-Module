using MediatR;
using System.Text.Json;
using Yookassa.Domain.Check;

namespace Yookassa.Application.CQRS.Command.PostCreateCheckCommand
{
    public class PostCreateReceiptOnPaymentCommand : IRequest<string>
    {
        public CheckPayment.PaymentRequestModel checkPayment { get; set; }
    }

}
