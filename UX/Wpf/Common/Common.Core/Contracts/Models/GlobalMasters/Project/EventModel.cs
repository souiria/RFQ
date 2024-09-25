/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   EventModel.cs
Function           :   Event Model
Created By         :   Pawan Kumar
Created on         :   31-Jul-2019
Revision History   :   [21-Oct-2019] : Pawan
                   :   [ ] : Modified validation of Start Date and End Date 
                   :   [12-Nov-2019] : Aditya
                   :   [ ] : Modified Validation End Date should be greater than Start Date
****************************************************************************************************/
using System;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.GlobalMasters.Project
{
    [DataContract]
    public class EventModel : BaseModel<Guid>, IValidatable
    {
        private DateTime _startDate;

        [DataMember]
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;

        [DataMember]
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Name),
            nameof(StartDate),
            nameof(EndDate)
        };

        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(Name) when string.IsNullOrWhiteSpace(Name):
                        return "Name must not be empty";

                    case nameof(StartDate) when _startDate < DateTime.UtcNow.Date:
                        if (CrudOperationType == CrudOperationType.Read)
                        { return null;  }
                        else
                        return "Start date must be set to a date equal to today or later.";

                    case nameof(EndDate) when _endDate < DateTime.UtcNow.Date:
                        if (CrudOperationType == CrudOperationType.Read)
                        { return null; }
                        else
                            return "End date must be set to a date equal to today or later.";

                    case nameof(EndDate) when _endDate <= _startDate:
                        if (CrudOperationType == CrudOperationType.Read)
                        { return null; }
                        else
                            return "End date must be set to a date later than the start date.";

                    default:
                        return null;
                }
            }
        }
    }
}
