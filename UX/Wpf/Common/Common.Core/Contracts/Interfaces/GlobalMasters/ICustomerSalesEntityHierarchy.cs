/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ICustomerHierarchy.cs
Function           :   Customer Hierarchy
Created By         :   Amit Agarwal 
Created on         :   29-Nov-2019
Revision History   :                    
****************************************************************************************************/
using Common.Core.Contracts.Interfaces;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.Core.Contracts.Models.GlobalMasters.Customer;
using System;
using System.Collections.Generic;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface ICustomerSalesEntityHierarchy : IBaseHierarchy<Guid>
    {
        string CustomerSalesEntityCode { get; set; }
        string CustomerSalesEntityName { get; set; }
        string FinanceCode { get; set; }
        string StreetNumber { get; set; }
        string StreetName { get; set; }
        string City { get; set; }
        string Region { get; set; }
        string ZipCode { get; set; }
        string Country { get; set; }
    }
}
