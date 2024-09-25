/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IAuditDefinition.cs
Function           :   Interface for IAuditDefinition Service
Created By         :   Shivam Dhingra
Created on         :   14-Feb-2020
Revision History   :   []
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Yokoten
{
    public interface IAuditDefinition : IService
    {
        Task<string> GetAllAuditDefinition();
        Task<string> GetAuditDefinitionById(Guid Id);
        Task<string> ProcessAuditDefinition(string modelData);
    }
}
