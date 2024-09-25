using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Notifications;
using Common.Core.Contracts.Models.User;
using Microsoft.ServiceFabric.Actors;

namespace Common.SF.Contracts.Interfaces.User
{
    public interface IUserSettings : IActor
    {
        #region Crud Operations
        Task<Notification> CreateNotification(Notification notification);
        Task<IEnumerable<Notification>> GetAllNotifications();
        Task<Notification> SaveNotification(Notification model);
        Task<bool> DeleteNotification(Guid id);
        Task<bool> DeleteAllNotifications();
        Task<IEnumerable<SubscriptionService>> ModifySubscriptions(IEnumerable<SubscriptionService> subChannels);
        Task<IEnumerable<SubscriptionService>> GetAllSubscriptions();
        Task<UserPreferenceModel> UpdatePreferences(UserPreferenceModel model);
        Task<UserPreferenceModel> GetPreferences();
        #endregion
    }
}
