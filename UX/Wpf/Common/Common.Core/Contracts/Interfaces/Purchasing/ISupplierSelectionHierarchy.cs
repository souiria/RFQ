using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Interfaces.Purchasing
{
    public interface ISupplierSelectionHierarchy : IBaseHierarchy<Guid>
    {
        Guid BusinessUnitGuid { get; set; }
        DateTime EffectiveDate { get; set; }
        int TransitLeadTime { get; set; }

    }
}
