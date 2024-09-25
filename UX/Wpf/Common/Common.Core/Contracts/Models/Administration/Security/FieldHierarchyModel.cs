using Common.Core.Contracts.Interfaces.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Maintenance;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class FieldHierarchyModel : H1FieldMasterModel, IHierarchyModel
    {
        private bool? _isSelected = false;
        [DataMember]
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        private Guid _viewId;
        [DataMember]
        public Guid ViewId
        {
            get => _viewId;
            set => SetProperty(ref _viewId, value);
        }

        private Guid _fieldSecurityGuid;
        [DataMember]
        public Guid FieldSecurityGuid
        {
            get => _fieldSecurityGuid;
            set => SetProperty(ref _fieldSecurityGuid, value);
        }

        public FieldHierarchyModel()
        {

        }

        public FieldHierarchyModel(H1FieldMasterModel masterModel)
        {
            if (masterModel == null) throw new ArgumentNullException(nameof(masterModel));

            Id = masterModel.Id;
            CreatedBy = masterModel.CreatedBy;
            CreatedDate = masterModel.CreatedDate;
            CrudOperationType = masterModel.CrudOperationType;
            FieldName = masterModel.FieldName;
            FieldDescription = masterModel.FieldDescription;
            VariableName = masterModel.VariableName;
            IsActive = masterModel.IsActive;
            IsRowChecked = masterModel.IsRowChecked;
            ModifiedBy = masterModel.ModifiedBy;
            ModifiedDate = masterModel.ModifiedDate;
            IsSelected = false;
        }
    }
}
