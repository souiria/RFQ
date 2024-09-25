using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Base
{
    public interface IDeleteAll : IService
    {
        Task DeleteAll();
    }
}
