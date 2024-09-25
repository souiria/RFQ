using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Security;
using Common.SF.Contracts.Models.Core.Proxy;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Security
{
    [ServiceContract]
    public interface IActiveDirectory : IService
    {
        [OperationContract]
        Task ForceUserRetrieval();

        [OperationContract]
        Task<byte[]> PullUserList(Range partitionRange);

        [OperationContract]
        Task<IEnumerable<ActiveDirectoryGroupModel>> GetAllH1UserGroups();

        [OperationContract]
        Task<byte[]> GetH1UserGroup(Guid id);

        [OperationContract]
        Task<IEnumerable<ActiveDirectoryGroupModel>> GetUserGroups(Guid id, bool recursive);

        [OperationContract]
        Task<ActiveDirectoryAccountModel> GetUserByGuid(Guid guid);

        [OperationContract]
        Task<ActiveDirectoryAccountModel> GetUserByUsername(string username);

        [OperationContract]
        Task AddUserToGroup(string groupName, Guid userGuid);

        [OperationContract]
        Task RemoveUserFromGroup(string groupName, Guid userGuid);

        [OperationContract]
        Task<bool> IsH1User(Guid userGuid);

        //[OperationContract]
        //Task<IEnumerable<ActiveDirectoryGroupModel>> GetHarnessOneAdGroupsByUserGuid(Guid userGuid);
        //[OperationContract]
        //Task<IEnumerable<ActiveDirectoryGroupModel>> GetHarnessOneAdGroupsByUsername(string username);
        //[OperationContract]
        //Task<ActiveDirectoryAccountModel> GetAdUserByUsername(string username);
        //[OperationContract]
        //Task<ActiveDirectoryAccountModel> GetAdUserByGuid(Guid guid);
        //[OperationContract]
        //Task<bool> AddUserToHarnessOneAdGroupByGuid(string groupName, Guid userGuid);
        //[OperationContract]
        //Task<bool> AddUserToHarnessOneAdGroupByUsername(string groupName, string username);
        //[OperationContract]
        //Task<IEnumerable<ActiveDirectoryAccountModel>> GetGroupMembers(string groupname, bool recursive);
        //[OperationContract]
        //Task<string> GetAllDomainUsers();
        //[OperationContract]
        //Task<IEnumerable<ActiveDirectoryGroupModel>> GetAllH1UserGroups();
        //[OperationContract]
        //Task<IEnumerable<ActiveDirectoryGroupModel>> GetAllH1UserGroupsByUserGuid(Guid id);
        //[OperationContract]
        //Task<IEnumerable<ActiveDirectoryAccountModel>> GetLeavers();
        //[OperationContract]
        //Task<bool> RemoveUserFromHarnessOneAdGroupByGuid(string groupName, Guid userGuid);
        //[OperationContract]
        //Task<bool> RemoveUserFromHarnessOneAdGroupByUsername(string groupName, string username);
    }
}
