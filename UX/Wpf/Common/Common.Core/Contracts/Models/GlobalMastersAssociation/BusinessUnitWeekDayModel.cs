/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   BusinessUnitWeekDayModel.cs
Function           :   BusinessUnit WeekDa Data
Created By         :   Shivam Dhingra
Created on         :   06-Jul-2021
Revision History   :  
****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// Class File for BusinessUnitWeekDay
    /// </summary>
    [DataContract,Serializable]
    public class BusinessUnitWeekDayModel
    {
        private string _businessUnitCode;
        /// <summary>
        /// BusinessUnitCode
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(4)]
        public string BusinessUnitCode
        {
            get => _businessUnitCode;
            set => _businessUnitCode = value;
        }

        private string _startWeekDay;
        /// <summary>
        /// StartWeekDay
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        [StringLength(10)]
        public string StartWeekDay
        {
            get => _startWeekDay;
            set => _startWeekDay = value;
        }

        private bool _isActive;
        /// <summary>
        /// IsActive
        /// </summary>
        ///<example>
        /// 
        ///</example>
        [DataMember]
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
    }
}
