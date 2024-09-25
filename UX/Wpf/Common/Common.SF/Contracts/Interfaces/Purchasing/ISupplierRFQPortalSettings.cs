/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ISupplierRFQPortalSettings.cs
Function           :   Supplier RFQ PortalSettings Proxy
Created By         :   Nitin Sagar
Created on         :   05-Jul-2019
Revision History   :   [14-Jun-2019] : Dharmendra
                   :   [ ] : Add two new method reset password and generate password.
                   :   [22-jul-2019] :Nitin
                   :    Added new method to update password
                   :   [25-Sep-2019] :Pawan
                   :   [] : Added new method for Issue Username
****************************************************************************************************/
using Common.SF.Contracts.Interfaces.Base;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    /// <summary>
    /// Proxy for Supplier RFQ Settings
    /// </summary>
    public interface ISupplierRFQPortalSettings : IBase
    {
        Task DatabaseRecovery(bool mergeData);
        Task<string> GenerateRandomPassword(string objData);
        Task<string> ResetRandomPassword(string objData);
        Task<string> IssueUsername(string objData);
        Task<string> UpdatePassword(string [] UserNamePassword);
    }
}

   