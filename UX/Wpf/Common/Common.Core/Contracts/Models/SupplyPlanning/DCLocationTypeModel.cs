/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DCLocationTypeModel.cs
Function           :   DCLocationTypeModel 
Created By         :  Virendra
Created on         :   07-Oct-2022
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
    [DataContract, Serializable]
    public class DCLocationTypeModel : BaseModel<Guid>
    {
        private Guid _locationTypeGuid;
        /// <summary>
        /// Get or Set for {LocationTypeGuid}.
        /// </summary>
        [DataMember]
        public Guid LocationTypeGuid
        {
            get => _locationTypeGuid;
            set => SetProperty(ref _locationTypeGuid, value);
        }
        private Guid _dCLocationGuid;
        /// <summary>
        /// Get or Set for {DCLocationGuid}.
        /// </summary>
        [DataMember]
        public Guid DCLocationGuid
        {
            get => _dCLocationGuid;
            set => SetProperty(ref _dCLocationGuid, value);
        }

        private string _type_CD;
        /// <summary>
        /// Get or Set for {Type_CD}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(10)]
        public string Type_CD
        {
            get => _type_CD;
            set => SetProperty(ref _type_CD, value);
        }
        private string _type_Desc;
        /// <summary>
        /// Get or Set for {Type_Desc}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(200)]
        public string Type_Desc
        {
            get => _type_Desc;
            set => SetProperty(ref _type_Desc, value);
        }

    }
}
