using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("ManualBomQuantity")]
    public class ManualBomQuantityModel : BaseModel<Guid>
    {
        private string _splitValue;
        [DataMember]
        public string SplitValue
        {
            get => _splitValue;
            set => SetProperty(ref _splitValue, value);
        }

        private string _moduleCode;
        [DataMember]
        public string ModuleCode
        {
            get => _moduleCode;
            set => SetProperty(ref _moduleCode, value);
        }

        private double _percentage;
        [DataMember]
        public double Percentage
        {
            get => _percentage;
            set => SetProperty(ref _percentage, value);
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
