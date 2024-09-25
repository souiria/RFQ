using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("CircuitOption")]
    public class CircuitOptionModel : BaseModel<Guid>
    {
        private string _optionName;
        [DataMember]
        public string OptionName
        {
            get => _optionName;
            set => SetProperty(ref _optionName, value);
        }
    }
}
