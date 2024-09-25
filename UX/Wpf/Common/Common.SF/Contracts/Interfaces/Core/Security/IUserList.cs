/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   User.cs
Function           :   User information
Created By         :   Dharmendra 
Created on         :   20-Dec-2019
Revision History   :   [20-Dec-2019] : Dharmendra
                   :   [] : Added New Method UpdateUserHelpDeskCallandUserRoles()
****************************************************************************************************/
using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.ServiceFabric.Services.Remoting;
namespace Common.SF.Contracts.Interfaces.Core.Security
{
    /// <inheritdoc />
    /// <summary>
    /// An interface with all the method from <see cref="T:Common.SF.Contracts.Interfaces.Core.Security.ISecurity" /> that are relevant to users.
    /// </summary>
    public interface IUserList : IService
    {
        /// <summary>
        /// Gets all the users currently stored in the service.
        /// </summary>
        /// <returns>A list of <see cref="Common.Core.Contracts.Models.Core.Security.User"/>s compressed</returns>
        Task<byte[]> GetAllUsers();

        /// <summary>
        /// Gets the user with the specified Id.
        /// </summary>
        /// <param name="id">The Id of the user to retrieve.</param>
        /// <returns>The <see cref="User"/> compressed.</returns>
        Task<byte[]> GetUser(Guid id);

        /// <summary>
        /// Gets the user with the specified username.
        /// </summary>
        /// <param name="username">The username of the user to retrieve.</param>
        /// <returns>The <see cref="User"/> compressed.</returns>
        Task<byte[]> GetUserByUsername(string username);

        /// <summary>
        /// Gets the launch status of the specified user based on whether they are a H1User. Additionally, it will update the users FirstLogin and LastLogin property.
        /// </summary>
        /// <param name="id">The Id of the user.</param>
        /// <returns>The launch status of that user.</returns>
        Task<LaunchStatus> GetLaunchStatus(Guid id);
        /// <summary>
        /// update user Roles and Helpdesk Number
        /// </summary>
        /// <param name="objData"></param>
        /// <returns></returns>
        Task UpdateUserHelpDeskCallandUserRoles(byte[] objData);
      
    }
}
