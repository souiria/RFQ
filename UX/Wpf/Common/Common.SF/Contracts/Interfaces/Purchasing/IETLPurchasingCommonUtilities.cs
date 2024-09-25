using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface IETLPurchasingCommonUtilities : IService
    {
        //Task<string> GetMaterialList();
        //Task<string> GetCommodityList();
        //Task<string> GetMaterialTypeList();
        //Task<string> GetCurrencyList();
        //Task<string> GetContactList();
        //Task<string> GetCountryList();
        //Task<string> GetEPOCommodityGroupList();
        //Task<string> GetIncotermsList();
        //Task<string> GetPaymentTermsList();
        //Task<string> GetPOPriceTypeList();
        //Task<string> GetPOPriceEffectiveList();
        //Task<string> GetPurchasingSupplierMaterialList();
        //Task<string> GetSupplierAssociationList();
        //Task<string> GetSupplierDevelopmentTeamList();
        //Task<string> GetSupplierGroupList();
        //Task<string> GetSupplierMaterialAssociationList();
        //Task<string> GetSupplierMaterialPOPricingList();
        //Task<string> GetSupplierSupplierCountryAssociationList();
        //Task<string> GetSupplierTypeList();
        //Task<string> GetTariffContentEmailList();
        //Task<string> GetMaterialAssociationList();
        //Task<string> GetAllSupplierMaterialAssociationList();
        //Task<string> GetActiveSupplierMatAssociationList();
        //Task<string> GetSupplierMatAssociationList();
        //Task<string> GetHeaderSupplierList();
        //Task<string> GetHeaderMaterialList();
        //Task<string> GetCustomerDataList();
        //Task<string> GetVehicleDataList();
        //Task<string> GetFacilityDataList();
        //Task<string> GetUnitOfMeasureList();
        //Task<string> GetSupplierMaterialAssociationDataList();
        Task<string> GetSupplierList();
        Task<string> GetBusinessUnitList();
        Task<SourceApplicationArticleAssociationModel> GetApplicationArticleAssociationDetail(string sourceAppName, string articleName);
    }
}
