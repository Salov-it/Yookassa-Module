using MediatR;
using Yookassa.Application.Interface;

namespace Yookassa.Application.CQRS.Command.PostWriteEverythingOffCommand
{
    public class PostWriteEverythingOffHandle : IRequestHandler<PostWriteEverythingOffCommand, string>
    {
        public readonly IWriteEverythingOff _writeEverythingOff;
        public PostWriteEverythingOffHandle(IWriteEverythingOff writeEverythingOff)
        {
            _writeEverythingOff = writeEverythingOff;
        }
        public async Task<string> Handle(PostWriteEverythingOffCommand request, CancellationToken cancellationToken)
        {
            var content = await _writeEverythingOff.WriteOffAll(request.writeEverythingOffModel1);

            return content;
        }
    }
}
