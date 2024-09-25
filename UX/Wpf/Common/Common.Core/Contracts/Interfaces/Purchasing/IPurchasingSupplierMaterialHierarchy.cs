using Common.Core.Contracts.Models.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Interfaces.Purchasing
{
    public interface IPurchasingSupplierMaterialHierarchy : IBaseHierarchy<Guid>
    {
        string SupplierCode { get; set; }
        bool IsFCExists { get; set; }
        int ContainerQuantity { get; set; }
        int ConversionFactor { get; set; }
        Guid CountryRegionsAssociationGuid { get; set; }
        string EUPreferentialOriginStatusCode { get; set; }
        DateTime ExpiryDate { get; set; }
        decimal FullBoxWeight { get; set; }
        int InitialVolumeQuantity { get; set; }
        int InnerContainerQuantity { get; set; }
        bool IsActive { get; set; }
        int IssueMinimumLot { get; set; }
        bool MatSuppMainSupplier { get; set; }
        decimal MetalRate { get; set; }
        decimal MetalWeight { get; set; }
        int MinimumOrderQuantity { get; set; }
        int NoOfInnerContainers { get; set; }
        int OrderLeadTime { get; set; }
        decimal POPrice { get; set; }
        decimal POPriceExcludingMetal { get; set; }
        string ReplacementMaterialNumber { get; set; }
        decimal StandardBoxHeight { get; set; }
        decimal StandardBoxLength { get; set; }
        decimal StandardBoxWidth { get; set; }
        int StandardPackFactor { get; set; }
        string SupplierMaterialName { get; set; }
        string SupplierMaterialNumber { get; set; }
        Guid TariffCodeGuid { get; set; }
        Guid UnitOfMeasurementGuid { get; set; }
        List<SupplierMaterialPOPricingHierarchyModel> SupplierMaterialPOPricingHierarchy { get; set; }
        List<SupplierSelectionHierarchyModel> SupplierSelectionHierarchy { get; set; }

    }
}
