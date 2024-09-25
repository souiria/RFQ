/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FGPurchasedPriceAlertModel.cs
Function           :   FG Purchased Price Alert Model
Created By         :   Ranjay
Created on         :   19-Jul-2023
Revision History   :
                   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Finance
{
    [DataContract, Serializable]
    public class FGPurchasedPriceAlertModel : BaseModel<Guid>
    {
        /// <summary>
        /// CustomerBusinessGroupGuid
        /// </summary>        
        private Guid _customerBusinessGroupGuid;
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => SetProperty(ref _customerBusinessGroupGuid, value);
        }
        /// <summary>
        /// CustomerBusinessGroup
        /// </summary>
        private string _customerBusinessGroup;
        [DataMember]
        public string CustomerBusinessGroup
        {
            get => _customerBusinessGroup;
            set => SetProperty(ref _customerBusinessGroup, value);
        }
        /// <summary>
        /// CustomerNameGuid
        /// </summary>        
        private Guid _customerGuid;
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }
        /// <summary>
        /// CustomerName
        /// </summary>
        private string _customerName;
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }
        /// <summary>
        /// ManufacturingSiteGuid
        /// </summary>        
        private Guid _manufacturingSiteGuid;
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => SetProperty(ref _manufacturingSiteGuid, value);
        }
        /// <summary>
        /// ManufacturingSite
        /// </summary>
        private string _manufacturingSite;
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite, value);
        }


        ///// <summary>
        ///// PurchasingUserGuid 
        ///// </summary>
        private List<Guid> _purchasingUserGuid;



        [DataMember]
        public List<Guid> PurchasingUserGuid
        {
            get => _purchasingUserGuid;
            set => SetProperty(ref _purchasingUserGuid, value);
        }


    }

    [DataContract, Serializable]
    public class FGPurchasedPriceFilterModel
    {
        /// <summary>
        /// FilterType
        /// </summary>
        private string _filterType;
        [DataMember]
        public string FilterType
        {
            get => _filterType;
            set => _filterType = value;
        }
        /// <summary>
        /// CustomerBusinessGroupGuid
        /// </summary>        
        private Guid _customerBusinessGroupGuid;
        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => _customerBusinessGroupGuid = value;
        }
        /// <summary>
        /// CustomerGuid
        /// </summary>        
        private Guid _customerGuid;
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }
        private Guid _manufacturingSiteGuid;
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => _manufacturingSiteGuid= value;
        }
    }


}
