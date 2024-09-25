/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   WeeklyDemandSplitLogicModel.cs
Function           :   WeeklyDemandSplitLogic
Created By         :   Shivam Dhingra
Created on         :   24-Sep-2020
Revision History   :   [24-Sep-2020] : Shivam Dhingra
                   :   Added new field EDIMessageTypeCode 
                   :   
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
    /// DataContract for WeeklyDemandSplitLogicModel
    /// </summary>
    [DataContract, Serializable]
    public class WeeklyDemandSplitLogicModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _customerBusinessGroupGuid     
        /// </summary>
        private Guid _customerBusinessGroupGuid;
        /// <summary>
        /// Get or Set for {CustomerBusinessGroupGuid}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerBusinessGroupGuid
        {
            get => _customerBusinessGroupGuid;
            set => SetProperty(ref _customerBusinessGroupGuid, value);
        }

        /// <summary>
        /// Local variable _columnIdentificationForWeeklySplit     
        /// </summary>
        private string _columnIdentificationForWeeklySplit;
        /// <summary>
        /// Get or Set for {ColumnIdentificationForWeeklySplit}.
        /// </summary>
        /// <example>
        /// 
        /// </example>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ColumnIdentificationForWeeklySplit
        {
            get => _columnIdentificationForWeeklySplit;
            set => SetProperty(ref _columnIdentificationForWeeklySplit, value);
        }

        /// <summary>
        /// Local variable _columnValueForWeeklySplit
        /// </summary>
        private string _columnValueForWeeklySplit;
        /// <summary>
        /// Get or Set for {ColumnValueForWeeklySplit}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(1)]
        public string ColumnValueForWeeklySplit
        {
            get => _columnValueForWeeklySplit;
            set => SetProperty(ref _columnValueForWeeklySplit, value);
        }

        /// <summary>
        /// Local variable _dateSplitIdentificationColumn
        /// </summary>
        private string _dateSplitIdentificationColumn;
        /// <summary>
        /// Get or Set for {DateSplitIdentificationColumn}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string DateSplitIdentificationColumn
        {
            get => _dateSplitIdentificationColumn;
            set => SetProperty(ref _dateSplitIdentificationColumn, value);
        }

        /// <summary>
        /// Local variable _quantitySplitIdentificationColumn
        /// </summary>
        private string _quantitySplitIdentificationColumn;
        /// <summary>
        /// Get or Set for {QuantitySplitIdentificationColumn}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string QuantitySplitIdentificationColumn
        {
            get => _quantitySplitIdentificationColumn;
            set => SetProperty(ref _quantitySplitIdentificationColumn, value);
        }

        /// <summary>
        /// Local variable _splitInCustomerWorkingDays
        /// </summary>
        private bool _splitInCustomerWorkingDays;
        /// <summary>
        /// Get or set for {SplitInCustomerWorkingDays}
        /// </summary>
        [DataMember]
        [Required]
        public bool SplitInCustomerWorkingDays
        {
            get => _splitInCustomerWorkingDays;
            set => SetProperty(ref _splitInCustomerWorkingDays, value);
        }

        private string _ediMessageTypeCode;
        /// <summary>
        /// Get or Set for {EDIMessageTypeCode}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(6)]
        public string EDIMessageTypeCode
        {
            get => _ediMessageTypeCode;
            set => SetProperty(ref _ediMessageTypeCode, value);
        }
    }
}
