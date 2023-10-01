using MediatR;
using Yookassa.Application.Interface;
using Yookassa.Domain.CreatePayment;

namespace Yookassa.Application.CQRS.Command.PostCreatePaymentCommand
{
    public class PostCreatePaymentCheckHandle : IRequestHandler<PostCreatePaymentCheckCommand,string>
    {
        private readonly ICreatePayment _createPayment;

       public PostCreatePaymentCheckHandle(ICreatePayment createPayment)
       {
          _createPayment = createPayment;
       }

        public async Task<string> Handle(PostCreatePaymentCheckCommand request, CancellationToken cancellationToken)
        {
            var content = await _createPayment.CreatePaymentCheck(request.createPaymentCheckModel);
            return content;
        }
    }
}
