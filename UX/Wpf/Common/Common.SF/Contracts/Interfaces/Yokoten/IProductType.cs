/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IProductType.cs
Function           :   Interface for ProductType Service
Created By         :   Shivam Dhingra
Created on         :   07-Feb-2020
Revision History   :   []
****************************************************************************************************/
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Yokoten
{
    public interface IProductType : IService
    {
        Task<string> GetAllProductType();
        Task<string> GetProductTypeById(Guid Id);
        Task<string> ProcessProductType(string modelData);
    }
}
