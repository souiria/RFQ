/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IQualityConcern.cs
Function           :   Interface for stateless service QualityConcern
Created By         :   Nitin
Created on         :   30-Jan-2020
Revision History   :   [06-02-2020] : Renamed interface methods
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Purchasing;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.Yokoten
{
    /// <summary>
    /// Interface for QualityConcern Service
    /// </summary>
    public interface IQualityConcern :IService
    {
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        Task<string> GetAllQualityConcern();
        /// <summary>
        /// Get data by supplied id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<string> GetQualityConcernById(Guid Id);
        /// <summary>
        /// add,update or delete data
        /// </summary>
        /// <param name="modelData"></param>
        /// <returns></returns>
        Task<string> ProcessQualityConcern(string modelData);
    }
}
