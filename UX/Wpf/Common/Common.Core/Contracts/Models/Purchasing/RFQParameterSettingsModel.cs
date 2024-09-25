
/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRParameterSettingsModel.cs
Function           :   Data Contracts for NPR Parameter Settings Screen
Created By         :   Srashti Gupta
Created on         :   14-Jun-2019
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

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class RFQParameterSettingsModel : BaseModel<Guid>
    {
        private string _parameterKey;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ParameterKey
        {
            get => _parameterKey;
            set => SetProperty(ref _parameterKey, value);
        }

        private string _parameterDescription;
        [DataMember]
        [Required]
        [StringLength(250)]
        public string ParameterDescription
        {
            get => _parameterDescription;
            set => SetProperty(ref _parameterDescription, value);
        }
        private string _parameterValue1;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ParameterValue1
        {
            get => _parameterValue1;
            set => SetProperty(ref _parameterValue1, value);
        }

        private string _parameterValue2;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ParameterValue2
        {
            get => _parameterValue2;
            set => SetProperty(ref _parameterValue2, value);
        }
        private string _parameterValue3;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ParameterValue3
        {
            get => _parameterValue3;
            set => SetProperty(ref _parameterValue3, value);
        }
        private string _parameterValue4;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ParameterValue4
        {
            get => _parameterValue4;
            set => SetProperty(ref _parameterValue4, value);
        }
        private string _parameterValue5;
        [DataMember]
        [Required]
        [StringLength(100)]
        public string ParameterValue5
        {
            get => _parameterValue5;
            set => SetProperty(ref _parameterValue5, value);
        }

    }
}

