/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SpecificDataFilteringModel.cs
Function           :   Filtering the specific data by required fields from service
Created By         :   Srashti Gupta
Created on         :   14-Oct-2019
Revision History   :   [24-Mar-2021] : Shivam Dhingra
                   :   [] : Added new field ReturnRecordCount
****************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Core.Filtering
{
    public enum FiltersDataType
    {
        Boolean_Value = 0,
        Int32_Value = 1,
        Int64_Value = 2,
        Double_Value = 3,
        DateTime_Value = 4,
        String_Value = 5,
        Guid_Value = 6
    }
    public class ComparisionOperators
    {
        public const string GreaterThan = ">";
        public const string LessThan = "<";
        public const string GreaterThanOrEqual = ">=";
        public const string LessThanOrEqual = "<=";
        public const string Equal = "=";
        public const string NotEqual = "<>";
        public const string StartsWith = "StartsWith";
        public const string Contains = "Contains";
        public const string InOperator = "In";
        public const string Like = "like";
    }

    public class LogicalOperators
    {
        public const string And = "and";
        public const string Or = "or";
        public const string Blank = "";
    }


    [DataContract, Serializable]
    public class SpecificDataFilteringModel
    {
        private string _fieldName;
        [DataMember]
        public string FieldName
        {
            get => _fieldName;
            set => _fieldName = value;
        }

        private object _fieldValue;
        [DataMember]
        public object FieldValue
        {
            get => _fieldValue;
            set => _fieldValue = value;
        }

        private string _operators;
        [DataMember]
        public string Operators
        {
            get => _operators;
            set => _operators = value;
        }

        private string _specificFields;
        [DataMember]
        public string SpecificFields
        {
            get => _specificFields;
            set => _specificFields = value;
        }

        private string _logicalOperators;
        [DataMember]
        public string LogicalOperators
        {
            get => _logicalOperators;
            set => _logicalOperators = value;
        }
        private string _filterOrder;
        [DataMember]
        public string FilterOrder
        {
            get => _filterOrder;
            set => _filterOrder = value;
        }
    }

    public class FiltersSpecificModel
    {
        private List<string> _Fields;
        [DataMember]
        public List<string> Fields
        {
            get => _Fields;
            set => _Fields = value;
        }

        private IEnumerable<SpecificDataFilteringModel> _specificDataFiltering;
        [DataMember]
        public IEnumerable<SpecificDataFilteringModel> SpecificDataFiltering
        {
            get => _specificDataFiltering;
            set => _specificDataFiltering = value;
        }

        private int _returnRecordCount = 0;
        [DataMember]
        public int ReturnRecordCount
        {
            get => _returnRecordCount;
            set => _returnRecordCount = value;
        }
    }
}
