/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   INPRPartSearch.cs
Function           :   Method for show NPR Part Search data
Created By         :   Dharmendra Kumar
Created on         :   25-Jul-2019
Revision History   :   [] :                  
****************************************************************************************************/
using Common.Core.Contracts.Models.NPR;
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.NPR
{
   public interface INPRPartSearch : IService
    {
        Task<string> ShowNPRPartSearch();
    }
}
