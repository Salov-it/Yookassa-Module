using MediatR;
using Yookassa.Domain.WriteEverythingOff;

namespace Yookassa.Application.CQRS.Command.PostWriteEverythingOffCommand
{
    public class PostWriteEverythingOffCommand : IRequest<string>
    {
        public WriteEverythingOffModel1 writeEverythingOffModel1 { get; set; }  
    }
}
