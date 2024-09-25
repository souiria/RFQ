using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Base
{
    [DataContract, Serializable]
    public abstract  class BaseSystemParameterSettings : BaseModel<Guid>
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
        [StringLength(250)]
        public string ParameterDescription
        {
            get => _parameterDescription;
            set => SetProperty(ref _parameterDescription, value);
        }
        private string _parameterValue1;
        [DataMember]
        [StringLength(100)]
        public string ParameterValue1
        {
            get => _parameterValue1;
            set => SetProperty(ref _parameterValue1, value);
        }

        private string _parameterValue2;
        [DataMember]
        [StringLength(100)]
        public string ParameterValue2
        {
            get => _parameterValue2;
            set => SetProperty(ref _parameterValue2, value);
        }
        private string _parameterValue3;
        [DataMember]
        [StringLength(100)]
        public string ParameterValue3
        {
            get => _parameterValue3;
            set => SetProperty(ref _parameterValue3, value);
        }
        private string _parameterValue4;
        [DataMember]
        [StringLength(100)]
        public string ParameterValue4
        {
            get => _parameterValue4;
            set => SetProperty(ref _parameterValue4, value);
        }
        private string _parameterValue5;
        [DataMember]
        [StringLength(100)]
        public string ParameterValue5
        {
            get => _parameterValue5;
            set => SetProperty(ref _parameterValue5, value);
        }

    }
}
