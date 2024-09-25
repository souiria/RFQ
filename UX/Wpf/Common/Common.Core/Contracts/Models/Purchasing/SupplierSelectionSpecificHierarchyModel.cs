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
    public class SupplierSelectionSpecificHierarchyModel :  ISupplierSelectionSpecificHierarchy
    {
        private Guid _businessUnitCode;
        [DataMember]
        [Required]
        public Guid BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }
        private int _transitLeadTime;
        [DataMember]
        [Required]
        public int TransitLeadTime
        {
            get => _transitLeadTime;
            set => _transitLeadTime = value;
        }

        private DateTime _effectiveDate;
        [DataMember]
        public DateTime EffectiveDate
        {
            get => _effectiveDate;
            set => _effectiveDate = value;
        }

    }
}
