/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProjectModel.cs
Function           :   Project Model
Created By         :   Pawan Kumar
Created on         :   31-Jul-2019
Revision History   :   [15-Oct-2019] : Pawan
                   :   [ ] : Removed validation from Project Code as it is automatically populated 
                   :   [18-Oct-2019] : Aditya
                   :   [ ] : Removed VehicleVolumePerAnnum 
                   
****************************************************************************************************/
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters.Project
{
    [DataContract]
    public class ProjectModel : BaseModel<Guid>, IValidatable
    {
        //private CustomerLocationModel _location;

        //[DataMember]
        //public CustomerLocationModel Location
        //{
        //    get => _location;
        //    set => SetProperty(ref _location, value);
        //}

        private Guid _customerLocationId;

        [DataMember]
        public Guid CustomerLocationId
        {
            get => _customerLocationId;
            set => SetProperty(ref _customerLocationId, value);
        }

        private string _projectCode;

        [DataMember]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        private string _project;

        [DataMember]
        public string Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        private string _customerProjectCode;

        [DataMember]
        public string CustomerProjectCode
        {
            get => _customerProjectCode;
            set => SetProperty(ref _customerProjectCode, value);
        }

        private string _description;

        [DataMember]
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        private int _annualVolume;

        [DataMember]
        public int AnnualVolume
        {
            get => _annualVolume;
            set => SetProperty(ref _annualVolume, value);
        }

       



        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property])) ;

        private static readonly string[] ValidatedProperties =
        {
            nameof(Project),
            nameof(ProjectCode),
            nameof(CustomerLocationId),
            nameof(CustomerProjectCode)
        };

        public override string this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case nameof(Project) when string.IsNullOrWhiteSpace(_project):
                        return "Project must not be empty";

                    //case nameof(ProjectCode) when string.IsNullOrWhiteSpace(_projectCode):
                    //    return "Project Code must not be empty";

                    case nameof(CustomerLocationId) when _customerLocationId == Guid.Empty:
                        return "Customer must not be empty";

                    case nameof(CustomerProjectCode) when string.IsNullOrWhiteSpace(_customerProjectCode):
                        return "Customer Project Code must not be empty";

                    default:
                        return null;
                }
            }
        }
    }
}
