/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DRPManualOrderGenerationModel.cs
Function           :   DRP Manual Order Generation
Created By         :   Ranjay
Created on         :   18-Sep-2023 [HD-00365855]
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning.DRP
{
    /// <summary>
    /// Data Contract use for DRP Manual Order Generation
    /// </summary>
    [DataContract, Serializable]
    public class DRPManualOrderGenerationParameterModel
    {

        private Guid _customerBusinessHierarchyGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessHierarchyGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerBusinessHierarchyGuid
        {
            get => _customerBusinessHierarchyGuid;
            set => _customerBusinessHierarchyGuid = value;
        }

        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        private Guid _projectGuid;
        /// <summary>
        /// Get or Set for {ProjectGuid}.
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => _projectGuid = value;
        }

        private Guid _dCLocationGuid;
        /// <summary>
        /// Get or Set for {DCLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid DCLocationGuid
        {
            get => _dCLocationGuid;
            set => _dCLocationGuid = value;
        }

        private Guid _mfSiteGuid;
        /// <summary>
        /// Get or Set for {MFSiteGuid}.
        /// </summary>
        [DataMember]
        public Guid MFSiteGuid
        {
            get => _mfSiteGuid;
            set => _mfSiteGuid = value;
        }

        private string _documentStatus;
        /// <summary>
        /// Get or Set for {DocumentStatus}.
        /// </summary>
        [DataMember]
        public string DocumentStatus
        {
            get => _documentStatus;
            set => _documentStatus = value;
        }
    }

    [DataContract, Serializable]
    public class CustomerNameBasedOnSupplyChainModel : BaseModel<Guid>
    {
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        private string _customerCode;
        /// <summary>
        /// Get or Set for {CustomerCode}.
        /// </summary>
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }
    }

    [DataContract, Serializable]
    public class ProjectNameBasedOnSupplyChainModel : BaseModel<Guid>
    {
        private string _projectName;
        /// <summary>
        /// ProjectName
        /// </summary>
        [DataMember]
        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }
    }

    [DataContract, Serializable]
    public class DcLocationBasedOnSupplyChainModel : BaseModel<Guid>
    {
        private string _businessUnitCode;
        /// <summary>
        /// BusinessUnitCode
        /// </summary>
        [DataMember]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }
    }

    [DataContract, Serializable]
    public class MFSiteBasedOnSupplyChainModel : BaseModel<Guid>
    {
        private string _legacyBusinessUnitCode;
        /// <summary>
        /// LegacyBusinessUnitCode
        /// </summary>
        [DataMember]
        public string LegacyBusinessUnitCode
        {
            get => _legacyBusinessUnitCode;
            set => SetProperty(ref _legacyBusinessUnitCode, value);
        }
    }

}
