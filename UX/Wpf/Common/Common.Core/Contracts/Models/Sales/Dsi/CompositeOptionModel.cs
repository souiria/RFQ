using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("CompositeOption")]
    public class CompositeOptionModel : BaseModel<Guid>
    {
        private string _optionName;
        [DataMember]
        public string OptionName
        {
            get => _optionName;
            set => SetProperty(ref _optionName, value);
        }

        private string _description;
        [DataMember]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private Guid _harnessID;
        [DataMember]
        public Guid HarnessID
        {
            get => _harnessID;
            set => SetProperty(ref _harnessID, value);
        }
    }
}
