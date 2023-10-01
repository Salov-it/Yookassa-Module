using MediatR;
using Yookassa.Application.Interface;

namespace Yookassa.Application.CQRS.Command.PostWriteoffPartCommand
{
    public class PostWriteoffPartHandle : IRequestHandler<PostWriteoffPartCommand, string>
    {
        public readonly IWriteoffPart _writeoffPart;

        public PostWriteoffPartHandle(IWriteoffPart writeoffPart)
        {
            _writeoffPart = writeoffPart;
        }
        public async Task<string> Handle(PostWriteoffPartCommand request, CancellationToken cancellationToken)
        {
            var content = await _writeoffPart.WriteoffPart(request.writeoffPartModel);
            return content;
        }
    }
}
