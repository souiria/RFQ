using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Base;
using Common.Core.Contracts.Models.Core.Notifications;
using Common.SF.Contracts.Interfaces.Core.Notifications;

namespace Common.SF.Tests.MockServices
{
    public class MockNotifications : INotifications
    {
        public CrudOperationType? CreateCrudChannelsWasCalled = null;
        public async Task ProcessChannels(byte[] objData)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetAllChannels()
        {
            throw new NotImplementedException();
        }

        public async Task CreateCrudChannels(string serviceName, CrudOperationType operation)
        {
            CreateCrudChannelsWasCalled = operation;
        }

        public async Task EnqueueNotification(Notification notification)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetRedisEndpoint()
        {
            throw new NotImplementedException();
        }
    }
}
