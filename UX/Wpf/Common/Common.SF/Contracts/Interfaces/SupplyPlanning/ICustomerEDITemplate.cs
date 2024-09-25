/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ICustomerEDITemplate.cs
Function           :   ICustomerEDITemplate
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
    /// Interface for CustomerEDITemplate Service
    /// </summary>
    public interface ICustomerEDITemplate : IBase
    {
        Task<string> GetCustomerEDITemplate(Guid id);
        Task<string> GetAllCustomerEDITemplate();
        Task<string> GetCustomerEDITemplateByFilter(string filter);
        Task ProcessCustomerEDITemplate(string objData);
    }
}
