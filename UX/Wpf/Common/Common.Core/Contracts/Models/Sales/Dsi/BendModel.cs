using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("Bend")]
    public class BendModel : BaseModel<Guid>
    {
        private string _bend;
        [DataMember]
        public string Bend
        {
            get => _bend;
            set => SetProperty(ref _bend, value);
        }
    }
}
