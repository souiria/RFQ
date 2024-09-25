using Common.UX.Wpf.Base;
using Common.UX.Wpf.Events;
using Prism.Events;

namespace SEWSE.H1.UX.Module.Core.Dashboard.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        public DashboardViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Loading Dashboard Module" });
            View = "00006";
            AddLabels();
        }

        private void AddLabels()
        {
            LabelsNeeded.Add("00006");
        }

        public override void PageLoaded()
        {
            base.PageLoaded();
            Header = Labels["00006"] ?? "Dashboard";
        }
    }
}
