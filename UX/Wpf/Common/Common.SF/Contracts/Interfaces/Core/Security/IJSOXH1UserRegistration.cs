/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IJSOXH1UserRegistration.cs
Function           :   JSOX H1User Regetration  
Created By         :   Dharmendra 
Created on         :   20-Jan-2021
Revision History   :    [01-Mar-2021] :Dharmendra
*                  :   Added the  new method GetAllH1Users()

****************************************************************************************************/
using Common.Core.Contracts.Models.JsoxAudit;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Core.Security
{
    public interface IJSOXH1UserRegistration : IService
    {
        Task<H1UserRegisterReportModel> GetJSoxH1UserRegitrationIformation(byte[] objData);
        Task<H1UserRegisterModel> GetJSoxH1UserRegitrationHDCallIformation(byte[] objData);
        Task<IEnumerable<Common.Core.Contracts.Models.Core.Security.User>> GetAllH1Users();
    }
}
