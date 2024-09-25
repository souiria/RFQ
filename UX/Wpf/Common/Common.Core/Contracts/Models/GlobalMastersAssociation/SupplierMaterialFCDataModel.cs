using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    [DataContract]
    public class SupplierMaterialFCDataModel:BaseModel<Guid>
    {
        [DataMember]
        public string supplier_c { get; set; }
        [DataMember]
        public string Material_no { get; set; }
    }
}
