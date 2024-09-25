/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerBacklogOrderModel.cs
Function           :   Customer Backlog Order
Created By         :   Shivam Dhingra
Created on         :   09-Nov-2020
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
    /// Data Contract for Customer Backlog Order
    /// </summary>
    [DataContract, Serializable]
    public class CustomerBacklogOrderModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _partNumber  
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(26)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        /// <summary>
        /// Local variable _orderNumber  
        /// </summary>
        private string _orderNumber;
        /// <summary>
        /// Get or Set for {OrderNumber}.
        /// Value will automatically generated through FunctionControlSequence
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(18)]
        public string OrderNumber
        {
            get => _orderNumber;
            set => SetProperty(ref _orderNumber, value);
        }

        /// <summary>
        /// Local variable _orderDate  
        /// </summary>
        private DateTime _orderDate;
        /// <summary>
        /// Get or Set for {OrderDate}.
        /// </summary>
        [DataMember]
        public DateTime OrderDate
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value);
        }

        /// <summary>
        /// Local variable _orderQty  
        /// </summary>
        private int _orderQty;
        /// <summary>
        /// Get or Set for {OrderQty}.
        /// </summary>
        [DataMember]
        public int OrderQty
        {
            get => _orderQty;
            set => SetProperty(ref _orderQty, value);
        }

        /// <summary>
        /// Local variable _shippedQty  
        /// </summary>
        private int _shippedQty = 0;
        /// <summary>
        /// Get or Set for {ShippedQty}.
        /// </summary>
        [DataMember]
        public int ShippedQty
        {
            get => _shippedQty;
            set => SetProperty(ref _shippedQty, value);
        }

        /// <summary>
        /// Local variable _backlogQty  
        /// </summary>
        private int _backlogQty = 0;
        /// <summary>
        /// Get or Set for {BacklogQty}.
        /// </summary>
        [DataMember]
        public int BacklogQty
        {
            get => _backlogQty;
            set => SetProperty(ref _backlogQty, value);
        }

        /// <summary>
        /// Local variable _customerNameGuid  
        /// </summary>
        private Guid _customerNameGuid;
        /// <summary>
        /// Get or Set for {CustomerNameGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerNameGuid
        {
            get => _customerNameGuid;
            set => SetProperty(ref _customerNameGuid, value);
        }

        /// <summary>
        /// Local variable _manufacturingSiteGuid  
        /// </summary>
        private Guid _manufacturingSiteGuid;
        /// <summary>
        /// Get or Set for {ManufacturingSiteGuid}.
        /// </summary>
        [DataMember]
        public Guid ManufacturingSiteGuid
        {
            get => _manufacturingSiteGuid;
            set => SetProperty(ref _manufacturingSiteGuid, value);
        }

        /// <summary>
        /// Local variable _ppsCustomerCode  
        /// </summary>
        private string _ppsCustomerCode;
        /// <summary>
        /// Get or Set for {PPSCustomerCode}.
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string PPSCustomerCode
        {
            get => _ppsCustomerCode;
            set => SetProperty(ref _ppsCustomerCode, value);
        }

        /// <summary>
        /// Local variable _ppsCarModel  
        /// </summary>
        private string _ppsCarModel;
        /// <summary>
        /// Get or Set for {PPSCarModel}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string PPSCarModel
        {
            get => _ppsCarModel;
            set => SetProperty(ref _ppsCarModel, value);
        }

        /// <summary>
        /// Local variable _ppsFacility  
        /// </summary>
        private string _ppsFacility;
        /// <summary>
        /// Get or Set for {PPSFacility}.
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string PPSFacility
        {
            get => _ppsFacility;
            set => SetProperty(ref _ppsFacility, value);
        }

        



    }
}
