/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BusinessUnitFGPurchasedPriceAssociation.cs
Function           :   Business Unit FG Purchased Price Association
Created By         :   Sejal Srivastava
Created on         :   07-03-2022
Revision History   :
                   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.Core.Infrastructure.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Finance
{
    [DataContract, Serializable]
    public class BusinessUnitFGPurchasedPriceAssociationModel : BaseModel<Guid>
    {
        
        /// <summary>
        /// BusinessUnitGuid
        /// </summary>        
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        /// <summary>
        /// FGPurchasePriceType
        /// </summary>
        private int _FGPurchasePriceType;
        [DataMember]
        public int FGPurchasePriceType
        {
            get => _FGPurchasePriceType;
            set => SetProperty(ref _FGPurchasePriceType, value);
        }
        

    }

    /// <summary>
    /// DAta Contract for BusinessUnitFGPurchasedPriceAssociationFilterModel
    /// </summary>
    [DataContract, Serializable]
    public class BusinessUnitFGPurchasedPriceAssociationFilterModel
    {
        /// <summary>
        /// Local variable _businessUnitGuid
        /// </summary>
        private Guid? _businessUnitGuid;
        /// <summary>
        /// Get or Set for {BusinessUnitGuid}.
        /// </summary>
        [DataMember]
        public Guid? BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => _businessUnitGuid = value;
        }
    }

}