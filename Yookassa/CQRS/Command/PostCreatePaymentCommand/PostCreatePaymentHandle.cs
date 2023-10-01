using MediatR;
using Yookassa.Application.Interface;

namespace Yookassa.Application.CQRS.Command.PostCreatePaymentCommand
{
    public class PostCreatePaymentHandle : IRequestHandler<PostCreatePaymentCommand, string>
    {
        private readonly ICreatePayment _createPayment;

       public PostCreatePaymentHandle(ICreatePayment createPayment)
        {
            _createPayment = createPayment;
        }

        public async Task<string> Handle(PostCreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var Content = await _createPayment.CreatePaymentAsync(request.createPayment1,
            request.createPayment1.idempotence);
            return Content;
        }
    }
}
