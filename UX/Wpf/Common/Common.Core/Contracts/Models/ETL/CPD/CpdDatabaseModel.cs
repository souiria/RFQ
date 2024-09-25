using Common.Core.Contracts.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ETL.CPD
{
    [DataContract, NotMapped]
    public class CpdDatabaseModel : ExternalDataSourceModel<object>
    {
        private IEnumerable<InterfaceWHCPDMastersMaterialSupplierModel> _supplierList;
        [DataMember, NotMapped]
        public IEnumerable<InterfaceWHCPDMastersMaterialSupplierModel> SupplierList { get => _supplierList; set => SetProperty(ref _supplierList, value); }

        private IEnumerable<InterfaceWHCPDMastersMaterialOriginModel> _materialList;
        [DataMember, NotMapped]
        public IEnumerable<InterfaceWHCPDMastersMaterialOriginModel> MaterialList { get => _materialList; set => SetProperty(ref _materialList, value); }
    }
}
