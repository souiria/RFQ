using SEWSE.H1.Common.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Models
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
