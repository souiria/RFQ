using System;
using Common.UX.Wpf.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace SEWSE.H1.UX.Module.Core.WidgetBar.ViewModels
{
    public class WidgetBarViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;

        public WidgetBarViewModel(IRegionManager regionManager, IEventAggregator ea)
        {
            _regionManager = regionManager;
            _eventAggregator = ea;
            _eventAggregator.GetEvent<MaximizeScreenEvent>().Subscribe(MaximizeScreen);
            _eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Loading WidgetBar Module" });
        }

        private void MaximizeScreen(bool isMinimized)
        {
            IsScreenMinimized = Convert.ToBoolean(isMinimized);
        }

        private bool _isScreenMinimized;
        public bool IsScreenMinimized
        {
            get { return _isScreenMinimized; }
            set { SetProperty(ref _isScreenMinimized, value); }
        }
    }
}