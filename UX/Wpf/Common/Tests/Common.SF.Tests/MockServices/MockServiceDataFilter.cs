using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Administration.Security.DataFilter;

namespace Common.SF.Tests.MockServices
{
    internal class MockServiceDataFilter : IDataFilter
    {
        public async Task<byte[]> GetAllDataFilters()
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetDataFilter(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetDataFiltersByFilter(byte[] objData)
        {
            throw new NotImplementedException();
        }

        public async Task ProcessDataFilters(byte[] objData)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetDataFiltersByRequest(IEnumerable<Guid> guid, string serviceUri)
        {
            throw new NotImplementedException();
        }
    }
}
