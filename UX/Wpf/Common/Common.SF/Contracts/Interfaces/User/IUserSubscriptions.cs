using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.User
{
    public interface IUserSubscriptions : IService
    {
        Task<IEnumerable<SubscriptionService>> GetSubscriptionsByUser(Guid id);
        Task SetUserSubscriptions(Guid id, IEnumerable<SubscriptionService> subscriptionModules);
    }
}
