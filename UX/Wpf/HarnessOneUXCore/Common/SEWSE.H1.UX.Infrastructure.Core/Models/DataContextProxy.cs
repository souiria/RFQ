using System.Windows;

namespace SEWSE.H1.UX.Infrastructure.Core.Models
{
    public class DataContextProxy : Freezable
    {
        public object Data
        {
            get { return (object)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register("Data", typeof(object), typeof(DataContextProxy), null);

        protected override Freezable CreateInstanceCore()
        {
            return new DataContextProxy();
        }
    }
}
