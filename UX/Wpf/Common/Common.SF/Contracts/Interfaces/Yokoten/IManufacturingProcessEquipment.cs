/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IManufacturingProcessEquipment.cs
Function           :   Interface for stateless service ManufacturingProcessEquipment
Created By         :   Nitin
Created on         :   05-Feb-2020
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
    /// Interface for EDIType Service
    /// </summary>
    public interface IManufacturingProcessEquipment : IService
    {
        /// <summary>
        /// Get all data
        /// </summary>
        /// <returns></returns>
        Task<string> GetAllManufacturingProcessEquipment();
        /// <summary>
        /// Get data by supplied id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<string> GetManufacturingProcessEquipmentById(Guid Id);
        /// <summary>
        /// add,update or delete data
        /// </summary>
        /// <param name="modelData"></param>
        /// <returns></returns>
        Task<string> ProcessManufacturingProcessEquipment(string modelData);
    }
}
