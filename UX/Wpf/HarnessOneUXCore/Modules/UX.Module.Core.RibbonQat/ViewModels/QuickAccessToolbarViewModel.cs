using Common.UX.Wpf.Base;
using Common.UX.Wpf.Events;
using Prism.Events;

namespace SEWSE.H1.UX.Module.Core.RibbonQat.ViewModels
{
    public class QuickAccessToolbarViewModel : ViewModelBase
    {
        #region Properties
        

        #endregion

        public QuickAccessToolbarViewModel(IEventAggregator eventAggregator) : base (eventAggregator)
        {
            _eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Loading Quick Access Toolbar Module" });
        }
    }
}
