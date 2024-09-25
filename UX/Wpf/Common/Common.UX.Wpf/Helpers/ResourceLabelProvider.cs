/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ResourceLabelProvider.cs
Function           :   Maintain Resources Labels and Languages
Created By         :   Amit
Created on         :   22-Feb-2019
Revision History   :   [12-May-2020] : Amit Agarwal
                   :   [] : Commented Language and Label Endpoints w.r.t GZip Issue in UAT
****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.UX.Api;
using Common.UX.Api.Endpoints;

namespace Common.UX.Wpf.Helpers
{
    #region Resource Label Loading
    public class UXResourceLabelInUserLanguage
    {
        public string LabelKey { get; set; }
        public string LabelValue { get; set; }
    }

    public class ResourceLabelProvider
    {
        List<UXLanguageModel> _lstLanguage = null;
        //List<UXRegionsModel> _lstUXRegions = null;
        List<UXResourceLabelModel> _lstResourceLabel = null;


        /// <summary>
        /// Public variable for the location of [.resx] resource file.
        /// </summary>
        public const string _resxFile = @".\HarnessOneResources.resx";

        private Dictionary<string, string> GetResourceLabelFromServiceIntoDictionary(string languageUserPreference, string uxRegions)
        {
            Dictionary<string, string> dictionaryResourceLabel = new Dictionary<string, string>();

            _lstLanguage = new List<UXLanguageModel>();
            //_lstUXRegions = new List<UXRegionsModel>();
            _lstResourceLabel = new List<UXResourceLabelModel>();

            #region get Language List from Service
            //try
            //{
            //    _lstLanguage = ServiceHelper.GetAll<UXLanguageModel>(ServiceEndpointRoutes.Languages).Result.ToList();
            //}
            //catch (Exception)
            //{
            //    //Fallback option
            //    _lstLanguage.Add(new UXLanguageModel() { Id = new Guid("a0949283-f29b-4f47-bf94-9de9c2e90102"), Language = "English", LanguageDescription = "Display all contents in English language", IsActive = true });
            //    //throw;
            //}
            #endregion

            #region get UXRegions List from Service
            //try
            //{
            //	_lstUXRegions = ServiceHelper.Get<UXRegionsModel>(ServiceEndpointRoutes.UXRegions);
            //}
            //catch (Exception)
            //{
            //	//Fallback option
            //	_lstUXRegions.Add(new UXRegionsModel() { Id = new Guid("a0949283-f29b-4f47-bf94-9de9c2e90100"), RegionName = "ContentRegion", IsActive = true });
            //	_lstUXRegions.Add(new UXRegionsModel() { Id = new Guid("a0949283-f29b-4f47-bf94-9de9c2e90120"), RegionName = "StatusBarRegion", IsActive = true });
            //	_lstUXRegions.Add(new UXRegionsModel() { Id = new Guid("a0949283-f29b-4f47-bf94-9de9c2e90130"), RegionName = "OutlookBarRegion", IsActive = true });
            //	//throw;
            //}
            #endregion

            #region get ResourceLabel List from Service
            //try
            //{
            //    var language = _lstLanguage.FirstOrDefault(it => it.Language == languageUserPreference);
            //    if (language != null)
            //        //TODO: Requires fixing.
            //        _lstResourceLabel = ServiceHelper.Get<List<UXResourceLabelModel>>(ServiceEndpointRoutes.Labels, language.Id.ToString(), false).Result;
            //}
            //catch (Exception)
            //{
            //    //Fallback option

            //    //throw;
            //}
            #endregion

            //var Regions = from l in _lstUXRegions where l.RegionName == uxRegions & l.IsActive == true select l;
            //if (Regions.Count() > 0)
            //{
            //	var joinLanguageAndResourceLabel = (from l in _lstLanguage
            //										join r in _lstResourceLabel on l.Id equals r.UXLanguageGuid
            //										where l.Language == languageUserPreference & l.IsActive == true & r.IsActive == true
            //										select r);

            //	var finalResult = from j in joinLanguageAndResourceLabel
            //					  select new UXResourceLabelInUserLanguage()
            //					  {
            //						  LabelKey = j.LabelCode,
            //						  LabelValue = j.LabelValue,
            //					  };

            //	foreach (var item in finalResult)
            //	{
            //		dictionaryResourceLabel.Add(item.LabelKey, item.LabelValue);
            //	}
            //}
            var joinLanguageAndResourceLabel = (from l in _lstLanguage
                                                join r in _lstResourceLabel on l.Id equals r.UXLanguageGuid
                                                where l.Language == languageUserPreference & l.IsActive == true & r.IsActive == true
                                                select r);

            var finalResult = from j in joinLanguageAndResourceLabel
                              select new UXResourceLabelInUserLanguage()
                              {
                                  LabelKey = j.LabelCode,
                                  LabelValue = j.LabelValue,
                              };

            foreach (var item in finalResult)
            {
                dictionaryResourceLabel.Add(item.LabelKey, item.LabelValue);
            }

            return dictionaryResourceLabel;
        }

        public void GenerateResxFileFromService(string languageUserPreference = "English", string uxRegions = "ContentRegion")
        {
            //Write resources into .resx file from the service

            Dictionary<string, string> dataFromApiDic = GetResourceLabelFromServiceIntoDictionary(languageUserPreference, uxRegions);
            /*if (!dataFromApiDic.Any())
            {
                dataFromApiDic = GetLabelsTestData();
            }

            Dictionary<string, string> dataFromApiDic = GetLabelsTestData();*/

            // Get resources from .resx file.
            using (var resxSet = new ResXResourceWriter(_resxFile))
            {
                foreach (var entry in dataFromApiDic)
                {
                    resxSet.AddResource(entry.Key, entry.Value);
                }
                resxSet.Generate();
            }
        }
        public Task<Dictionary<string, string>> GetResourceLabelsFromResx(string resxFileNameIncludingPath = @".\HarnessOneResources.resx")
        {
            Dictionary<string, string> resultDic = new Dictionary<string, string>();
            // Get resources from .resx file.
            using (ResXResourceSet resxReader = new ResXResourceSet(resxFileNameIncludingPath))
            {
                foreach (DictionaryEntry entry in resxReader)
                {
                    resultDic.Add((string)entry.Key, (string)entry.Value);
                }
            }
            return Task.FromResult(resultDic);
        }

        private static Dictionary<string, string> GetLabelsTestData()
        {
            return new Dictionary<string, string>
            {
                { "00001", "SEWS-E Harness One" },
                { "00002", "Menu" },
                { "00003", "Home" },
                { "00004", "Tools" },
                { "00005", "Notifications" },
                { "00006", "Dashboard" },
                { "00007", "Welcome to Harness One" },
                { "00008", "Helpdesk" },
                { "00009", "Actions" },
                { "00010", "Print/Export" },
                { "00011", "Open Excel Export" },
                { "00012", "Help" },
                { "00013", "Add" },
                { "00014", "Delete" },
                { "00015", "Save" },
                { "00016", "Cancel" },
                { "00017", "Print" },
                { "00018", "Export" },
                { "00019", "Open Excel on Export" },
                { "00020", "Open Last Excel Exported" },
                { "00021", @"The dirctory C:\H1Releases does not exist, or you do not have access to this location." },
                { "00022", "Global Masters" },
                { "00023", "Core Masters" },
                { "00024", "Country" },
                { "00025", "Currency" },
                { "00026", "Units Of Measurements" },
                { "00027", "Business Unit Type" },
                { "00028", "Business Unit" },
                { "00029", "Incoterms" },
                { "00030", "Commodity" },
                { "00031", "Tariff Code" },
                { "00032", "Source Application" },
                { "00033", "Material Type" },
                { "00034", "Material" },
                { "00035", "Supplier Type" },
                { "00036", "Supplier Group" },
                { "00037", "Supplier" },
                { "00038", "Contact" },
                { "00039", "Language" },
                { "00040", "Regions" },
                { "00041", "Resource Label" },
                { "00042", "H1 Function" },
                { "00043", "H1 Module" },
                { "00044", "H1 View" },
                { "00045", "H1 Function H1 Module Association" },
                { "00046", "H1 Module H1 View Association" },
                { "00047", "H1 Configuration Key" },
                { "00048", "H1 Configuration Setting" },
                { "00049", "H1 Service Configuration Setting" },
                { "00050", "Field Override Security" },
                { "00051", "Association" },
                { "00052", "Supplier Association" },
                { "00053", "Material Association" },
                { "00054", "Supplier Material" },
                { "00055", "Tarrif Code Country Association" },
                { "00056", "Units of Measurement Association" },
                { "00057", "System Administration" },
                { "00058", "Security" },
                { "00059", "User Permissions" },
                { "00060", "Subscriptions" },
                { "00061", "Permissions" },
                { "00062", "Procurement" },
                { "00063", "Master Data Maintenance" },
                { "00064", "Procurement Supplier" },
                { "00065", "Supplier Management" },
                { "00066", "Procurement Material" },
                { "00067", "Safety Inventory" },
                { "00068", "Procurement Process Prefix Setting" },
                { "00069", "Procurement Process Counter Setting" },
                { "00070", "Procurement Process Counter Detail" },
                { "00071", "Purchasing" },
                { "00072", "Purchasing Supplier" },
                { "00073", "Purchasing Material" },
                { "00074", "Purchasing Commodity Code" },
                { "00075", "Material Origin" },
                { "00076", "Supplier Development Team" },
                { "00077", "EPO Commodity Group" },
                { "00078", "PO Price Type" },
                { "00079", "PO Price Effective Data Type" },
                { "00080", "Supplier Material Maintenance" },
                { "00081", "Supplier Material PO Pricing" },
                { "00082", "Supplier Selection" },
                { "00083", "Reports" },
                { "00084", "Material Inventory Enquiry" },
                { "00085", "Supplier Selection Change Log" },
                { "00086", "Origin Data Error List" },
                { "00087", "Supplier Material Change Log" },
                { "00088", "Material No X-Reference" },
                { "00089", "First Receipt Date" },
                { "00090", "Supplier Capactiy Planning" },
                { "00091", "Consolidated MRP Error List (Pre-Check)" },
                { "00092", "PO Price List" },
                { "00093", "Sales" },
                { "00094", "Enquiry" },
                { "00095", "RFQ" },
                { "00096", "Agresso Supplier" },
                { "00097", "Composite" },
                { "00098", "Customer" },
                { "00099", "Derivative" },
                { "00100", "Exchange Rate" },
                { "00101", "Facility" },
                { "00102", "Field Level Demo" },
                { "00103", "Indexed Material" },
                { "00104", "Logistics Concern Raised Status" },
                { "00105", "Logistics Concern Reason" },
                { "00106", "Material Cost Group" },
                { "00107", "Material Supplier" },
                { "00108", "Pack Form" },
                { "00109", "Part" },
                { "00110", "Payment Terms" },
                { "00111", "PO Price Effective" },
                { "00112", "Project" },
                { "00113", "Rating Concern" },
                { "00114", "Transportation Mode" },
                { "00115", "Vehicle" },
                { "00116", "Wire" },
                { "00117", "Association Masters" },
                { "00118", "Maintanence" },
                { "00119", "Analysis" },
                { "00120", "Forecast" },
                { "00121", "Data Synchronization" },
                { "00122", "Purchasing Article Synchronization" },
                { "00123", "V.A.V.E" },
                { "00124", "Alternative Parts" },
                { "10001", "Country Name" },
                { "10002", "Alpha 2 Code"},
                { "10003", "Alpha 3 Code"},
                { "10004", "UN Code"},
                { "10005", "Currency Code"},
                { "10006", "Currency Name"},
                { "10007", "Euro Rate"},
                { "10008", "Unit Of Measure Code"},
                { "10009", "Unit Of Measure Description"},
                { "10010", "Business Unit Type Name"},
                { "10011", "Business Unit Code"},
                { "10012", "Business Unit Name"},
                { "10013", "Street Number"},
                { "10014", "Street Name "},
                { "10015", "City"},
                { "10016", "Region "},
                { "10017", "Zip Code"},
                { "10018", "Incoterm Code"},
                { "10019", "Incoterm Description"},
                { "10020", "Commodity Name"},
                { "10021", "Tarrif Code Name "},
                { "10022", "EU Duty Rate"},
                { "10023", "Non EU Duty Rate "},
                { "10024", "Vat Rate"},
                { "10025", "Source Application Name"},
                { "10026", "Source Application Description"},
                { "10027", "Material Description"},
                { "10028", "Material Number"},
                { "10029", "Material Name"},
                { "10030", "Pre Production Number~"},
                { "10031", "Supplier Code"},
                { "10032", "Supplier Name"},
                { "10033", "Address 1"},
                { "10034", "Address 2"},
                { "10035", "Address 3"},
                { "10036", "Contact Type"},
                { "10037", "Contact Code"},
                { "10038", "First Name"},
                { "10039", "Last Name"},
                { "10040", "Contact No. "},
                { "10041", "Other Contact No "},
                { "10042", "Fax No."},
                { "10043", "Email Id"},
                { "10044", "Buyer"},
                { "10045", "SDE"},
                { "10046", "Language Description"},
                { "10047", "Region Name "},
                { "10048", "Label Code"},
                { "10049", "Label Value "},
                { "10050", "Label Purpose"},
                { "10051", "Function Name"},
                { "10052", "Module Name "},
                { "10053", "View Name"},
                { "10054", "Function"},
                { "10055", "Module "},
                { "10056", "View"},
                { "10057", "Configuration Key"},
                { "10058", "Is Encrypted"},
                { "10059", "Configuration Value"},
                { "10060", "Encryption Key"},
                { "10061", "Service Name"},
                { "10062", "Audit Logging"},
                { "10063", "Database Sync"},
                { "10064", "Value/Encryption/Decryption"},
                { "10065", "Enabled"},
                { "10066", "Allow Refreshing "},
                { "10067", "User Name"},
                { "10068", "Field Name"},
                { "10069", "Visible"},
                { "10070", "Transporter Currency"},
                { "50001","Material Number" },
                { "50002","Material Name" },
                { "50004","Active" },
                { "50005","Material Description" },
                { "50006","Effective Date To" },
                { "50007","Effective Date From" },
                { "50008","No Of Inner Container" },
                { "50009","Container Quantity" },
                { "50010","Issue Minimum Lot" },
                { "50011","Order Lead Time" },
                { "50012","Transit Lead Time" },
                { "50013","PO Price" },
                { "50014","PO Minimum Order Quantity" },
                { "50015","Supplier Material Name" },
                { "50016","Supplier Material Number" },
                { "50017","Supplier Code" },
                { "50018","Site Type Name" },
                { "50019","Site Name" },
                { "50020","Site Type" },
                { "50021","Supplier Group" },
                { "50023","Supplier Name" },
                { "50024","Material Cost Group" },
                { "50025","AgressoSupplier Code" },
                { "50026","AgressoSupplier Name" },
                { "50027","[50027] Save not allowed while error in Grid." },
                { "50028","[50028] Record saved successfully." },
                { "50029","[50029] Record updated successfully." },
                { "50030","[50030] Record deleted successfully." },
                { "50031","[50031] Duplicate Records Exist."},
                { "50032","Language" },
                { "50033","Region Name" },
                { "50034","Label Value" },
                { "50035","Label Code" },
                { "50036","PO Price Effective Description" },
                { "50037","Function Name" },
                { "50038","Function Description" },
                { "50039","Module Name" },
                { "50040","Module Description" },
                { "50041","Views Name" },
                { "50042","View Description" },
                { "50043","LCR Reason Description" },
                { "50044","LCR Code" },
                { "50045","PackForm Name" },
                { "50046","Commodity Name" },
                { "50047","Commodity Group" },
                { "50048","Delivery Terms" },
                { "50049","Payment Terms" },
                { "50050","H1 Function Name" },
                { "50051","H1 Module Name" },
                { "50052","H1 Configuration Parameter Key" },
                { "50053","H1 Configuration Parameter Value" },
                { "50054","H1 Encryption Key" },
                { "50055","Is Encrypted" },
                { "50056","[50056] Add not allowed while error in Grid." },
                { "50057","Status Code" },
                { "50058","Status Description" },
                { "50059","Reason Code" },
                { "50060","Reason Description" },
                { "50061","Incoterm Code" },
                { "50062","Incoterm Description" },
                { "50063","Counter Key" },
                { "50064","Counter Key Name" },
                { "50065","Prefix Code" },
                { "50066","Prefix Description" },
                { "50067","[50067] Do you want to Cancel ?" },
                { "50068","[50068] Do you want to Save the changes?" },
                { "50069","[50069] Are you sure ? " + Environment.NewLine + "Split pallet into boxes." },
                { "50070","[50070] Error in grid,can not continue!" },
                { "50071","Transportation Description" },
                { "50072","[50072] Mark for Deletion?" },
                { "50073","Counter" },
                { "50074","Site" },
                { "50075","Contact Type" },
                { "50076","Code" },
                { "50077","Contact Person Name" },
                { "50078","Contact No" },
                { "50079","Other Contact No" },
                { "50080","Fax No" },
                { "50081","Email Id" },
                { "50082","Business Unit Type Name" },
                { "50083","Currency Code" },
                { "50084","Currency Name" },
                { "50085","Euro Rate" },
                { "50086","Business Unit Name" },
                { "50087","Street Name" },
                { "50088","Street Number" },
                { "50089","City" },
                { "50090","Region" },
                { "50091","ZipCode" },
                { "50092","Country" },
                { "50093","Rating Concern Code" },
                { "50094","Rating Concern Description" },
                { "50095","Address 1" },
                { "50096","Address 2" },
                { "50097","Address 3" },
                { "50098","Commodity Group Code" },
                { "50099","Unit Of Measure Code" },
                { "50100","EPO Commodity Group Code" },
                { "50168","[50168] No data in Grid. Cannot Export." },
                { "50169","[50169] No Record Found." },
                { "50178","[50178] Unsaved data. Can not Export!" },
                { "50179","[50179] Export File Not Found!" },
                { "50181","[50181] Delete not allowed while Error in Grid!!" },
                { "50182","[50182] No data found to Upload." },
                { "50183","[50183] Upload un-successful." },
                { "50184","[50184] Uploaded Successfully." },
                { "50185","[50185] Approved must be [Y or N]." }
             };
        }
    }
    #endregion
}
