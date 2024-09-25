using SEWSE.H1.Common.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Helpers;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Services
{
    public static partial class ServiceHelper
    {
        public static List<Notification> GetNotifications()
        {
            return ClusterApiHelper.GetNotificationApi().Get<Notification>();
        }

        public static int GetNotificationsCount()
        {
            return ClusterApiHelper.GetNotificationApi().Get<Notification>().Count;
        }
    }
}
