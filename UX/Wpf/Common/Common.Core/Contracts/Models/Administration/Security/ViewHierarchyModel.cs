using Common.Core.Contracts.Interfaces.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Maintenance;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class ViewHierarchyModel : H1ViewMasterModel, IHierarchyModel
    {
        private ObservableCollection<FieldHierarchyModel> _fields;
        [DataMember]
        public ObservableCollection<FieldHierarchyModel> Fields
        {
            get => _fields;
            set => SetProperty(ref _fields, value);
        }

        private bool? _isSelected = false;
        [DataMember]
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public ViewHierarchyModel() { }

        public ViewHierarchyModel(H1ViewMasterModel masterModel)
        {
            if (masterModel == null) throw new ArgumentNullException(nameof(masterModel));

            Id = masterModel.Id;
            ActiveDirectoryName = masterModel.ActiveDirectoryName;
            CreatedBy = masterModel.CreatedBy;
            CreatedDate = masterModel.CreatedDate;
            CrudOperationType = masterModel.CrudOperationType;
            ViewName = masterModel.ViewName;
            IsActive = masterModel.IsActive;
            IsRowChecked = masterModel.IsRowChecked;
            ModifiedBy = masterModel.ModifiedBy;
            ModifiedDate = masterModel.ModifiedDate;
            Fields = new ObservableCollection<FieldHierarchyModel>();
            IsSelected = false;
        }
    }
}
