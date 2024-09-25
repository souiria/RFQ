using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Notifications;
using Common.Core.Contracts.Models.User;
using Microsoft.ServiceFabric.Actors;

namespace Common.SF.Contracts.Interfaces.Core.User
{
    public interface IUser : IActor
    {
        Task<Notification> CreateNotification(Notification notification);
        Task<byte[]> GetAllNotifications();
        Task<Notification> SaveNotification(Notification model);
        Task DeleteNotification(Guid id);

        Task<IEnumerable<SubscriptionService>> GetAllSubscriptions();
        Task<IEnumerable<SubscriptionService>> ModifySubscriptions(IEnumerable<SubscriptionService> subChannels);

        Task<UserPreferenceModel> UpdatePreferences(UserPreferenceModel model);
        Task<UserPreferenceModel> GetPreferences();

        Task IsRead(Guid id, bool isRead);
        Task ClearNotifications();
    }
}
