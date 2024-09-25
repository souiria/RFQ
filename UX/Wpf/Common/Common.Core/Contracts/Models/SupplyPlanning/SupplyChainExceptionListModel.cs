/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyChainExceptionListModel.cs
Function           :   Supply Chain Exception List
Created By         :   Sejal Srivastava
Created on         :   28-July-2022
Revision History   :   [04-Aug-2022] : Sejal Srivastava
*                  :   [] Improvements in screen
*                  :   [10-Aug-2022] : Sejal Srivastava
*                  :   [] Corrected name of parameter
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract for SupplyChainExceptionListModel
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainExceptionListModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _unloadingPointGuid     
        /// </summary>
        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => SetProperty(ref _unloadingPointGuid, value);
        }
        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }
    }

    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in SupplyChainExceptionList endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainExceptionListByProcedureParameterModel
    {
        /// <summary>
        /// Local variable _unloadingPointGuid
        /// </summary>
        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => _unloadingPointGuid = value;
        }

    }

    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in SupplyChainExceptionList endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainExceptionListCustomerPartNumberParameter
    {
        /// <summary>
        /// Local variable _unloadingPointGuid     
        /// </summary>
        private Guid? _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid? UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => _unloadingPointGuid = value;
        }

    }
    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in SupplyChainExceptionList endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainExceptionListGetCustomerPartNumber
    {
        
        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }
    }

    [DataContract, Serializable]
    public class SupplyChainExceptionListDownloadTemplate
    {
        /// <summary>
        /// Local variable _unloadingPoint     
        /// </summary>
        private string _unloadingPointCode;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        public string UnloadingPointCode
        {
            get => _unloadingPointCode;
            set => _unloadingPointCode = value;
        }
        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }
    }

    [DataContract, Serializable]
    public class SupplyChainExceptionListDownloadErrorModel 
    {
        /// <summary>
        /// Local variable _unloadingPoint     
        /// </summary>
        private string _unloadingPointCode;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        public string UnloadingPointCode
        {
            get => _unloadingPointCode;
            set => _unloadingPointCode = value;
        }
        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        // <summary>
        /// Local variable _Error
        /// </summary>
        private string _Error;
        /// <summary>
        /// Get or Set for {Error}.
        /// </summary>
        [DataMember]
        public string Error
        {
            get => _Error;
            set => _Error = value;
        }
    }
}
