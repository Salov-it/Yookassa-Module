using MediatR;
using Yookassa.Domain.WriteoffPart;

namespace Yookassa.Application.CQRS.Command.PostWriteoffPartCommand
{
    public class PostWriteoffPartCommand : IRequest<string>
    {
        public WriteoffPartModel writeoffPartModel { get; set; }    
    }
}
