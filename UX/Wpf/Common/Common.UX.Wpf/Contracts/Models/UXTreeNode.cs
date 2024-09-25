using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace Common.UX.Wpf.Contracts.Models
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
