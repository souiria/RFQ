/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   FiveYAndRouteCauseAnalysisModel.cs
Function           :   FiveYAndRouteCauseAnalysisModel,DataForRetrunModel
Created By         :   Vishwadeep Singh
Created on         :   19-Jan-2024
Revision History   :
                   :   [13-Dec-2023] : Vishwadeep Singh
                   :   Added to region names ConcernViewRegion,ControllerToDelegateViewRegion
****************************************************************************************************/

namespace Common.UX.Wpf.Helpers
{
    public class RegionNames
    {
        #region Main UX Layout
        public static string ContentRegion => "ContentRegion";
        public static string RibbonBarRegion => "RibbonBarRegion";
        public static string OutlookBarRegion => "OutlookBarRegion";
        public static string StatusBarRegion => "StatusBarRegion";
        public static string WidgetBarRegion => "WidgetBarRegion";
        public static string WizardRegion => "WizardRegion";
        #endregion

        #region UX Subregions
        public static string OutlookBarGroupRegion => "OutlookBarGroupRegion";
        public static string WidgetBarGroupRegion => "WidgetBarGroupRegion";
        public static string RibbonRegion => "RibbonRegion";
        public static string RibbonTabRegion => "RibbonTabRegion";
        public static string RibbonContextTabRegion => "RibbonContextTabRegion";
        public static string ApplicationMenuRegion => "ApplicationMenuRegion";
        public static string RFQViewRegion => "RFQViewRegion";
        public static string DSIViewRegion => "DSIViewRegion";
        public static string AlternativeViewRegion => "AlternativeViewRegion";
        public static string NPRViewRegion => "NPRViewRegion";
        public static string MarginDashboardRegion => "MarginDashboardRegion";
        public static string SFSViewRegion => "SFSViewRegion";
        public static string SFSCarModelRegion = "SFSCarModelRegion";
        public static string SFSCalendarRegion = "SFSCalendarRegion";
        public static string EDIInvalidDespatchesRegion => "EDIInvalidDespatchesRegion";
        public static string EDILocationMasterRegion = "EDILocationMasterRegion";
        public static string YokotenViewRegion => "YokotenViewRegion";
        public static string ConcernViewRegion => "ConcernViewRegion";
        public static string ControllerToDelegateViewRegion => "ControllerToDelegateViewRegion";

        public static string BusinessApproval => "BusinessApproval";
        public static string CLSStatusEnquiry => "CLSStatusEnquiry";
        #endregion
    }
}
