/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ManufacturingProcessEquipmentModel.cs
Function           :   Data contract for ManufacturingProcessEquipmentModel
Created By         :   Amit Agarwal
Created on         :   30-Jan-2020
Revision History   :   [04-Mar-2020] : Srashti Gupta
*                  :   Modified the Class Name in Revision History.
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class ManufacturingProcessEquipmentModel : BaseModel<Guid>
    {
        private string _manufacturingProcessEquipmentName;
        /// <summary>
        /// Get or Set for {ManufacturingProcessEquipmentName}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ManufacturingProcessEquipmentName
        {
            get => _manufacturingProcessEquipmentName;
            set => SetProperty(ref _manufacturingProcessEquipmentName, value);
        }

        private string _manufacturingProcessEquipmentType;
        /// <summary>
        /// Get or Set for {ManufacturingProcessEquipmentType}
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(50)]
        public string ManufacturingProcessEquipmentType
        {
            get => _manufacturingProcessEquipmentType;
            set => SetProperty(ref _manufacturingProcessEquipmentType, value);
        }
       
        private Guid _parentId;
        /// <summary>
        /// Get or Set for {ParentId}
        /// </summary>
        [DataMember]
        [Required]
        
        public Guid ParentId
        {
            get => _parentId;
            set => SetProperty(ref _parentId, value);
        }
    }
}
