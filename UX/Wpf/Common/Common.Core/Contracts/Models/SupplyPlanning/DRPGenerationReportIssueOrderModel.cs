/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DRPGenerationReportIssueOrderModel.cs
Function           :   DRPGenerationReport Issue Order
Created By         :   Shivam Dhingra
Created on         :   08-Jul-2021
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

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Class File for DRPGenerationReportIssueOrderModel
    /// </summary>
    [DataContract,Serializable]
    public class DRPGenerationReportIssueOrderModel : BaseModel<Guid>
    {

        private string _orderNumber;
        /// <summary>
        /// OrderNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(30)]
        public string OrderNumber
        {
            get => _orderNumber;
            set => _orderNumber = value;
        }

        private string _partNumber;
        /// <summary>
        /// PartNumber
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(35)]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

        private string _custDesc1;
        /// <summary>
        /// CustDesc1
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(4)]
        public string CustDesc1
        {
            get => _custDesc1;
            set => _custDesc1 = value;
        }

        private string _custDesc2;
        /// <summary>
        /// CustDesc2
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(2)]
        public string CustDesc2
        {
            get => _custDesc2;
            set => _custDesc2 = value;
        }

        private string _intDesc1;
        /// <summary>
        /// IntDesc1
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(2)]
        public string IntDesc1
        {
            get => _intDesc1;
            set => _intDesc1 = value;
        }

        private DateTime? _orderDueDate;
        /// <summary>
        /// OrderDueDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? OrderDueDate
        {
            get => _orderDueDate;
            set => _orderDueDate = value;
        }

        private int? _quantity;
        /// <summary>
        /// Quantity
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public int? Quantity
        {
            get => _quantity;
            set => _quantity = value;
        }

        private DateTime? _orderDate;
        /// <summary>
        /// OrderDueDate
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public DateTime? OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }
    }

    /// <summary>
    /// Class File for DRPGenerationIssueOrderParameterModel
    /// </summary>
    [DataContract,Serializable]
    public class DRPGenerationReportIssueOrderParameterModel
    {
        private string _customerCode;
        /// <summary>
        /// Get or Set for {CustomerCode}.
        /// </summary>
        [DataMember]
        [StringLength(4)]
        public string CustomerCode
        {
            get => _customerCode;
            set => _customerCode = value;
        }

        private string _option;
        /// <summary>
        /// Get or Set for {Option}.
        /// </summary>
        [DataMember]
        [StringLength(1)]
        public string Option
        {
            get => _option;
            set => _option = value;
        }

        private Guid _createdBy;
        /// <summary>
        /// Get or Set for {CreatedBy}.
        /// </summary>
        [DataMember]
        public Guid CreatedBy
        {
            get => _createdBy;
            set => _createdBy = value;
        }
    }
}
