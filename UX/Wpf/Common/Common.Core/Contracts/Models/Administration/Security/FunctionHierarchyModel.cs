using Common.Core.Contracts.Interfaces.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Maintenance;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Security
{
    [DataContract, Serializable]
    public class FunctionHierarchyModel : H1FunctionMasterModel, IHierarchyModel
    {
        private ObservableCollection<ModuleHierarchyModel> _modules;
        [DataMember]
        public ObservableCollection<ModuleHierarchyModel> Modules
        {
            get => _modules;
            set => SetProperty(ref _modules, value);
        }

        private bool? _isSelected = false;
        [DataMember]
        public bool? IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public FunctionHierarchyModel()
        { }

        public FunctionHierarchyModel(H1FunctionMasterModel masterModel)
        {
            if(masterModel == null) throw new ArgumentNullException(nameof(masterModel));

            Id = masterModel.Id;
            ActiveDirectoryName = masterModel.ActiveDirectoryName;
            CreatedBy = masterModel.CreatedBy;
            CreatedDate = masterModel.CreatedDate;
            CrudOperationType = masterModel.CrudOperationType;
            FunctionName = masterModel.FunctionName;
            IsActive = masterModel.IsActive;
            IsRowChecked = masterModel.IsRowChecked;
            ModifiedBy = masterModel.ModifiedBy;
            ModifiedDate = masterModel.ModifiedDate;
            Modules = new ObservableCollection<ModuleHierarchyModel>();
            IsSelected = false;
        }

    }
}
