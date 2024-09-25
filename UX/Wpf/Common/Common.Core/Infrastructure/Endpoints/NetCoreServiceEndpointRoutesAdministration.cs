/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NetCoreServiceEndpointRoutes.cs
Function           :   Endpoints to create a proxy of Core Services
Created By         :    Dharmendra Kumar    
Created on         :    [03-Nov-2020]
Revision History   :  [04-Nov-2020] : Dharmendra Kumar  
                   :  []   Add new endpoint CoreCountryUserFunctionAssociation
****************************************************************************************************/
namespace Common.Core.Infrastructure.Endpoints
{
    public partial class NetCoreServiceEndpointRoutes
    {
        /// <summary>
        /// Service path to interact with Service CoreFunctionControlSequenceType
        /// </summary>
        
        public static readonly NetCoreServiceEndpointRoutes CoreBusinessProcessByCountryAndSites = new NetCoreServiceEndpointRoutes("Administration/api/SF.AdministrationCore.Masters/BusinessProcessByCountryAndSites");
        public static readonly NetCoreServiceEndpointRoutes CoreCountryUserFunctionAssociation = new NetCoreServiceEndpointRoutes("Administration/api/SF.AdministrationCore.Masters/CountryUserFunctionAssociation");

    }
}
