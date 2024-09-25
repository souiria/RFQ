using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Sales.Dsi;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Sales.Dsi
{
    [DataContract, Serializable, Table("Scope")]
    public class ScopeModel : BaseModel<Guid>
    {
        private string _scope;
        [DataMember]
        public string Scope
        {
            get => _scope;
            set => SetProperty(ref _scope, value);
        }
    }
}
