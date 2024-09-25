/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerDeliveryPointAssociationModel.cs
Function           :   Customer Delivery Point Association
Created By         :   Shivam Dhingra 
Created on         :   07-Oct-2021
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

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// Class File for Customer Delivery Point
    /// </summary>
    [DataContract, Serializable]
    public class CustomerDeliveryPointAssociationModel : BaseModel<Guid>
    {
        private Guid _customerHierarchyGuid;
        /// <summary>
        /// get or set for CustomerHierarchyGuid
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerHierarchyGuid
        {
            get => _customerHierarchyGuid;
            set => SetProperty(ref _customerHierarchyGuid, value);
        }

        private string _customerDeliveryPoint;
        /// <summary>
        /// CustomerDeliveryPoint
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(20)]
        public string CustomerDeliveryPoint
        {
            get => _customerDeliveryPoint;
            set => SetProperty(ref _customerDeliveryPoint, value);
        }

        private string _customerDeliveryLocation;
        /// <summary>
        /// CustomerDeliveryLocation
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(50)]
        public string CustomerDeliveryLocation
        {
            get => _customerDeliveryLocation;
            set => SetProperty(ref _customerDeliveryLocation, value);
        }
    }
}
