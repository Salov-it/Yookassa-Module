using Yookassa.Domain.WriteoffPart;

namespace Yookassa.Application.Interface
{
    public interface IWriteoffPart
    {
        Task<string> WriteoffPart(WriteoffPartModel writeoffPartModel);
    }
}
