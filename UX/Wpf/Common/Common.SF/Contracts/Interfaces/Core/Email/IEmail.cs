using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Email;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Notifications
{
    public interface IEmail : IService
    {
        Task EnqueueEmail(EmailDetail email);
    }
}
