using System.Windows;

namespace Common.UX.Wpf.Contracts.Models
{
    public class DataContextProxy : Freezable
    {
        public object Data
        {
            get => (object)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(DataContextProxy), null);

        protected override Freezable CreateInstanceCore()
        {
            return new DataContextProxy();
        }
    }
}
