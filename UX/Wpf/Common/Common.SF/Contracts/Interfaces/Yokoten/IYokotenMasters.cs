/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IYokotenMasters.cs
Function           :   Interface for stateless service YokotenMasters
Created By         :   Nitin
Created on         :   06-Feb-2020
Revision History   :   []  
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Purchasing;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.Yokoten
{
    /// <summary>
    /// An interface that provide all the public method implementations for the YokotenMasters service.
    /// </summary>
    public interface IYokotenMasters :IService,IProcessType,IQualityConcern,IManufacturingProcessEquipment
    {
    }
}
