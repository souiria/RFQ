using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Security;

namespace Common.UX.Wpf.Contracts.Models.Administration
{
    public class UXFunctionHierarchyModel : FunctionHierarchyModel
    {
        public UXFunctionHierarchyModel() { }

        public UXFunctionHierarchyModel(FunctionHierarchyModel function)
        {
            Id = function.Id;
            Name = function.Name;
            CreatedDate = function.CreatedDate;
            ModifiedDate = function.ModifiedDate;
            IsRowChecked = function.IsRowChecked;
            CreatedBy = function.CreatedBy;
            ModifiedBy = function.ModifiedBy;
            IsActive = function.IsActive;
            ActiveDirectoryName = function.ActiveDirectoryName;
            FunctionName = function.FunctionName;
            IsSelected = function.IsSelected;
        }

        private ObservableCollection<UXModuleHierarchyModel> _modules;
        public new ObservableCollection<UXModuleHierarchyModel> Modules
        {
            get => _modules;
            set => SetProperty(ref _modules, value);
        }
    }
}
