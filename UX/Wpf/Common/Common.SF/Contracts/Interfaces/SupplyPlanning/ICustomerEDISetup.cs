/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ICustomerEDITemplateSetup.cs
Function           :   ICustomerEDITemplateSetup
Created By         :   Srashti Gupta
Created on         :   23-Jan-2020
Revision History   :   
                   :   
****************************************************************************************************/
using Common.Core.Contracts.Models.Core.Filtering;
using Common.Core.Contracts.Models.SupplyPlanning;
using Common.SF.Contracts.Interfaces.Base;
using Common.SF.Contracts.Interfaces.Base.Base64;
using System;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.SupplyPlanning
{
    /// <summary>
    /// Interface for CustomerEDISetup Service
    /// </summary>
    public interface ICustomerEDISetup : IBase, IBase64Custom
    {
        Task<string> Get(Guid id);
        Task<string> GetAll();
        Task<CustomerEDISetupModel> GetUncompressed(Guid id);
        Task<string> GetCustomerEDISetupFlattenData(string filterdata);
    }
}
