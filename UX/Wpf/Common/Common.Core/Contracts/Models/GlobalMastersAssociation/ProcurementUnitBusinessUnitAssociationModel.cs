/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProcurementUnitBusinessUnitAssociationModel.cs
Function           :   Procurement Unit Business Unit Association Model
Created By         :   Pawan
Created on         :   29-Nov-2019
Revision History   :   [10-Jun-2020] : Pawan
                   :   [] : Added field for Site Quality Manager
                   :   [06-Jul-2020] : Shivam Dhingra
                   :   [] : Added field for SyncCurrencyExchangeDataToDHS
                   :   [06-Jul-2020] : Shivam Dhingra
                   :   [] : Added DataMember with SyncCurrencyExchangeDataToDHS
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract, Serializable]
    public class ProcurementUnitBusinessUnitAssociationModel : BaseModel<Guid>
    {

        private Guid _procurementUnitGuid;
        [DataMember]
        [Required]
        public Guid ProcurementUnitGuid
        {
            get => _procurementUnitGuid;
            set => SetProperty(ref _procurementUnitGuid, value);
        }

        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        private string _businessUnitShortCode;
        [DataMember]
        [Required]
        [StringLength(1)]
        public string BusinessUnitShortCode
        {
            get => _businessUnitShortCode;
            set => SetProperty(ref _businessUnitShortCode, value);
        }

        private Guid _baseCurrencyGuid;
        [DataMember]
        [Required]
        public Guid BaseCurrencyGuid
        {
            get => _baseCurrencyGuid;
            set => SetProperty(ref _baseCurrencyGuid, value);
        }

        private Guid _siteQualityManagerGuid;
        /// <summary>
        /// Site Quality Manager Guid
        /// </summary>
        [DataMember]
        public Guid SiteQualityManagerGuid
        {
            get => _siteQualityManagerGuid;
            set => SetProperty(ref _siteQualityManagerGuid, value);
        }

        private bool _syncCurrencyExchangeDataToDHS = false;
        /// <summary>
        /// SyncCurrencyExchangeDataToDHS
        /// </summary>
        [DataMember]
        public bool SyncCurrencyExchangeDataToDHS
        {
            get => _syncCurrencyExchangeDataToDHS;
            set => SetProperty(ref _syncCurrencyExchangeDataToDHS, value);
        }


    }
}
