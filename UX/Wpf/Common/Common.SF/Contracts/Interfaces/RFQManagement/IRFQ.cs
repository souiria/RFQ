/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IRFQ.cs
Function           :   Interface 
Created By         :   Dharmendra Kumar 
Created on         :   24-Jun-2019
Revision History   :   [] : 
****************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.RFQManagement
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRFQ : IBase
    {
        /// <summary>
        /// Fetch Record from service on the basis of Guid.
        /// </summary>
        /// <param name="id">It is uniqIdentifier.</param>
        /// <returns>single model for currenct service</returns>
        Task<string> Get(Guid id);
        /// <summary>
        /// Get all records from service
        /// </summary>
        /// <returns>List of collection</returns>
        Task<string> GetAll();
        /// <summary>
        /// Get data on the basis of filter value.
        /// </summary>
        /// <param name="filter">fields on the basis filter operation will occur</param>
        /// <returns>Get Filter result</returns>
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filter);
        /// <summary>
        /// This is used to create,update and delete process.
        /// </summary>
        /// <param name="objData">parameter used as object string for process record</param>
        /// <returns>return result in form of string</returns>
        Task<string> ProcessOperation(string objData);
        /// <summary>
        /// this method is used for Databases the recovery.
        /// </summary>
        /// <param name="mergeData">if set to <c>true</c> [merge data].</param>
        Task DatabaseRecovery(bool mergeData);
    }
}
