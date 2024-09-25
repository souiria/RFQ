using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.Remoting.Contexts;
using CachingFramework.Redis;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Common.Core.Contracts.Models.Core.Notifications;
using Common.UX.Api.Commercial;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Controls;
using Common.UX.Wpf.EventHandlers;
using Common.UX.Wpf.Events;
using Prism.Events;
using Prism.Mvvm;

namespace Common.UX.Wpf.Helpers
{

    public class NotificationHelper : BindableBase
    {
        private IEventAggregator _eventAggregator;
        private bool _online;
        public bool Online
        {
            get => _online;
            set
            {
                SetProperty(ref _online, value);
                ConnectionChanged(_online);
            }
        }
        public event ConnectionEventHandler NotificationConnectionChanged;
        private List<Notification> WaitingNotifications { get; set; }
        private List<PopupWindow> LiveNotifications { get; set; }
        EventWaitHandle WaitHandle { get; set; }
        EventWaitHandle UserWaitHandle { get; set; }
        Context Context { get; set; }

        public NotificationHelper(IEventAggregator eventAggregator)
        {
            //Disabled until UX notifications has been reworked.

            //_eventAggregator = eventAggregator;
            //LiveNotifications = new List<PopupWindow>();
            //WaitingNotifications = new List<Notification>();
            //WaitHandle = new EventWaitHandle(true, EventResetMode.ManualReset);
            //UserWaitHandle = new EventWaitHandle(true, EventResetMode.ManualReset);
            //_eventAggregator.GetEvent<StandardNotificationEvent>().Subscribe(async (object obj) =>
            //{
            //    var notification = obj as Notification;
            //    WaitingNotifications.Add(notification);
            //});

            //Task.Run(() => WaitForNotifications());
            //InitializeConnection();
        }

        private async void InitializeConnection()
        {
            Online = await GetRedisContext(3);
            if (Online)
            {
                SubscribeToUserChannel();
                SubscribeToHelpDeskMailChannel();
            }
        }

        private async Task<bool> GetRedisContext(int retryCount)
        {
            if (retryCount > 0)
            {
                //Check a limited amount of times
                while (retryCount > 0)
                {
                    try
                    {
                        Context = new Context(await ServiceHelper.Get<string>(ServiceEndpointRoutes.Notifications));
                        Console.WriteLine("Redis endpoint resolved: " + Context.GetConnectionMultiplexer().GetEndPoints().ToString());
                        Context.GetConnectionMultiplexer().ConnectionFailed += NotificationHelper_ConnectionFailed;
                        return true;
                    }
                    catch (Exception e)
                    {
                        retryCount--;
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                }
            }
            GetRedisContext();

            return false;
        }

        private async Task GetRedisContext()
        {
            //Check until connected
            while (true)
            {
                try
                {
                    Context = new Context(await ServiceHelper.Get<string>(ServiceEndpointRoutes.Notifications));
                    Console.WriteLine("Redis endpoint resolved: " + Context.GetConnectionMultiplexer().GetEndPoints().ToString());
                    Context.GetConnectionMultiplexer().ConnectionFailed += NotificationHelper_ConnectionFailed;
                    Online = true;
                    return;
                }
                catch (Exception e)
                {
                    //30 Second Delay before retry
                    await Task.Delay(TimeSpan.FromSeconds(30));
                }
            }
        }

        protected void ConnectionChanged(bool state)
        {
            NotificationConnectionChanged?.Invoke(this, state);
        }

        private async void NotificationHelper_ConnectionFailed(object sender, StackExchange.Redis.ConnectionFailedEventArgs e)
        {
            Context.GetConnectionMultiplexer().ConnectionFailed -= NotificationHelper_ConnectionFailed;
            Context.Dispose();
            Online = false;
            await GetRedisContext(0);
        }

        public void SubscribeToUserChannel()
        {
            var userChannel = $"{UserPreferenceSetupHelper.UserPrincipalGuid.ToString()}Channel";

            Context.PubSub.Subscribe<object>(userChannel, message =>
            {
                _eventAggregator.GetEvent<StandardNotificationEvent>().Publish(message);
            });
        }

        public void SubscribeToHelpDeskMailChannel()
        {
            //var userChannel = "ErrorLogHelpDeskMailChannel";
            var userChannel = $"{UserPreferenceSetupHelper.UserPrincipalGuid.ToString()}ErrorLogHelpDeskMailChannel";

            Context.PubSub.Subscribe<object>(userChannel, message =>
            {
                _eventAggregator.GetEvent<StandardNotificationEvent>().Publish(message);
            });
        }

        #region Popup Methods

        private async Task WaitForNotifications()
        {
            while (true)
            {
                if (WaitingNotifications.Count > 0)
                {
                    List<Notification> preparedNotifications = new List<Notification>();
                    do
                    {
                        preparedNotifications.AddRange(WaitingNotifications);
                        WaitingNotifications.RemoveAll((x) => true);
                        await Task.Delay(TimeSpan.FromSeconds(2));
                    }
                    while (WaitingNotifications.Count > 0);

                    if (preparedNotifications.Count > 3)
                    {
                        var concatenatedNotifiaction = new Notification
                        {
                            Header = $"You have {preparedNotifications.Count} new notifications waiting...",
                            Body = $"You have {preparedNotifications.Count} new notifications waiting..."
                        };
                        DisplayNotification(concatenatedNotifiaction);
                    }
                    else
                    {
                        foreach (var prepNotifications in preparedNotifications)
                        {
                            DisplayNotification(prepNotifications);
                        }
                    }
                }
                await Task.Delay(TimeSpan.FromSeconds(5));
            }
        }

        public async Task DisplayNotification(object notification)
        {
            WaitHandle.WaitOne();
            UserWaitHandle.WaitOne();

            var anims = new List<Task>();
            var standardNotification = (Notification)notification;

            if (LiveNotifications.Count > 8)
            {
                var window = LiveNotifications.First();
                anims.Add(window.BeginAsync(WindowAnimationDirection.Right));
                LiveNotifications.Remove(window);
            }


            foreach (var liveNotification in LiveNotifications)
            {
                anims.Add(liveNotification.BeginAsync(WindowAnimationDirection.Up));
            }

            var popupWindow = Application.Current.Dispatcher.Invoke(() =>
            {
                PopupWindow popup = new PopupWindow(standardNotification);
                LiveNotifications.Add(popup);
                popup.MouseUp += Popup_MouseUp;
                popup.Show();

                return popup;
            });


            anims.Add(popupWindow.BeginAsync(WindowAnimationDirection.Left));

            UserWaitHandle.WaitOne();
            WaitHandle.Reset();

            await Task.WhenAll(anims);


            WaitHandle.Set();


            await Task.Delay(TimeSpan.FromSeconds(7));

            WaitHandle.WaitOne();
            UserWaitHandle.WaitOne();
            WaitHandle.Reset();

            await popupWindow.BeginAsync(WindowAnimationDirection.Right);

            WaitHandle.Set();

            LiveNotifications.Remove(popupWindow);
        }

        private async void Popup_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            await Task.Run(() => UserWaitHandle.WaitOne());
            UserWaitHandle.Reset();

            var popupWindow = sender as PopupWindow;
            List<Task> anims = new List<Task>();
            await popupWindow.BeginAsync(WindowAnimationDirection.Right);

            await Task.Run(() => WaitHandle.WaitOne());

            var index = LiveNotifications.IndexOf(popupWindow);
            LiveNotifications.Remove(popupWindow);
            LiveNotifications.ForEach(x =>
            {
                int i = LiveNotifications.IndexOf(x);
                if (i < index)
                {
                    anims.Add(x.BeginAsync(WindowAnimationDirection.Down));
                }
            });

            await Task.WhenAll(anims);

            UserWaitHandle.Set();
        }

        public async void NotificationRecieved(Notification notification)
        {
            WaitHandle.WaitOne();
            UserWaitHandle.WaitOne();

            var anims = new List<Task>();
            var standardNotification = (Notification)notification;

            if (LiveNotifications.Count > 8)
            {
                var window = LiveNotifications.First();
                anims.Add(window.BeginAsync(WindowAnimationDirection.Right));
                LiveNotifications.Remove(window);
            }


            foreach (var liveNotification in LiveNotifications)
            {
                anims.Add(liveNotification.BeginAsync(WindowAnimationDirection.Up));
            }

            var popupWindow = Application.Current.Dispatcher.Invoke(() =>
            {
                PopupWindow popup = new PopupWindow(standardNotification);
                LiveNotifications.Add(popup);
                popup.MouseUp += Popup_MouseUp;
                popup.Show();

                return popup;
            });


            anims.Add(popupWindow.BeginAsync(WindowAnimationDirection.Left));

            UserWaitHandle.WaitOne();
            WaitHandle.Reset();

            await Task.WhenAll(anims);


            WaitHandle.Set();


            await Task.Delay(TimeSpan.FromSeconds(7));

            WaitHandle.WaitOne();
            UserWaitHandle.WaitOne();
            WaitHandle.Reset();

            await popupWindow.BeginAsync(WindowAnimationDirection.Right);

            WaitHandle.Set();

            LiveNotifications.Remove(popupWindow);
        }
        #endregion
    }
}
