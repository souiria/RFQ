/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   Audit.cs
Function           :   Interface for Audit Service
Created By         :   Shivam Dhingra
Created on         :   07-Feb-2020
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
    public interface IAudit : IService
    {
        Task<string> GetAllAudit();
        Task<string> GetAuditById(Guid Id);
        Task<string> ProcessAudit(string modelData);
    }
}
