using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Notifications
{
    public interface INotifications : IService, ISubscriptions
    {
        /// <summary>
        /// Adds a notification to the publishing queue.
        /// </summary>
        /// <param name="notification">The notification to be published</param>
        /// <returns></returns>
        Task EnqueueNotification(Notification notification);

        /// <summary>
        /// Get the redis endpoint which can be consumed by RedisContext.
        /// </summary>
        /// <returns>The endpoint.</returns>
        Task<string> GetRedisEndpoint();
    }
}
