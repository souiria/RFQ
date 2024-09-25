/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   INPRBacklogHistory.cs
Function           :   NPR Backlog Proxy
Created By         :   Amit Agarwal
Created on         :   04-Jul-2019
Revision History   :   [] : 
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.RFQManagement
{
    /// <summary>
    /// Proxy for NPR Backlog
    /// </summary>
    public interface INPRBacklog : IBase
    {
    }
}