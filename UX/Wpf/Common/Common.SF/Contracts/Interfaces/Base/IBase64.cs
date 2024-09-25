/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   IBase64.cs
Function           :   Interfaces for fetching the records from service.
Created By         :  
Created on         :  
Revision History   :   [14-Oct-2019] : Srashti Gupta
*                  :   [] : Added the IBaseCustom64 interface for performance optimization.
****************************************************************************************************/

using Common.Core.Contracts.Models.Core.Filtering;
using Microsoft.ServiceFabric.Services.Remoting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.SF.Contracts.Interfaces.Base.Base64
{
    public interface IBase64 : IService
    {
        Task<string> GetAll();
        Task<string> Get(Guid id);
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filter);
        Task<string> ProcessOperation(string objData);
        Task<string> GetAllByPartition(string key);
        //Task<string> GetAllSecureDataByPartition(string key, string guidObjData);
    }
    public interface IBase64Custom : IService
    {
        Task<string> GetAllFieldsSelector(string field);
        Task<string> GetAllFieldsSelectorFilter(List<SpecificDataFilteringModel> Filters);
        Task<string> GetAllFieldsSelectorUncompressed(string field);
        Task<string> GetAllFieldsSelectorByDictionaryUncompressed(string Key, string field);
        Task<string> GetAllFieldsSelectorByPartition(string key, string fields);
        Task<string> GetFieldsSelectorWithFilterByDictionary(string key, string selectorAndFilter);
    }

}