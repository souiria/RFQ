using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Wpf.Contracts.Models
{
    class BusyIndicator : IBusyIndicator
    {
        IEventAggregator _eventAggregator;
        public  BusyIndicator(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public async Task ShowBusyIndicator(Action action)
        {
            _eventAggregator.GetEvent<LoadingEvent>().Publish(true);
            await Task.Run(action).ContinueWith((T) => { _eventAggregator.GetEvent<LoadingEvent>().Publish(false); });
        }
    }
}
