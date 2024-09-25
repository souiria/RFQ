using Common.Core.Contracts.Models.Core.Filtering;
using Common.UX.Api.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Api.Commercial
{
    public interface IServiceNonstatic
    {
        Task<IEnumerable<T>> ProcessOperation<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null);
        Task ProcessOperation(ServiceEndpointRoutes serviceRoute, IEnumerable<object> items, string parameters = null);
        Task<T> Post<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null);
        Task Post(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null);
        Task<List<T>> GetAll<T>(ServiceEndpointRoutes serviceRoute, string parameters = null);
        Task<IEnumerable<T>> GetAllSecureAsync<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<Guid> guidIdentites, string parameters = null);
        Task<IEnumerable<T>> GetByFilter<T>(ServiceEndpointRoutes serviceRoute, IEnumerable<FilterCollectionModel> filters, string parameters = null);
        Task<T> Get<T>(ServiceEndpointRoutes serviceRoute, string parameters = null);
        Task<T> Update<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null);
        Task Update(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null);
        Task<T> Delete<T>(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null);
        Task Delete(ServiceEndpointRoutes serviceRoute, object item = null, string parameters = null);

    }
}
