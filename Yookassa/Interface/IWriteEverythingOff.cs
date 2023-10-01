using Yookassa.Domain.WriteEverythingOff;

namespace Yookassa.Application.Interface
{
    public interface IWriteEverythingOff
    {
        Task<string> WriteOffAll(WriteEverythingOffModel1 writeEverythingOffModel1);
    }
}
