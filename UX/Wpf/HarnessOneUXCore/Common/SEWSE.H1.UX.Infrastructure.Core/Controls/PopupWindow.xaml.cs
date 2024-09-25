using SEWSE.H1.Common.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Contracts;
using SEWSE.H1.UX.Infrastructure.Core.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SEWSE.H1.UX.Infrastructure.Core.Controls
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        private bool IsClosing { get; set; }
        public PopupWindow(Notification notification)
        {
            InitializeComponent();
            Header.Text = "New Notification";
            Content.Text = notification.MessageHeader;
            Left = SystemParameters.PrimaryScreenWidth;
            Top = SystemParameters.PrimaryScreenHeight - 165;
        }

        public Task BeginAsync(WindowAnimationDirection direction)
        {
            DoubleAnimation animation = null;
            switch (direction)
            {
                case (WindowAnimationDirection.Left):
                    Dispatcher.Invoke(() =>
                    {
                        animation = new DoubleAnimation(Left - 350, TimeSpan.FromSeconds(0.7));
                        Timeline.SetDesiredFrameRate(animation, 15);
                        animation.EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut };
                    });
                    break;

                case (WindowAnimationDirection.Up):
                    Dispatcher.Invoke(() =>
                    {
                        animation = new DoubleAnimation(Top - 115, TimeSpan.FromSeconds(0.7));
                        Timeline.SetDesiredFrameRate(animation, 15);
                        animation.EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut };
                    });
                    break;

                case (WindowAnimationDirection.Right):
                    Dispatcher.Invoke(() =>
                    {
                        animation = new DoubleAnimation(SystemParameters.PrimaryScreenWidth, TimeSpan.FromSeconds(0.35));
                        Timeline.SetDesiredFrameRate(animation, 15);
                        animation.Completed += Animation_Completed;
                    });
                    break;

                case (WindowAnimationDirection.Down):
                    Dispatcher.Invoke(() =>
                    {
                        animation = new DoubleAnimation(Top + 115, TimeSpan.FromSeconds(0.7));
                        Timeline.SetDesiredFrameRate(animation, 15);
                        animation.EasingFunction = new CircleEase { EasingMode = EasingMode.EaseOut };
                    });
                    break;
            }

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            EventHandler onComplete = null;
            onComplete = (s, e) =>
            {
                animation.Completed -= onComplete;
                tcs.SetResult(true);
            };
            Dispatcher.Invoke(() => animation.Completed += onComplete);
            switch (direction)
            {
                case (WindowAnimationDirection.Right):
                case (WindowAnimationDirection.Left):
                    Dispatcher.Invoke(() =>
                    {
                        BeginAnimation(LeftProperty, animation);
                    });
                    break;

                case (WindowAnimationDirection.Down):
                case (WindowAnimationDirection.Up):
                    Dispatcher.Invoke(() =>
                    {
                        BeginAnimation(TopProperty, animation);
                    });
                    break;
            }

            return tcs.Task;
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            Close();
        }
    }
}
