/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IPropagateNPRToH1.cs
Function           :   Propagate NPR Data to H1
Created By         :   Pawan
Created on         :   27-Aug-2019
Revision History   :   [13-Sep-2019] : Pawan
                   :   [] : Added interface to propagate data as Active 
                   :   [16-Sep-2019] : Pawan
                   :   [] : Commented other methods for optimization
                   :   [06-Mar-2020] : Dharmendra
                   :   [] : Added new interface PropagateNPRToH1ValidationsOnSQLServer()
****************************************************************************************************/
using Common.Core.Contracts.Models.Purchasing;
using Microsoft.ServiceFabric.Services.Remoting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    /// <summary>
    /// Interface for Propagation of Data from NPR to H1
    /// </summary>
    public interface IPropagateNPRToH1 : IService
    {
        /// <summary>
        /// Propagate Active NPR Data to H1 Screens
        /// </summary>
        /// <param name="propagateNPRToH1Model"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> NPRToH1ActiveDataPropagation(PropagateNPRToH1Model propagateNPRToH1Model);
        ///// <summary>
        ///// Propagate In-Active NPR Data to H1 Screens till PO Pricing
        ///// </summary>
        ///// <param name="propagateNPRToH1Model"></param>
        ///// <returns></returns>
        //Task<IEnumerable<string>> NPRToH1InActiveDataPropagation(PropagateNPRToH1Model propagateNPRToH1Model);
        ///// <summary>
        ///// Propagate Active NPR Data to H1 Screens till PO Pricing without Business Unit
        ///// </summary>
        ///// <param name="propagateNPRToH1Model"></param>
        ///// <returns></returns>
        //Task<IEnumerable<string>> NPRToH1ActiveDataPropagationWithoutBusinessUnit(PropagateNPRToH1Model propagateNPRToH1Model);

        Task<string> PropagateNPRToH1ValidationsOnSQLServer(string objData);
    }
}