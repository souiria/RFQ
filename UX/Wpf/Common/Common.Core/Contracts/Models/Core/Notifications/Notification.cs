using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Notifications
{
    /// <summary>
    /// Represents a notification sent from a Master Service
    /// </summary>    
    [DataContract, Serializable]
    public class Notification : BaseModel<Guid>
    {
        /// <summary>
        /// Gets or sets the header of the notification message
        /// </summary>
        [DataMember]
        public string Header { get; set; }

        /// <summary>
        /// Gets or set the message body of the notification
        /// </summary>
        [DataMember]
        public string Body { get; set; }

        /// <summary>
        /// Gets or set the date the notification was created and sent
        /// </summary>
        [DataMember]
        public DateTime DateSent { get; set; }

        [DataMember]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or set whether the notification has been read by the user
        /// </summary>
        private bool _isRead;
        [DataMember]
        public bool IsRead
        {
            get => _isRead;
            set => SetProperty(ref _isRead, value);
        }
    }
}
