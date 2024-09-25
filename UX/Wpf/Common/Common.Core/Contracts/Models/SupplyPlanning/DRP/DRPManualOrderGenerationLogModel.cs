/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :  DRPManualOrderGenerationLogModel.cs
Function           :   
Created By         :  Piyush Anand
Created on         :  19-Sep-2023 [HD-00365855]
Revision History   :   

****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// This class is used to have information about to DRP Manual Order Generation Log Model.
    /// </summary>
    [DataContract, Serializable]
    public class DRPManualOrderGenerationLogModel : BaseModel<Guid>
    {
        private string _documentID;
        /// <summary>
        /// Get or Set for {DocumentID}
        /// </summary>
        [DataMember]
        public string DocumentID
        {
            get => _documentID;
            set => SetProperty(ref _documentID, value);
        }
        private string _customerBusinessGroup;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroup}
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroup
        {
            get => _customerBusinessGroup;
            set => SetProperty(ref _customerBusinessGroup, value);
        }
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }
        private string _projectName;
        /// <summary>
        /// Get or Set for {ProjectName}
        /// </summary>
        [DataMember]
        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }
        private string _dCLocation;
        /// <summary>
        /// Get or Set for {DCLocation}
        /// </summary>
        [DataMember]
        public string DCLocation
        {
            get => _dCLocation;
            set => SetProperty(ref _dCLocation, value);
        }
        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }
        private string _documentStatus;
        /// <summary>
        /// Get or Set for {DocumentStatus}
        /// </summary>
        [DataMember]
        public string DocumentStatus
        {
            get => _documentStatus;
            set => SetProperty(ref _documentStatus, value);
        }
        private string _dRPOrderNo;
        /// <summary>
        /// Get or Set for {DRPOrderNo}
        /// </summary>
        [DataMember]
        public string DRPOrderNo
        {
            get => _dRPOrderNo;
            set => SetProperty(ref _dRPOrderNo, value);
        }
        private DateTime? _issueDate;
        /// <summary>
        /// Get or Set for {IssueDate}
        /// </summary>
        [DataMember]
        public DateTime? IssueDate
        {
            get => _issueDate;
            set => SetProperty(ref _issueDate, value);
        }
        private DateTime? _shipDate;
        /// <summary>
        /// Get or Set for {ShipDate}
        /// </summary>
        [DataMember]
        public DateTime? ShipDate
        {
            get => _shipDate;
            set => SetProperty(ref _shipDate, value);
        }
        private DateTime? _arrivalDate;
        /// <summary>
        /// Get or Set for {ArrivalDate}
        /// </summary>
        [DataMember]
        public DateTime? ArrivalDate
        {
            get => _arrivalDate;
            set => SetProperty(ref _arrivalDate, value);
        }
        private DateTime? _receiveDate;
        /// <summary>
        /// Get or Set for {ReceiveDate}
        /// </summary>
        [DataMember]
        public DateTime? ReceiveDate
        {
            get => _receiveDate;
            set => SetProperty(ref _receiveDate, value);
        }
        private string _partNo;
        /// <summary>
        /// Get or Set for {PartNo}
        /// </summary>
        [DataMember]
        public string PartNo
        {
            get => _partNo;
            set => SetProperty(ref _partNo, value);
        }
        private int _orderedQuantity;
        /// <summary>
        /// Get or Set for {OrderedQuantity}
        /// </summary>
        [DataMember]
        public int OrderedQuantity
        {
            get => _orderedQuantity;
            set => SetProperty(ref _orderedQuantity, value);
        }
        private string _reason;
        /// <summary>
        /// Get or Set for {Reason}
        /// </summary>
        [DataMember]
        public string Reason
        {
            get => _reason;
            set => SetProperty(ref _reason, value);
        }
    }

    public class FilterDRPManualOrderGenerationLogModel
    {
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }
        private Guid _projectGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }
        private Guid _dCLocationGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}
        /// </summary>
        [DataMember]
        public Guid DCLocationGuid
        {
            get => _dCLocationGuid;
            set => _dCLocationGuid = value;
        }
        private Guid _mFSiteGuid;
        /// <summary>
        /// Get or Set for {MFSiteGuid}
        /// </summary>
        [DataMember]
        public Guid MFSiteGuid
        {
            get => _mFSiteGuid;
            set => _mFSiteGuid = value;
        }
        private string _documentStatus;
        /// <summary>
        /// Get or Set for {DocumentStatus}
        /// </summary>
        [DataMember]
        public string DocumentStatus
        {
            get => _documentStatus;
            set => _documentStatus = value;
        }
        private string _p_DocumentStatus;
        /// <summary>
        /// Get or Set for {_p_DocumentStatus}.
        /// </summary>
        [DataMember]
        public string P_DocumentStatus
        {
            get => _p_DocumentStatus;
            set => _p_DocumentStatus = value;
        }
        private DateTime? _creationDateFrom;
        /// <summary>
        /// Get or Set for {CreationDateFrom}
        /// </summary>
        [DataMember]
        public DateTime? CreationDateFrom
        {
            get => _creationDateFrom;
            set => _creationDateFrom = value;
        }
        private DateTime? _creationDateTo;
        /// <summary>
        /// Get or Set for {CreationDateTO}
        /// </summary>
        [DataMember]
        public DateTime? CreationDateTO
        {
            get => _creationDateTo;
            set => _creationDateTo = value;
        }
    }
}
