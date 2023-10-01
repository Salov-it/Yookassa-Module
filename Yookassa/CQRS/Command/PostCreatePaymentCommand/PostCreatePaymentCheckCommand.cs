using MediatR;
using Yookassa.Domain.CreatePayment;

namespace Yookassa.Application.CQRS.Command.PostCreatePaymentCommand
{
    public class PostCreatePaymentCheckCommand : IRequest<string>
    {
        public CreatePaymentCheckModel createPaymentCheckModel { get; set; }    
    }
}
