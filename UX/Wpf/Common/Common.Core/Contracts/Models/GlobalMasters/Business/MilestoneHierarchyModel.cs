/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   MilestoneHierarchyModel.cs
Function           :   Milestone Hierarchy Model
Created By         :   Amit Agarwal
Created on         :   29-Nov-2019
Revision History   :   [30-Nov-2019] : Pawan
                   :   [] : Added validation for each property  
                   :   [02-Dec-2019] : Nitin
                   :   [] : Added field length validation
                   :   [03-Mar-2020] : Srashti Gupta
                   :   [] : Modified the datatype to Datetime? of EventStartDate,EventEndDate
                   :   [22-Feb-2023]  : Vishwadeep Singh 
                   :   [] : Add property ProjectHierarchyGuid
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.SF.Contracts.Interfaces.GlobalMasters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract]
    public class MilestoneHierarchyModel : BaseModel<Guid>, IMilestoneHierarchy
    {
        private string _milestoneEventName;

        /// <summary>
        /// EventName
        /// </summary>
        /// <example>
        /// MassProduction, Build1, Build2
        /// </example>
        [DataMember]
        [StringLength(100)]
        public string MilestoneEventName
        {
            get => _milestoneEventName;
            set => SetProperty(ref _milestoneEventName, value);
        }

        private DateTime? _eventStartDate;

        [DataMember]
        public DateTime? EventStartDate
        {
            get => _eventStartDate;
            set => SetProperty(ref _eventStartDate, value);
        }

        private DateTime? _eventEndDate;

        [DataMember]
        public DateTime? EventEndDate
        {
            get => _eventEndDate;
            set => SetProperty(ref _eventEndDate, value);
        }

        // Added by vishwadeep singh
        private Guid _projectHierarchyGuid;

        /// <summary>
        /// ProjectHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid ProjectHierarchyGuid
        {
            get => _projectHierarchyGuid;
            set => SetProperty(ref _projectHierarchyGuid, value);
        }

        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Name),
            nameof(EventStartDate),
            nameof(EventEndDate)
        };
        /// <summary>
        /// Method to validate properties
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public override string this[string propertyName]
        {
            get
            {
                Error = string.Empty;
                try
                {
                    switch (propertyName)
                    {
                        case nameof(EventStartDate) when _eventStartDate == null:
                            if (CrudOperationType == CrudOperationType.Read)
                            { Error = null; }
                            else
                                Error = "Start date must be set to a date equal to today or later.";
                            break;
                        case nameof(EventStartDate) when _eventEndDate <= _eventStartDate:
                            if (CrudOperationType == CrudOperationType.Read)
                            { Error = null; }
                            else
                                Error = "Start date must be a date before the end date.";
                            break;
                        case nameof(EventEndDate) when _eventEndDate == null:
                            if (CrudOperationType == CrudOperationType.Read)
                            { Error = null; }
                            else
                                Error = "End date must be set to a date equal to today or later.";
                            break;

                        case nameof(EventEndDate) when _eventEndDate <= _eventStartDate:
                            if (CrudOperationType == CrudOperationType.Read)
                            { Error = null; }
                            else
                                Error = "End date must be set to a date later than the start date.";
                            break;
						case nameof(MilestoneEventName) when string.IsNullOrWhiteSpace(_milestoneEventName):
							if (CrudOperationType == CrudOperationType.Read)
							{ Error = null; }
							else
								Error = "Milestone Event Name must not be empty.";
							break;

						default:
                            Error = null;break;
                    }
                    UpdateErrors(propertyName, Error);
                }
                catch (Exception) { }
                return Error;
            }
        }

        #endregion
    }
}
