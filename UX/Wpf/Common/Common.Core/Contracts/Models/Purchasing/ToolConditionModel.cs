/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ToolConditionModel.cs
Function           :   
Created By         :  Virendra
Created on         :  30-Sep-2022
Revision History   :   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ToolConditionModel : BaseModel<Guid>
    {
        private string _toolCondition;
        [DataMember]
        [StringLength(500)]
        public string ToolCondition
        {
            get => _toolCondition;
            set => SetProperty(ref _toolCondition, value);
        }
        private bool _isActive = true;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
