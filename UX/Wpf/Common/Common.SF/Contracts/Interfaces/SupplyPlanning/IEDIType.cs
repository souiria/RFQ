/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IEDIType.cs
Function           :   IEDIType
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
    /// Interface for EDIType Service
    /// </summary>
    public interface IEDIType : IBase
    {
        Task<string> GetEDIType(Guid id);
        Task<string> GetAllEDIType();
        Task<string> GetEDITypeByFilter(string filter);
        Task ProcessEDIType(string objData);
    }
}
