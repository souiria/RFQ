using Common.UX.Wpf.Base;
using Common.UX.Wpf.Events;
using Prism.Events;

namespace SEWSE.H1.UX.Module.Core.ApplicationMenu.ViewModels
{
    public class ApplicationMenuViewModel : ViewModelBase
    {
        #region Properties

        private string _menuLabel;
        public string MenuLabel
        {
            get => _menuLabel;
            set => SetProperty(ref _menuLabel, value);
        }

        #endregion

        public ApplicationMenuViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Loading Application Menu Module" });

            AddLabels();            
        }

        private void AddLabels()
        {
            LabelsNeeded.Add("00002");
        }

        public override void PageLoaded()
        {
            base.PageLoaded();
            MenuLabel = Labels["00002"] ?? "Menu";
        }
    }
}
