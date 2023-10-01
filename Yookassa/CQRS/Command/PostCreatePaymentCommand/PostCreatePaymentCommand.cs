using MediatR;
using Yookassa.Domain.CreatePayment;

namespace Yookassa.Application.CQRS.Command.PostCreatePaymentCommand
{
    public class PostCreatePaymentCommand : IRequest<string>
    {
      public CreatePaymentModel.createPaymentModel createPayment1 { get;set; }
    }
}
