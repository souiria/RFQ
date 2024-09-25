/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EDIMessageDetailModel.cs
Function           :   EDI Message Detail Model
Created By         :   Shivam Dhingra
Created on         :   07-Apr-2020
Revision History   :   [28-Apr-2020] : Shivam Dhingra
                   :   Modified model as per the change in Tables
                   :   [01-May-2020] : Shivam Dhingra
                   :   removed Required attribute from DemandQty
                   :   [29-Jul-2022] : Shahab Ashraf
                   :   Added field IsPartMapped
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
    [DataContract, Serializable]
    public class EDIMessageDetailModel : BaseModel<Guid>
    {

        private Guid _ediMessageHeaderId;
        /// <summary>
        /// Get or Set for {EDIMessageHeaderId}.
        /// </summary>
        [DataMember]
        [Required]
        public Guid EDIMessageHeaderId
        {
            get => _ediMessageHeaderId;
            set => SetProperty(ref _ediMessageHeaderId, value);
        }

        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }


        private DateTime? _demandStartDate;
        /// <summary>
        /// This field will set DemandStartDate
        /// </summary>
        [DataMember]
        public DateTime? DemandStartDate
        {
            get => _demandStartDate;
            set => SetProperty(ref _demandStartDate, value);
        }


        private DateTime? _demandEndDate;
        /// <summary>
        /// This field will set DemandEndDate
        /// </summary>
        [DataMember]
        public DateTime? DemandEndDate
        {
            get => _demandEndDate;
            set => SetProperty(ref _demandEndDate, value);
        }


        private int? _demandQty;
        /// <summary>
        /// Get or Set for {DemandQty}.
        /// </summary>
        [DataMember]
        public int? DemandQty
        {
            get => _demandQty;
            set => SetProperty(ref _demandQty, value);
        }


        private bool _supplyChainFlag;
        /// <summary>
        /// Get or Set for {SupplyChainFlag}.
        /// </summary>
        [DataMember]
        [Required]
        public bool SupplyChainFlag
        {
            get => _supplyChainFlag;
            set => SetProperty(ref _supplyChainFlag, value);
        }


        private bool _isNewPart;
        /// <summary>
        /// Get or Set for {IsNewPart}.
        /// </summary>
        [DataMember]
        [Required]
        public bool IsNewPart
        {
            get => _isNewPart;
            set => SetProperty(ref _isNewPart, value);
        }

        private bool _isPartMapped;
        /// <summary>
        /// Get or Set for {IsAllPartMapped}.
        /// </summary>
        [DataMember]
        [Required]
        public bool IsPartMapped
        {
            get => _isPartMapped;
            set => SetProperty(ref _isPartMapped, value);
        }



    }
}

	