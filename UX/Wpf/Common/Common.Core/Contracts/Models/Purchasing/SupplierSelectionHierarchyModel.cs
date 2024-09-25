using Common.Core.Contracts.Interfaces.Purchasing;
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class SupplierSelectionHierarchyModel : BaseModel<Guid>, ISupplierSelectionHierarchy
    {
        private Guid _businessUnitGuid;
        [DataMember]
        [Required]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }
        private int _transitLeadTime;
        [DataMember]
        [Required]
        public int TransitLeadTime
        {
            get => _transitLeadTime;
            set => SetProperty(ref _transitLeadTime, value);
        }

        private DateTime _effectiveDate;
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => SetProperty(ref _effectiveDate, value);
        }

    }
}
