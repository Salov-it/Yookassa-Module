using MediatR;
using Yookassa.Application.Interface;


namespace Yookassa.Application.CQRS.Command.PostCreateCheckCommand
{
    public class PostCreateReceiptOnPaymentHandler : IRequestHandler<PostCreateReceiptOnPaymentCommand, string>
    {
        private readonly ICreateReceiptOnPayment _createReceiptOnPayment;

        public PostCreateReceiptOnPaymentHandler(ICreateReceiptOnPayment createReceiptOnPayment)
        {
            _createReceiptOnPayment = createReceiptOnPayment;
        }
        public async Task<string> Handle(PostCreateReceiptOnPaymentCommand request, CancellationToken cancellationToken)
        {
            var content = await _createReceiptOnPayment.CreateReceiptOnPayments(request.checkPayment,"45");
            return content;
        }
    }
}
