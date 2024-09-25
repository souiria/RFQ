/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRTypeModel.cs
Function           :   NPR Type 
Created By         :   Pawan Kumar
Created on         :   13-Aug-2019
Revision History   :   [] : 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPR
{
    /// <summary>
    /// This class is used to have information about NPR Type.
    /// </summary>
    [DataContract, Serializable]
    public class NPRTypeModel :  BaseModel<Guid>
    {
        private string _nprTypeCode;
        [DataMember]
        [StringLength(20)]
        public string NPRTypeCode
        {
            get => _nprTypeCode;
            set => SetProperty(ref _nprTypeCode, value);
        }

        private string _nprTypeDescription = null;
        [DataMember]
        [StringLength(50)]
        public string NPRTypeDescription
        {
            get => _nprTypeDescription;
            set => SetProperty(ref _nprTypeDescription, value);
        }
    }
}