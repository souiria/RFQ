using Common.Core.Contracts.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.NPA
{
    [DataContract, NotMapped]
    public class NpaDatabaseModel : ExternalDataSourceModel<object>
    {
        private IEnumerable<InterfaceWHNPAMaterialPriceModel> _materialList;
        [DataMember, NotMapped]
        public IEnumerable<InterfaceWHNPAMaterialPriceModel> MaterialList { get => _materialList; set => SetProperty(ref _materialList, value); }
    }
}
