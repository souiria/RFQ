using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("CavityMapping")]
    public class CavityMappingModel : BaseModel<Guid>
    {
        private string _cavityMapping;
        [DataMember]
        public string CavityMapping
        {
            get => _cavityMapping;
            set => SetProperty(ref _cavityMapping, value);
        }
    }
}
