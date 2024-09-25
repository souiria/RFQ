using Common.SF.Contracts.Interfaces.Base.Base64;
using Common.SF.Contracts.Interfaces.Base.Byte;
using Common.SF.Infrastructure.PubSub.Interfaces;

namespace Common.SF.Contracts.Interfaces.Base
{
    public interface IBase : ISubscriberService, IDeleteAll, IBase64, IBaseByte
    {
    }
}
