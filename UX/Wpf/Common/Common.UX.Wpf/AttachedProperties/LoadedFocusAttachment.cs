using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Common.UX.Wpf.AttachedProperties
{
    public class LoadedFocusAttachment
    {
        public static Control GetElementToFocus(UserControl control)
        {
            return (Control)control.GetValue(ElementToFocusProperty);
        }

        public static void SetElementToFocus(UserControl control, Control value)
        {
            control.SetValue(ElementToFocusProperty, value);
        }
        public static Control GetFocusedControl(UserControl control)
        {
            return (Control)control.GetValue(FocusedControlProperty);
        }

        public static void SetFocusedControl(UserControl control, Control value)
        {
            control.SetValue(FocusedControlProperty, value);
        }


        public static readonly DependencyProperty ElementToFocusProperty =
            DependencyProperty.RegisterAttached("ElementToFocus", typeof(Control),
                typeof(LoadedFocusAttachment), new UIPropertyMetadata(ElementToFocusPropertyChanged));

        public static readonly DependencyProperty FocusedControlProperty =
            DependencyProperty.RegisterAttached("FocusedControl", typeof(Control),
                typeof(LoadedFocusAttachment), new UIPropertyMetadata(null));

        public static void ElementToFocusPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
            {
                ((UserControl) e.OldValue).Loaded -= FocusElement;
                ((UserControl) e.OldValue).Unloaded -= StoreFocusedControl;
            }

            if (e.NewValue is UserControl userControl)
            {
                userControl.Loaded += FocusElement;
                userControl.Unloaded += StoreFocusedControl;
            }
        }

        private static void StoreFocusedControl(object sender, RoutedEventArgs e)
        {
            try
            {
                var x = Keyboard.FocusedElement;               
                if ((((DependencyObject)x).DependencyObjectType.SystemType).Name == "ContentPresenter")
                {
                    return;
                }               
                SetFocusedControl((UserControl)sender, (Control)x);
            }
            catch
            {
                // ignored
            }
        }

        private static void FocusElement(object sender, RoutedEventArgs e)
        {
            var view = sender as UserControl;
            var control = GetFocusedControl(view) ?? GetElementToFocus(view);

            if (control == null) return;

            if (!control.Focusable)
            {
                control.Focusable = true;
            }
            control.Focus();

        }
    }
}