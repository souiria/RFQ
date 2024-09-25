using System;
using Common.Core.Contracts.Models.Administration.Security;
using Prism.Mvvm;

namespace Common.UX.Wpf.Contracts.Models.Administration
{
 public class ComboModuleHierarchyModel : BindableBase
    {
        #region Properites

        private Guid _id;
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _activeDirectoryName;
        public string ActiveDirectoryName
        {
            get => _activeDirectoryName;
            set => SetProperty(ref _activeDirectoryName, value);
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        private string _function;
        public string Function
        {
            get => _function;
            set => SetProperty(ref _function, value);
        }

        private Guid _currentlyOwnedBy;
        public Guid CurrentlyOwnedBy
        {
            get => _currentlyOwnedBy;
            set => SetProperty(ref _currentlyOwnedBy, value);
        }
        #endregion

        #region ctor

        public ComboModuleHierarchyModel() { }

        public ComboModuleHierarchyModel(ComboModuleHierarchyModel moduleHierarchyModel)
        {
            Id = moduleHierarchyModel.Id;
            ActiveDirectoryName = moduleHierarchyModel.ActiveDirectoryName;
            IsSelected = moduleHierarchyModel.IsSelected;
            Function = moduleHierarchyModel.Function;
            CurrentlyOwnedBy = moduleHierarchyModel.CurrentlyOwnedBy;
        }

        public ComboModuleHierarchyModel(ModuleHierarchyModel moduleHierarchyModel)
        {
            Id = moduleHierarchyModel.Id;
            ActiveDirectoryName = moduleHierarchyModel.ActiveDirectoryName;
        }

        public ComboModuleHierarchyModel(ModuleHierarchyModel moduleHierarchyModel, FunctionHierarchyModel function) : this(moduleHierarchyModel)
        {
            Function = function.FunctionName;
        }

        public ComboModuleHierarchyModel(ModuleHierarchyModel moduleHierarchyModel, bool isSelected) : this(moduleHierarchyModel)
        {
            IsSelected = isSelected;
        }

        public ComboModuleHierarchyModel(ModuleHierarchyModel moduleHierarchyModel, FunctionHierarchyModel function, bool isSelected) : this(moduleHierarchyModel)
        {
            Function = function.FunctionName;
            IsSelected = isSelected;
        }

        public ComboModuleHierarchyModel(ModuleHierarchyModel moduleHierarchyModel, bool isSelected, FunctionHierarchyModel function) : this(moduleHierarchyModel)
        {
            Function = function.FunctionName;
            IsSelected = isSelected;
        }

        #endregion
    }
}
