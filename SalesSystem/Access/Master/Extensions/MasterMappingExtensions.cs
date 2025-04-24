using Master.Data.Model;
using Master.DTOs;

namespace Master.Extensions
{
    public static class MasterMappingExtensions
    {
        #region Currency

        public static CurrencyDto MapToCurrencyDto(this DbCurrency entity)
        {
            return new CurrencyDto
            {
                Id = entity.Id,
                CurrencyCode = entity.CurrencyCode,
                CurrencyName = entity.CurrencyName,
                EuroRate = entity.EuroRate,
                IsActive = entity.IsActive
            };
        }

        #endregion
    }
}
