/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IMilestoneHierarchy.cs
Function           :   Milestone Hierarchy
Created By         :   Dharmendra 
Created on         :   29-Nov-2019
Revision History   :   [03-Mar-2020] : Srashti Gupta
                   :   [] : Modified the datatype to Datetime? of EventStartDate,EventEndDate                 
****************************************************************************************************/
using Common.Core.Contracts.Interfaces;
using Common.Core.Contracts.Models.GlobalMasters.Customer;
using System;
using System.Collections.Generic;

namespace Common.SF.Contracts.Interfaces.GlobalMasters
{
    public interface IMilestoneHierarchy : IBaseHierarchy<Guid>
    {
        string Name { get; set; }
        DateTime? EventStartDate { get; set; }
        DateTime? EventEndDate { get; set; }
    }
}
