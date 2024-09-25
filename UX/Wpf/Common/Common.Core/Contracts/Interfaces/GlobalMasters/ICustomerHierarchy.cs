/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ICustomerHierarchy.cs
Function           :   Customer Hierarchy
Created By         :   Dharmendra 
Created on         :   29-Nov-2019
Revision History   :   [03-Dec-2019] : Pawan
                   :   [] : Changed List to Observable Collection                 
****************************************************************************************************/
using Common.Core.Contracts.Interfaces;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.Core.Contracts.Models.GlobalMasters.Customer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface ICustomerHierarchy : IBaseHierarchy<Guid>
    {
        string CustomerCode { get; set; }
        string CustomerName { get; set; }
        string StreetNumber { get; set; }
        string StreetName { get; set; }
        string City { get; set; }
        string Region { get; set; }
        string ZipCode { get; set; }
        string Country { get; set; }
        string CustomerBusinessType { get; set; }
        string IndexedMaterial { get; set; }

        ObservableCollection<PlatformHierarchyModel> PlatformHierarchy { get; set; }
        ObservableCollection<CustomerSalesEntityHierarchyModel> CustomerSalesEntityHierarchy { get; set; }
    }
}
