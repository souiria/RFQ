using Common.Core.Contracts.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Interfaces.GlobalMasters
{
    public interface IMaterialHierarchy : IBaseHierarchy<Guid>
    {
        Guid CommodityGuid { get; set; }
        decimal CutLength { get; set; }
        bool IsCustomerNominatedMaterial { get; set; }
        string MaterialName { get; set; }
        string MaterialNumber { get; set; }
        Guid MaterialTypeGuid { get; set; }
        string PreProductionNumber { get; set; }
        Guid SourceApplicationGuid { get; set; }
        Guid UnitOfMeasureGuid { get; set; }
        decimal UnitWeight { get; set; }
        List<PurchasingSupplierMaterialHierarchyModel> PurchasingSupplierMaterialHierarchy { get; set; }
    }
}