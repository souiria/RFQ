/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CountryUserFunctionAssociationModel.cs
Function           :   CountryUserFunctionAssociation
Created By         :   Dharmendra Kumar 
Created on         :   04-Nov-2020
Revision History   :   [11-Nov-2020]: Dharmendra Kumar
                   :   []: Rename Model and Property BusinessProcessGuid
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Administration.Maintenance
{
    /// <summary>
    /// Country User Function Association Model
    /// </summary>
   [DataContract,Serializable]
    public class CountryUserFunctionAssociationModel : BaseModel<Guid>
    {
        
        private Guid _userGuid;
        /// <summary>
        /// Get or set for UserGuid
        /// </summary>
        [DataMember]
        [Required]
        public Guid UserGuid
        {
            get => _userGuid;
            set => SetProperty(ref _userGuid, value);
        }
        private List<BusinessProcessUserAssociationByCountryModel> _lstBusinessProcessByCountryAndSitesAndCountryAssociation;
        /// <summary>
        /// This field will set BusinessUnitList
        /// </summary>
        [DataMember]
        [Required]
        public List<BusinessProcessUserAssociationByCountryModel> BusinessProcessCountryHierarchyList
        {
            get => _lstBusinessProcessByCountryAndSitesAndCountryAssociation;
            set => SetProperty(ref _lstBusinessProcessByCountryAndSitesAndCountryAssociation, value);
        }

    }
    /// <summary>
    ///  Model class for mapping BusinessProcessByCountryAndSitesAndCountryAssociationModel
    /// </summary>
    [DataContract, Serializable]
    public class BusinessProcessUserAssociationByCountryModel : BaseModel<Guid>
    {

        
        private Guid _businessProcessGuid;
        /// <summary>
        /// This field will set _businessProcessByCountryAndSitesGuid
        /// </summary>
        [DataMember]
        public Guid BusinessProcessGuid
        {
            get => _businessProcessGuid;
            set => SetProperty(ref _businessProcessGuid, value);
        }

        private Guid _countryGuid;
        /// <summary>
        /// This field will set CountryGuid
        /// </summary>
        [DataMember]
        public Guid CountryGuid
        {
            get => _countryGuid;
            set => SetProperty(ref _countryGuid, value);
        }

    }


}
