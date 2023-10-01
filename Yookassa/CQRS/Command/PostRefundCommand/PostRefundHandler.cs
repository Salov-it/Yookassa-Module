using MediatR;
using Yookassa.Application.Interface;

namespace Yookassa.Application.CQRS.Command.PostRefundCommand
{
    public class PostRefundHandler : IRequestHandler<PostRefundCommand, string>
    {
        private readonly IRefund _refund;

        public PostRefundHandler(IRefund refund)
        {
            _refund = refund;
        }
        public async Task<string> Handle(PostRefundCommand request, CancellationToken cancellationToken)
        {
            var content = await _refund.Return(request.refundModel);
            return content;
        }
    }
}
