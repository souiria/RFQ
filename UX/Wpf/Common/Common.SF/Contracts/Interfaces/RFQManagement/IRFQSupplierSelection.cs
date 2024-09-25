/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IRFQSupplierSelection.cs
Function           :   RFQ Supplier Selection Proxy
Created By         :   Dashisht Bhardwaj
Created on         :   11-Jul-2019
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
    public interface IRFQSupplierSelection : IBase
    {
    }
}