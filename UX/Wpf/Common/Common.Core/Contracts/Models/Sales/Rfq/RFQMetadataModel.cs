using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.Core.Contracts.Models.Purchasing;
using Common.Core.Contracts.Models.Sales.Rfq.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Rfq
{
    [DataContract, Serializable]
    [KnownType(typeof(RFQMetadataModel))]
    public class RFQMetadataModel : BaseModel<Guid>
    {
        #region TempData Storage
        private List<RFQDerivativeCollectionModel> _derivativeCollectionList;
        [DataMember]
        public List<RFQDerivativeCollectionModel> DerivativeCollectionList
        {
            get => _derivativeCollectionList;
            set => SetProperty(ref _derivativeCollectionList, value);
        }

        private List<RFQCreationGroupedPartModel> _groupedPartList;
        [DataMember]
        public List<RFQCreationGroupedPartModel> GroupedPartList
        {
            get => _groupedPartList;
            set => SetProperty(ref _groupedPartList, value);
        }

        private List<DerivativeInformationModel> _derivativeInformation;
        [DataMember]
        public List<DerivativeInformationModel> DerivativeInformation
        {
            get => _derivativeInformation;
            set => SetProperty(ref _derivativeInformation, value);
        }

        private List<RFQParentHeirarchyModel> _rfqParentHeirarchy;
        [DataMember]
        public List<RFQParentHeirarchyModel> RFQParentHeirarchy
        {
            get => _rfqParentHeirarchy;
            set => SetProperty(ref _rfqParentHeirarchy, value);
        }

        private List<RFQRemovedStoreModel> _rfqRemovedPartsList;
        [DataMember]
        public List<RFQRemovedStoreModel> RfqRemovedPartsList
        {
            get => _rfqRemovedPartsList;
            set => SetProperty(ref _rfqRemovedPartsList, value);
        }
        #endregion

        private CustomerHierarchyModel _customerHierarchy;
        [DataMember]
        public CustomerHierarchyModel CustomerHierarchy
        {
            get => _customerHierarchy;
            set => SetProperty(ref _customerHierarchy, value);
        }
        public CustomerModel _customer;
        [DataMember]
        public CustomerModel Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }

        private int _vehicleVolume;
        [DataMember]
        public int VehicleVolume
        {
            get => _vehicleVolume;
            set => SetProperty(ref _vehicleVolume, value);
        }

        private ProjectModel _project;
        [DataMember]
        public ProjectModel Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        private ProjectHierarchyModel _projectHierarchy;
        public ProjectHierarchyModel ProjectHierarchy
        {
            get => _projectHierarchy;
            set => SetProperty(ref _projectHierarchy, value);
        }

        private ProjectHierarchyModel _projectDetails;
        public ProjectHierarchyModel ProjectDetails
        {
            get => _projectDetails;
            set => SetProperty(ref _projectDetails, value);
        }

        private PlatformHierarchyModel _platformDetails;
        public PlatformHierarchyModel PlatformDetails
        {
            get => _platformDetails;
            set => SetProperty(ref _platformDetails, value);
        }

        private ProgramHierarchyModel _programDetails;
        public ProgramHierarchyModel ProgramDetails
        {
            get => _programDetails;
            set => SetProperty(ref _programDetails, value);
        }
        private RFQReasonModel _reason;
        public RFQReasonModel Reason
        {
            get => _reason;
            set => SetProperty(ref _reason, value);
        }
        private DateTime? _rfqDeadline;
        [DataMember]
        public DateTime? RfqDeadline
        {
            get => _rfqDeadline;
            set => SetProperty(ref _rfqDeadline, value);
        }

        private RFQStatus _status;
        [DataMember]
        public RFQStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        private List<string> _admin;
        [DataMember]
        public List<string> Admin
        {
            get => _admin;
            set => SetProperty(ref _admin, value);
        }
    }
}