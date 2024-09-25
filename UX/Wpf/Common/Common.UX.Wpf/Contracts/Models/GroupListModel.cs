using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Base;

namespace Common.UX.Wpf.Contracts.Models
{
    public class GroupListModel : BindableBaseEntity
    {
        private ObservableCollection<string> _availableGroups;
        public ObservableCollection<string> AvailableGroups
        {
            get => _availableGroups;
            set => SetProperty(ref _availableGroups, value);
        }

        private string _selectedGroup;
        public string SelectedGroup
        {
            get => _selectedGroup;
            set => SetProperty(ref _selectedGroup, value);
        }

    }
}
