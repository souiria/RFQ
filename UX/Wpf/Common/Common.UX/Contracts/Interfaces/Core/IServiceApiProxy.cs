/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IServiceApiProxy.cs
Function           :   Proxy for Service Helper functionalities
Created By         :   Amit
Created on         :   07-Mar-2019
Revision History   :   [03-Oct-2019] : Srashti Gupta
*                  :   [] : Added the GetAllFieldsSelector(),GetByFilterFieldsSelector() and GetAllAsyncFieldsSelector() for proxy functionalities.
*                  :   [09-Oct-2020] : Shivam Dhingra
*                  :   [] : Added the GetAll() accepting string parameters
*                  :   [16-Oct-2020] : Srashti Gupta
*                  :   [] : Remove Added the GetAll() accepting string parameters
****************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.UX.Api.Endpoints;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.UX.Contracts.Interfaces.Core
{
    public interface IServiceApiProxy
    {
        Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null);
        Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null);
        Task<List<T>> GetAllFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, string parameters = null,List<string> fields = null);
        Task<List<T>> GetAllAsync<T>(ServiceEndpointRoutes serviceRoute, string parameters = null);
        Task<List<T>> GetAllAsyncFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, List<string> fields = null);
        Task<List<T>> GetFieldsSelectorWithFilterByDictionary<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, FiltersSpecificModel filtersSpecifics = null);
        Task<List<T>> GetSpecificFieldsAsyncByFilter<T>(ServiceEndpointRoutes serviceRoute, string parameters = null, FiltersSpecificModel filtersSpecifics=null);
        Task<IEnumerable<T>> GetByFilter<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null);
        Task<IEnumerable<T>> GetByFilterFieldsSelector<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<SpecificDataFilteringModel> filters, string parameters = null);
        Task<T> Get<T>(ServiceEndpointRoutes serviceRoute, string parameters = null);
        T Post<T>(ServiceEndpointRoutes serviceRoute, object items, string parameters = null);
        Task<T> PostByteArray<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null);
        IEnumerable<T> PostAndGet<T>(ServiceEndpointRoutes serviceRoute, object obj, string parameters = null);



    }
}
