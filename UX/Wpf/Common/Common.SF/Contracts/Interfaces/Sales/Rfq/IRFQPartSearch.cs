using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Settings;
using Common.Core.Contracts.Models.Sales.Rfq;
using Common.SF.Contracts.Models.Sales.Rfq;
using Microsoft.ServiceFabric.Actors;

namespace Common.SF.Contracts.Interfaces.Sales.Rfq
{
    public interface IRFQPartSearch : IActor
    {
        Task<IEnumerable<RFQPartSearchProcedureModel>> GetEmacsSumitomo(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<RFQPartSearchProcedureModel>> GetEmacsCustomer(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<RFQPartSearchProcedureModel>> GetEmacsSupplier(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<CustomerCodeModel>> GetEmacsDefaultCustomerCode(IEnumerable<string> sumitomoNumbers, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<CustomerCodeModel>> GetEmacsCustomerCodes(IEnumerable<string> sumitomoNumbers, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<CustomerMasterData>> GetEmacsCustomerMaster(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<SupplierNumberModel>> GetEmacsSupplierNumber(IEnumerable<string> sumitomoNumber, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<RFQPartSearchProcedureModel>> GetNpaSupplierPrice(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<RFQPartSearchProcedureModel>> GetNpaCustomerPrice(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<NpaMasterData>> GetNpaCustomerMaster(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<NpaMasterData>> GetNpaSupplierMaster(Dictionary<string, int> partList, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<RFQSupplierModel>> GetCpdMaterialSupplier(IEnumerable<string> sumitomoNumber, H1ServiceConfigurationSettingModel settings);
        Task<IEnumerable<NpaMaterialOriginModel>> GetCpdMaterialOrigin(IEnumerable<string> sumitomoNumber, H1ServiceConfigurationSettingModel settings);
    }
}
