using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Security;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Security
{
    /// <summary>
    /// An interface the encapsulate all the public method for the Security service.
    /// </summary>
    public interface ISecurity : IService, IUserList, IMenu, ISecurityAudit
    {
        /// <summary>
        /// Adds a user, specified by their active directory guid, to a group with the provided name.
        /// </summary>
        /// <param name="groupName">The name of the group to add the user to.</param>
        /// <param name="userGuid">The active directory guid of the user.</param>
        /// <returns></returns>
        Task AddUserToGroup(string groupName, Guid userGuid);

        /// <summary>
        /// Removes a user, specified by their active directory guid, from a group with the provided name.
        /// </summary>
        /// <param name="groupName">The name of the group to remove the user from.</param>
        /// <param name="userGuid">The active directory guid of the user.</param>
        /// <returns></returns>
        Task RemoveUserFromGroup(string groupName, Guid userGuid);

        /// <summary>
        /// Gets all the groups in the 'H1 Users Groups' organisational unit in active directory.
        /// </summary>
        /// <param name="recursive">Whether each group should return the groups they are a part of.</param>
        /// <returns>A list of the <see cref="Group"/>s compressed.</returns>
        Task<byte[]> GetAllH1UserGroups(bool recursive);

        /// <summary>
        /// Gets the group with a matching active directory guid from active directory.
        /// </summary>
        /// <param name="id">The active directory guid of the group.</param>
        /// <param name="recursive">Whether the group should return the groups it is a part of.</param>
        /// <returns>The requested group compressed.</returns>
        Task<byte[]> GetGroup(Guid id, bool recursive);

        /// <summary>
        /// Gets all the groups that a specified user is a member of. This includes roles from 'H1 User Groups'.
        /// </summary>
        /// <param name="id">The active directory guid of the user.</param>
        /// <param name="recursive">Whether each group should return the groups they are a part of.</param>
        /// <returns>A list of the users groups compressed.</returns>
        Task<byte[]> GetUserGroups(Guid id, bool recursive);

        /// <summary>
        /// Determines whether a user is a member of any of the groups within Harness One.
        /// </summary>
        /// <param name="userGuid">The active directory guid of the user</param>
        /// <returns>If the user is a user of Harness One.</returns>
        Task<bool> IsH1User(Guid userGuid);

        /// <summary>
        /// Forces the service to immediately get a fresh list from active directory. If the service is already in the process of refreshing, it will do nothing.
        /// </summary>
        /// <returns></returns>
        Task ForceUserRetrieval();
    }
}
