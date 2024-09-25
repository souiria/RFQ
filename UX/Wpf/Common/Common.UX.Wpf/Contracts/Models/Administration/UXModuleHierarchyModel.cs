using Common.Core.Contracts.Models.Administration.Security;

namespace Common.UX.Wpf.Contracts.Models.Administration
{
    public class UXModuleHierarchyModel : ModuleHierarchyModel
    {
        public UXModuleHierarchyModel() { }

        public UXModuleHierarchyModel(ModuleHierarchyModel module)
        {
            Id = module.Id;
            Name = module.Name;
            CreatedDate = module.CreatedDate;
            ModifiedDate = module.ModifiedDate;
            IsRowChecked = module.IsRowChecked;
            CreatedBy = module.CreatedBy;
            ModifiedBy = module.ModifiedBy;
            IsActive = module.IsActive;
            ActiveDirectoryName = module.ActiveDirectoryName;
            ModuleName = module.ModuleName;
            IsSelected = module.IsSelected;
            Views = module.Views;
        }

        private OwnedStatus _isOwned;
        public OwnedStatus IsOwned
        {
            get => _isOwned;
            set => SetProperty(ref _isOwned, value);
        }
    }
}
