/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IAuditGrade.cs
Function           :   Interface for AuditGrade Service
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
    public interface IAuditGrade : IService
    {
        Task<string> GetAllAuditGrade();
        Task<string> GetAuditGradeById(Guid Id);
        Task<string> ProcessAuditGrade(string modelData);
    }
}
