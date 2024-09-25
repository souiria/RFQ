/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NetCoreServiceEndpointRoutes.cs
Function           :   Endpoints to create a proxy of Core Services
Created By         :  
Created on         :   
Revision History   :  [06-Nov-2020] : Srashti Gupta
*                  :  Added EndpointRoutes for WMSLocationMapping, WMSLocationReportingSection
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Infrastructure.Endpoints
{
    public partial class NetCoreServiceEndpointRoutes
    {
        public static readonly NetCoreServiceEndpointRoutes CoreCustomerIdentificationSettingsPartitions = new NetCoreServiceEndpointRoutes("SupplyPlanning.EDISetup/SF.SupplyPlanning.EDISetupMaster/CustomerIdentificationSettings");
        public static readonly NetCoreServiceEndpointRoutes CoreWMSLocationMapping = new NetCoreServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/WMSLocationMapping");
        public static readonly NetCoreServiceEndpointRoutes CoreWMSLocationReportingSection = new NetCoreServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/WMSLocationReportingSection");

    }
}