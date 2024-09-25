/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IAuditLog.cs
Function           :   To display Jsox Audit Report
Created By         :   Dharmendra
Created on         :  
Revision History   :  [09-Jun-2020] : Dharmenadra Kumar
                   :  []   Add new method DisplayJsoxAuditReportData()
                   :  [06-Jul-2020] : Dharmenadra Kumar
                   :  []   Add new method DisplayJsoxAuditH1UsersScreenPermission()
****************************************************************************************************/

using System;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Logging;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core.Logging
{
    public interface IAuditLog : IService
    {
        Task<byte[]> GetAllAudits();
        Task<byte[]> GetAudit(Guid id);
        Task ProcessAudits(byte[] objData);
        Task<byte[]> GetAllByModelName(byte[] auditTrailSearchModel);
        Task<byte[]> DisplayJsoxAuditReportData();
        Task<byte[]> DisplayJsoxAuditH1UsersScreenPermission();
    }
}
