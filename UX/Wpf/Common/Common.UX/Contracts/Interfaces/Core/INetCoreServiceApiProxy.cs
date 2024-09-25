/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   INetCoreServiceApiProxy.cs
Function           :   Net Core Proxy for Service Helper functionalities
Created By         :   Amit
Created on         :   12-Feb-2020
Revision History   :   [30-Mar-2020] : Srashti Gupta
*                  :   Added proxy for PostAndGet.
*                  :   [03-May-2020] : Amit
                   :   [] : Added the endpoints IsExistsWithFiltersByPartition()
                   :   [16-Oct-2020] : Srashti Gupta
                   :   [] : Added the endpoints GetAll()
*                  :   [20-July-2022] : Sejal Srivastava
*                  :   [] : Added the endpoints PostAndGetDataTable()
****************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.UX.Api.Endpoints;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.UX.Contracts.Interfaces.Core
{
    public interface INetCoreServiceApiProxy
    {
        Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null);
        Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null);
        Task<List<T>> GetAll<T>(string serviceRoute, object parameters = null);
        Task<List<T>> GetAllFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, string parameters = null,List<string> fields = null);
        Task<List<T>> GetAllAsync<T>(ServiceEndpointRoutes serviceRoute, string parameters = null);
        Task<List<T>> GetAllAsyncFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, List<string> fields = null);
        Task<List<T>> GetFieldsSelectorWithFilterByDictionary<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, FiltersSpecificModel filtersSpecifics = null);
        Task<List<T>> GetSpecificFieldsAsyncByFilter<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, FiltersSpecificModel filtersSpecifics=null);
        Task<bool> IsExistsWithFiltersByPartition(ServiceEndpointRoutes serviceRoute, List<SpecificDataFilteringModel> filterslist = null);
        Task<IEnumerable<T>> PostAndGet<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null);
        Task<string> PostAndGetDataTable<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null);
    }
}
