using Prism.Events;

namespace SEWSE.H1.UX.Module.Core.WidgetBar.Views
{
    /// <summary>
    /// Interaction logic for WidgetBar.xaml
    /// </summary>
    public partial class WidgetBar
    {
        private IEventAggregator _eventAggregator;

        public WidgetBar(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();
        }
    }
}
