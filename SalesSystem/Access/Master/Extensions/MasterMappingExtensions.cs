using Master.Data.DTOs;
using Master.Data.Model;

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

        #region Customer

        public static CustomerBusinessHierarchyDto MapToCustomerBusinessHierarchyDto(this DbCustomerBusinessHierarchy entity)
        {
            return new CustomerBusinessHierarchyDto
            {
                Id = entity.Id,
                CustomerBusinessGroupCode = entity.CustomerBusinessGroupCode,
                CustomerBusinessGroupName = entity.CustomerBusinessGroupName,
                SEWSEBusinessTeam = entity.SEWSEBusinessTeam
            };
        }

        public static CustomerHierarchyDto MapToCustomerHierarchyDto(this DbCustomerHierarchy entity)
        {
            return new CustomerHierarchyDto
            {
                Id = entity.Id,
                CustomerCode = entity.CustomerCode,
                CustomerName = entity.CustomerName,
                StreetNumber = entity.StreetNumber,
                StreetName = entity.StreetName,
                City = entity.City,
                Region = entity.Region,
                ZipCode = entity.ZipCode,
                Country = entity.Country,
                CustomerBusinessType = entity.CustomerBusinessType,
                IndexedMaterial = entity.IndexedMaterial,
                CustomerBusinessHierarchyGuid = entity.CustomerBusinessHierarchyGuid,
                CustomerBusinessQualityManagerName = entity.CustomerBusinessQualityManagerName,
                CustomerCountryGuid = entity.CustomerCountryGuid
            };
        }

        public static CustomerProjectAssociationDto MapToCustomerProjectAssociationDto(this DbCustomerProjectAssociation entity)
        {
            return new CustomerProjectAssociationDto
            {
                Id = entity.Id,
                CustomerLocationGuid = entity.CustomerGuid,
                ProjectGuid = entity.ProjectGuid
            };
        }

        #endregion
    }
}
