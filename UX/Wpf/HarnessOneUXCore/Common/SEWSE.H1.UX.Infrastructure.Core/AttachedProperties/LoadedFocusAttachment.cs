using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEWSE.H1.UX.Infrastructure.Core.AttachedProperties
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
                (e.OldValue as UserControl).Loaded -= FocusElement;
                (e.OldValue as UserControl).Unloaded -= StoreFocusedControl;
            }

            var userControl = e.NewValue as UserControl;
            if (userControl != null)
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
            }            
        }

        private static void FocusElement(object sender, RoutedEventArgs e)
        {
            var view = sender as UserControl;
            Control control;
            if (GetFocusedControl(view) == null)
                control = GetElementToFocus(view);
            else
                control = GetFocusedControl(view);

            if (control != null)
            {
                if (!control.Focusable)
                {
                    control.Focusable = true;
                }
                control.Focus();
            }

        }
    }
}