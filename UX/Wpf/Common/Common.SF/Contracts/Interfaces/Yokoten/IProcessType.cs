/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IProcessType.cs
Function           :   Interface for ProcessType Service
Created By         :   Amit Agarwal
Created on         :   30-Jan-2020
Revision History   :   []
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Yokoten
{
   public interface IProcessType : IService
    {
        Task<string> GetAllProcessType();
        Task<string> GetProcessTypeById(Guid Id);
        Task<string> ProcessProcessType(string modelData);
    }
}
