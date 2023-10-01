using MediatR;
using Yookassa.Domain.Refund;

namespace Yookassa.Application.CQRS.Command.PostRefundCommand
{
    public class PostRefundCommand : IRequest<string>
    {
        public RefundModel refundModel { get; set; }    
    }
}
