/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IFunctionControlSequenceGenerator.cs
Function           :   Function Control Sequence Generator Proxy
Created By         :   Nitin Sagar  
Created on         :   26-Jun-2019
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
  public interface IFunctionControlSequenceGenerator: IBase
    {
       Task<string> GenerateSequenceNumber(string functionCode);
    }
}
