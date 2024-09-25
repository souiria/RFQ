/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   InvoiceQueryReasonModel.cs
Function           :   
Created By         :  Prakhar
Created on         :  [21-Jul-2023]
Revision History   :  []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class InvoiceQueryReasonModel : BaseModel<Guid>
    {
        private string _reasonforQuery;
        [DataMember]
        public string ReasonforQuery
        {
            get => _reasonforQuery;
            set => SetProperty(ref _reasonforQuery, value);
        }
        private bool _isActive;
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
