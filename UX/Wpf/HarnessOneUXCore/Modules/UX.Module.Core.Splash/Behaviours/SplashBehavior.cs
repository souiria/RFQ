using System.Windows;

namespace SEWSE.H1.UX.Module.Core.Splash.Behaviours
{
    public class SplashBehavior
    {
        #region Dependency Properties
        public static readonly DependencyProperty EnabledProperty = DependencyProperty.RegisterAttached(
            "Enabled", typeof(bool), typeof(SplashBehavior), new PropertyMetadata(OnEnabledChanged));

        public static bool GetEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnabledProperty);
        }

        public static void SetEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(EnabledProperty, value);
        }
        #endregion

        #region Event Handlers
        private static void OnEnabledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var splash = obj as Window;
            if (splash != null && args.NewValue is bool && (bool)args.NewValue)
            {
                splash.Closed += (s, e) =>
                {
                    splash.DataContext = null;
                    splash.Dispatcher.InvokeShutdown();
                };
                splash.MouseDoubleClick += (s, e) => splash.Close();
                splash.MouseLeftButtonDown += (s, e) => splash.DragMove();
            }
        }
        #endregion
    }
}