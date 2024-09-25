using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;

namespace Common.UX.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for LookupTextBlock.xaml
    /// </summary>
    public partial class LookupTextBlock
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(LookupTextBlock), new PropertyMetadata(null, ReevaluateItems));

        public static readonly DependencyProperty DisplayMemberPathProperty =
            DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(LookupTextBlock), new PropertyMetadata(null, ReevaluateItems));

        public static readonly DependencyProperty LookupPropertyPathProperty =
             DependencyProperty.Register("LookupPropertyPath", typeof(string), typeof(LookupTextBlock), new PropertyMetadata(null, ReevaluateItems));

        public static readonly DependencyProperty ValueProperty =
             DependencyProperty.Register("Value", typeof(object), typeof(LookupTextBlock), new PropertyMetadata(null, ReevaluateItems));

        public static readonly DependencyProperty IfNullProperty =
             DependencyProperty.Register("IfNull", typeof(string), typeof(LookupTextBlock), new PropertyMetadata(null));

        [Bindable(true, BindingDirection.OneWay)]
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public string DisplayMemberPath
        {
            get => (string)GetValue(DisplayMemberPathProperty);
            set => SetValue(DisplayMemberPathProperty, value);
        }

        public string LookupPropertyPath
        {
            get => (string)GetValue(LookupPropertyPathProperty);
            set => SetValue(LookupPropertyPathProperty, value);
        }

        [Bindable(true, BindingDirection.OneWay)]
        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public string IfNull
        {
            get => (string)GetValue(IfNullProperty);
            set => SetValue(IfNullProperty, value);
        }


        private static void ReevaluateItems(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is LookupTextBlock lookupTextBlock)) return;
            if (Equals(e.NewValue, e.OldValue)) return;

            if (lookupTextBlock.ItemsSource != null && lookupTextBlock.DisplayMemberPath != null &&
                lookupTextBlock.LookupPropertyPath != null && lookupTextBlock.Value != null)
            {
                if (lookupTextBlock.ItemsSource is IDictionary dictionary && dictionary.Contains(lookupTextBlock.Value))
                {
                    if (lookupTextBlock.DisplayMemberPath.StartsWith("Value."))
                        Debug.WriteLine("WARNING: LookupTextBlock binding is a dictionary but still attempt to bind to the Value of a KeyValuePair.");
                    var binding = new Binding(lookupTextBlock.DisplayMemberPath)
                    {
                        Source = dictionary[lookupTextBlock.Value],
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                    };
                    lookupTextBlock.SetBinding(ContentProperty, binding);
                    return;
                }
                else
                {
                    foreach (var item in lookupTextBlock.ItemsSource)
                    {
                        var internalValueBinding = new Binding(lookupTextBlock.LookupPropertyPath)
                        {
                            Source = item,
                            Mode = BindingMode.OneWay
                        };

                        var internalValue = new InternalValue();
                        BindingOperations.SetBinding(internalValue, InternalValue.ValueProperty, internalValueBinding);

                        if (internalValue.Value == null ||
                            !internalValue.Value.Equals(lookupTextBlock.Value)) continue;

                        var binding = new Binding(lookupTextBlock.DisplayMemberPath)
                        {
                            Source = item,
                            Mode = BindingMode.TwoWay,
                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                        };
                        lookupTextBlock.SetBinding(ContentProperty, binding);
                        return;
                    }
                }
            }
            if (lookupTextBlock.IfNull != null && lookupTextBlock.Value == null)
            {
                lookupTextBlock.Content = lookupTextBlock.IfNull;
            }
            else
            {
                BindingOperations.ClearBinding(lookupTextBlock, ContentProperty);
                lookupTextBlock.Content = null;
            }
        }

        public LookupTextBlock()
        {
            InitializeComponent();
        }
    }

    internal class InternalValue : DependencyObject
    {
        public object Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(InternalValue), new UIPropertyMetadata(null));
    }
}
