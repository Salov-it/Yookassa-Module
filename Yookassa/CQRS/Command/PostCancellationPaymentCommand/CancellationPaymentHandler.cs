using MediatR;
using Yookassa.Application.Interface;

namespace Yookassa.Application.CQRS.Command.PostCancellationPaymentCommand
{
    public class CancellationPaymentHandler : IRequestHandler<CancellationPaymentCommand, string>
    {
        private readonly ICancellationPayment _cancellationPayment;

        public CancellationPaymentHandler(ICancellationPayment cancellationPayment)
        {
            _cancellationPayment = cancellationPayment;
        }
        public async Task<string> Handle(CancellationPaymentCommand request, CancellationToken cancellationToken)
        {
            var content = await _cancellationPayment.CancelAsync(request.cancellationPaymentModel);
            return content;
        }
    }
}
