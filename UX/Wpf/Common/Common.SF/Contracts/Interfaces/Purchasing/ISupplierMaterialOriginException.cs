/**************************************************************************************************
 (C) 2018 SEWS-E Ltd., All rights reserved
 File Name          :   ISupplierMaterialOriginException.cs
 Function           :   Common method for service
 Created By         :   Srashti Gupta
 Created on         :   12-Feb-2019
 Revision History   :                    
 *                  :   
****************************************************************************************************/
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Common.SF.Contracts.Interfaces.Base;

namespace Common.SF.Contracts.Interfaces.Purchasing
{
    public interface ISupplierMaterialOriginException : IBase
	{
        Task<string> GetAll();
        Task<string> GetByFilter(IEnumerable<FilterCollectionModel> filterList);
        Task<string> ProcessOperation(string objData);
        Task DatabaseRecovery(bool mergeData);

    }
}
