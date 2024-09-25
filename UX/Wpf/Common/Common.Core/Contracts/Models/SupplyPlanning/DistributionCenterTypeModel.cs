/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DistributionCenterTypeModel.cs
Function           :   Distribution Center Type
Created By         :   Shivam Dhingra
Created on         :   19-Feb-2020
Revision History   :   [19-Feb-2020]:Sai Kiran
*                  :   Removed Description Field and changed name of code field
*                  :
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
    public class DistributionCenterTypeModel : BaseModel<Guid>
    {
        private string _distributionCenterTypeName;
        /// <summary>
        /// Get or Set for {Code}.
        /// </summary>
        [DataMember]
        [Required]
        [StringLength(35)]
        public string DistributionCenterTypeName
        {
            get => _distributionCenterTypeName;
            set => SetProperty(ref _distributionCenterTypeName, value);
        }

    }
}
