/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ConsolidatedCustomerProductModel.cs
Function           :   Data contract for ConsolidatedCustomerProductModel
Created By         :   Amit
Created on         :   23-May-2020
Revision History   :   [] : 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract, Serializable]
    public class ConsolidatedCustomerProductModel 
    {
        private string _customerProductNumber;
        [DataMember]
        [StringLength(26)]
        public string CustomerProductNumber
        {
            get => _customerProductNumber;
            set =>  _customerProductNumber = value;
        }
        private DateTime _entryDate;
        [DataMember]
        public DateTime EntryDate
        {
            get => _entryDate;
            set => _entryDate = value;
        }
        private string dataSource;
        [DataMember]
        [StringLength(20)]
        public string DataSource
        {
            get => dataSource;
            set => dataSource = value;
        }
    }
}
