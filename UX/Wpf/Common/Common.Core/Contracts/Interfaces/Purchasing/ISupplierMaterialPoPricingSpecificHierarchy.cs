using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Interfaces.Purchasing
{
    public interface ISupplierMaterialPoPricingSpecificHierarchy
    {

        string Approved { get; set; }
        DateTime ApprovedDate { get; set; }
        DateTime EffectiveFromDate { get; set; }
        bool IsActive { get; set; }
        decimal MetalRate { get; set; }
        decimal MetalWeight { get; set; }
        decimal POPrice { get; set; }
        decimal POPriceExcludingMetal { get; set; }
        string PriceChangeNotification { get; set; }
        Guid PriceTypeGuid { get; set; }
        int RecordEntryID { get; set; }
    }
}
