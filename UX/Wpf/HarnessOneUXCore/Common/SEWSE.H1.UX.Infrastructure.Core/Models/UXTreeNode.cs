using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Models
{
    public class UXTreeNode : BindableBase
    {
        private string _displayName;
        public string DisplayName
        {
            get => _displayName;
            set => SetProperty(ref _displayName, value);
        }

        private ObservableCollection<UXTreeNode> _children;
        public ObservableCollection<UXTreeNode> Children
        {
            get => _children;
            set => SetProperty(ref _children, value);
        }
    }
}
