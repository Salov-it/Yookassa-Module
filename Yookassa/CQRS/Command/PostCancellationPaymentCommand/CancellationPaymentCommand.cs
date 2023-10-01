using MediatR;
using Yookassa.Domain.CancellationPayment;

namespace Yookassa.Application.CQRS.Command.PostCancellationPaymentCommand
{
    public class CancellationPaymentCommand : IRequest<string>
    {
        public CancellationPaymentModel cancellationPaymentModel { get;set; }
    }
}
