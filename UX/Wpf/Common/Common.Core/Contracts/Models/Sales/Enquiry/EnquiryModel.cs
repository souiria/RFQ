using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Sales.Enquiry
{
    [DataContract]
    public class EnquiryModel : BaseModel<Guid>
    {
        private Guid _userId;

        [DataMember]
        public Guid UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        private string _username;

        [DataMember]
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private string _userEmail;

        [DataMember]
        public string UserEmail
        {
            get => _userEmail;
            set => SetProperty(ref _userEmail, value);
        }

        private Guid _customerId;

        [DataMember]
        public Guid CustomerId
        {
            get => _customerId;
            set => SetProperty(ref _customerId, value);
        }

        private string _customerName;

        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        private Guid _projectId;

        [DataMember]
        public Guid ProjectId
        {
            get => _projectId;
            set => SetProperty(ref _projectId, value);
        }
    }
}
