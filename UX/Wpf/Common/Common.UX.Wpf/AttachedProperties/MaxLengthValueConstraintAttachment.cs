using System;
using System.Windows;
using Infragistics.Windows.DataPresenter;
using Infragistics.Windows.Editors;

namespace Common.UX.Wpf.AttachedProperties
{
    public class MaxLengthValueConstraintAttachment
    {
        public static readonly DependencyProperty CustomMaxLengthProperty = DependencyProperty.RegisterAttached(
                "CustomMaxLength",
                typeof(int),
                typeof(MaxLengthValueConstraintAttachment),
                new PropertyMetadata(default(int), CustomMaxLengthChanged));

        private static void CustomMaxLengthChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs)
        {

            int result;
            if (dependencyObject is Field field && eventArgs.NewValue is int)
            {
                field.PropertyChanged += (sender, args) =>
                {
                    Int32.TryParse(eventArgs.NewValue.ToString(), out result);
                    var v = new ValueConstraint {MaxLength = result};
                    if (field.ValueConstraint == null)
                    {
                        field.ValueConstraint = v;
                    }
                };
            }
        }

        public static void SetCustomMaxLength(DependencyObject element, int value)
        {
            element.SetValue(CustomMaxLengthProperty, value);
        }

        public static int GeCustomMaxLength(DependencyObject element)
        {
            return (int)element.GetValue(CustomMaxLengthProperty);
        }
    }
}
