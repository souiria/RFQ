/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EndpointHelper.cs
Function           :   
Created By         :   
Created on         :   
Revision History   :   [28-May-2020] : Srashti Gupta
*                  :   Added the YokotenAngularWepAppUrl for Yokoten Module to genrate the dynamically Url on its ViewModels
****************************************************************************************************/

namespace Common.UX.Helpers
{
    public static class EndpointHelper
    {
#if DEBUG
        // Local
        public static string EndpointAddress = "192.168.53.12";//"ukhqsfuat001.sews-e.com"; //"172.29.58.207";
        //public static string EndpointAddress = "harnessone.mindeservices.com";

        //Yokoten
        public static string YokotenAngularWepAppUrl = "192.168.53.252:8091";   // Port : 8090 for MIND

        //MIND Server IP
        //Please do not move this code in UAT or Live.
        //Ajay: 15-Apr-2020. This is done for auto build process and H1 Instller Release in MIND Environment
        //For H1 MIND Installer

        //public static string EndpointAddress = "harnessone.mindeservices.com";

        // TDD
        //public static string EndpointAddress = "192.168.53.51";

        // UAT
        //public static string EndpointAddress = "UKHQH1UAT";

        //Live
        //public static string EndpointAddress = "UKHQH1LIVE";
#elif UAT
        //public static string YokotenAngularWepAppUrl = "192.168.53.12:8203";  // Port : 8091 for UAT
        // // UAT
        //public static string EndpointAddress = "UKHQH1UAT";
        //public static string EndpointAddress = "172.29.58.207";

        //Yokoten
       // public static string YokotenAngularWepAppUrl = "192.168.53.252:8091";
#else
        //Live
        //public static string EndpointAddress = "UKHQH1LIVE";
#endif

    }
}
