/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IEDIFileType.cs
Function           :   IEDIFileType
Created By         :   Srashti Gupta
Created on         :   23-Jan-2020
Revision History   :   
                   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.SupplyPlanning;
using Common.SF.Contracts.Interfaces.Base;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.SupplyPlanning
{
    /// <summary>
    /// Interface for EDIFileType Service
    /// </summary>
    public interface IEDIFileType : IBase
    {
        Task<string> GetEDIFileType(Guid id);
        Task<string> GetAllEDIFileType();
        Task<string> GetEDIFileTypeByFilter(string filter);
        Task ProcessEDIFileType(string objData);
    }
}
