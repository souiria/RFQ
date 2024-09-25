/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IPlatformHierarchy.cs
Function           :   Platform Hierarchy
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
    public interface IPlatformHierarchy : IBaseHierarchy<Guid>
    {
        string PlatformName { get; set; }
        ObservableCollection<ProgramHierarchyModel> ProgramHierarchy { get; set; }
    }
}
