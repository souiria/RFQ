namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        public static readonly ServiceEndpointRoutes UserSettingsPreference = new ServiceEndpointRoutes("UserSettings/Preference");
        public static readonly ServiceEndpointRoutes UserSettingsNotification = new ServiceEndpointRoutes("UserSettings/Notification");
        public static readonly ServiceEndpointRoutes UserSettingsSubscription = new ServiceEndpointRoutes("UserSettings/Subscription");
        public static readonly ServiceEndpointRoutes UserSubscriptions = new ServiceEndpointRoutes("UserSubscriptions");
    }
}
