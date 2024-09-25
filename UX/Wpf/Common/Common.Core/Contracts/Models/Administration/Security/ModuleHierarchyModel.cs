using Common.Core.Contracts.Interfaces.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Maintenance;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class ModuleHierarchyModel : H1ModuleMasterModel, IHierarchyModel
    {
        private ObservableCollection<ViewHierarchyModel> _views;
        [DataMember]
        public ObservableCollection<ViewHierarchyModel> Views
        {
            get => _views;
            set => SetProperty(ref _views, value);
        }

        private bool? _isSelected = false;
        [DataMember]
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public ModuleHierarchyModel()
        { }

        public ModuleHierarchyModel(H1ModuleMasterModel masterModel)
        {
            if (masterModel == null) throw new ArgumentNullException(nameof(masterModel));

            Id = masterModel.Id;
            ActiveDirectoryName = masterModel.ActiveDirectoryName;
            CreatedBy = masterModel.CreatedBy;
            CreatedDate = masterModel.CreatedDate;
            CrudOperationType = masterModel.CrudOperationType;
            ModuleName = masterModel.ModuleName;
            IsActive = masterModel.IsActive;
            IsRowChecked = masterModel.IsRowChecked;
            ModifiedBy = masterModel.ModifiedBy;
            ModifiedDate = masterModel.ModifiedDate;
            Views = new ObservableCollection<ViewHierarchyModel>();
            IsSelected = false;
        }
    }
}
