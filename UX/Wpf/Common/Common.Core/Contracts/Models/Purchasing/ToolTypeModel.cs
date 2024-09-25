/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ToolTypeModel.cs
Function           :   
Created By         :  Dharmendra Kumar
Created on         :  21-Sep-2022
Revision History   :   
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ToolTypeModel : BaseModel<Guid>
    {
        private string _toolType;
        [DataMember]
        [StringLength(200)]
        public string ToolType
        {
            get => _toolType;
            set => SetProperty(ref _toolType, value);
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
