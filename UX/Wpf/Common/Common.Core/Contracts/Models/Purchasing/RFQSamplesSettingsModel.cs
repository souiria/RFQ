/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   RFQSamplesSettingsModel.cs
Function           :   Commodity Quantity Settings for Sample
Created By         :   Param
Created on         :   03-Jun-2019
Revision History   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of Commodity Name.
    /// </summary>
    [DataContract, Serializable]
    public class RFQSamplesSettingsModel : BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets a GUID value for the Commodity column.
        /// </summary>
        private Guid _commodityGuid;
        [DataMember]
        [Required]
        //Navigation Property
        public Guid CommodityGuid
        {
            get => _commodityGuid;
            set => SetProperty(ref _commodityGuid, value);
        }

        /// <summary>
        /// Gets or sets a string value for the Commodity Qty Limit.
        /// </summary>
        private int _commoditySampleQty;
        [DataMember]
        [Required]
        public int CommoditySampleQty
        {
            get => _commoditySampleQty;
            set => SetProperty(ref _commoditySampleQty, value);
        }

    }
}
