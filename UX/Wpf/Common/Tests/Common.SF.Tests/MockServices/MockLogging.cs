using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Core.Logging;

namespace Common.SF.Tests.MockServices
{
    internal class MockLogging : ILogging
    {
        public bool ExceptionReceived { get; private set; }
        public bool ProcessAuditsCalled { get; private set; }
        public async Task<byte[]> GetAllErrors()
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetError(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task ProcessErrors(byte[] objData)
        {
            ExceptionReceived = true;
        }

        public async Task<byte[]> GetAllAudits()
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetAudit(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task ProcessAudits(byte[] objData)
        {
            ProcessAuditsCalled = true;
        }

        public async Task<byte[]> GetAllByModelName(byte[] auditTrailSearchModel)
        {
            throw new NotImplementedException();
        }

        public Task ProcessNPRStageChangeLog(byte[] objData)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> DisplayJsoxAuditReportData()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> DisplayJsoxAuditH1UsersScreenPermission()
        {
            throw new NotImplementedException();
        }
    }
}
