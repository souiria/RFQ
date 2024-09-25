/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IEDISetupMasters.cs
Function           :   IEDISetupMasters
Created By         :   Srashti Gupta
Created on         :   27-Jan-2020
Revision History   :   
                   :   
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.SupplyPlanning
{
    /// <summary>
    /// Interface for EDISetUpMasters Service
    /// </summary>
    public interface IEDISetupMasters : IService, IEDIFileType, IEDIType, ICustomerEDITemplate
    {
    }
}
