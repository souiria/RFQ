using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IH1ToCPDSynchronization : IService
    {
        Task<string> H1ToCPDDataSynchronization();
        //Task<IEnumerable<H1ToCPDMaterialDataSyncModel>> H1ToCPDMaterialAssociationDataSync(List<H1ToCPDMaterialAssociationModel> listH1ToCPDMaterialAssociationModel);
        //Task<IEnumerable<H1ToCPDMaterialDataSyncModel>> H1ToCPDMaterialMasterDataSync(List<H1ToCPDMaterialModel> listH1ToCPDMaterial);

        //Task<IEnumerable<H1ToCPDBusinessUnitDataSyncModel>> H1ToCPDBusinessUnitDataSync(List<H1ToCPDBusinessUnitModel> listBusinessUnitModel);

        //Task<IEnumerable<H1ToCPDCommodityDataSyncModel>> H1ToCPDCommodityDataSync(List<H1ToCPDCommodityModel> listCommodityModel);

        //Task<IEnumerable<H1ToCPDIncotermsDataSyncModel>> H1ToCPDIncotermsDataSync(List<H1ToCPDIncotermsModel> listIncotermsModel);

        //Task<IEnumerable<H1ToCPDPOPriceEffectiveDateTypeDataSyncModel>> H1ToCPDPOPriceEffectiveDateTypeDataSync(List<H1ToCPDPOPriceEffectiveDateTypeModel> listCommodityModel);

        //Task<IEnumerable<H1ToCPDEPOCommodityGroupDataSyncModel>> H1ToCPDEPOCommodityGroupDataSync(List<H1ToCPDEPOCommodityGroupModel> listIncotermsModel);

        //Task<IEnumerable<H1ToCPDUnitOfMeasureDataSyncModel>> H1ToCPDUnitOfMeasureDataItemSync(List<H1ToCPDUnitOfMeasureModel> listH1ToCPDUnitOfMeasureDataSyncModel);

        //Task<IEnumerable<H1ToCPDContactDataSyncModel>> H1ToCPDContactDataItemSync(List<H1ToCPDContactModel> listContactModel);

        //Task<IEnumerable<H1ToCPDCurrencyDataSyncModel>> H1ToCPDCurrencyDataSync(List<H1ToCPDCurrencyModel> listCurrencyModel);

        //Task<IEnumerable<H1ToCPDPOPriceTypeDataSyncModel>> H1ToCPDPOPriceTypeDataSync(List<H1ToCPDPOPriceTypeModel> listPOPriceTypeModel);

        //Task<IEnumerable<PurchasingSupplierMaterialModel>> H1ToCPDSupplierMaterialDataSync(List<H1ToCPDSupplierMaterialModel> listSupplierMaterialModel);

        //Task<IEnumerable<H1ToCPDSupplierMaterialPOPricingDataSyncModel>> H1ToCPDSupplierMaterialPOPricingDataSync(List<H1ToCPDSupplierMaterialPOPricingModel> listSupplierMaterialPOPricingModel);

        //Task<IEnumerable<H1ToCPDSupplierSelectionDataSyncModel>> H1ToCPDSupplierSelectionDataSync(List<H1ToCPDSupplierSelectionModel> listSupplierSelectionModel);

        //Task<IEnumerable<H1ToCPDSupplierDataSyncModel>> H1ToCPDSupplierAssociationDataSync(List<H1ToCPDSupplierAssociationModel> listH1ToCPDSupplierAssociationModel);

        //Task<IEnumerable<H1ToCPDSupplierDataSyncModel>> H1ToCPDSupplierDataSync(List<H1ToCPDSupplierModel> listH1ToCPDSupplierModel);

        //Task<IEnumerable<H1ToCPDSupplierDataSyncModel>> H1ToCPDPurchasingSupplierDataSync(List<H1ToCPDPurchasingSupplierModel> listH1ToCPDPurchasingSupplierModel);

        //Task<IEnumerable<MaterialOriginModel>> H1ToCPDMaterialOriginDataSync(List<H1ToCPDMaterialOriginDataSyncModel> _lstH1ToCPDMaterialOriginDataSyncModel);

    }
}
