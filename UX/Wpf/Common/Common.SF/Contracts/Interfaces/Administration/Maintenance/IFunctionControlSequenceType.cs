/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IFunctionControlSequenceType.cs
Function           :   Function Control Sequence Type Proxy
Created By         :   Nitin Sagar  
Created on         :   12-Jul-2019
Revision History   :   [] : 
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.Administration.Maintenance
{
  public interface IFunctionControlSequenceType : IBase
    {
        Task<string> GenerateSequenceNumber(string ParamObj);
    }
}
