using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Settings.Commercial
{
    [DataContract, Serializable]
    public class Connection : BaseModel<Guid>, IEquatable<Connection>
    {
        private string _connectionName;
        [DataMember]
        public string ConnectionName
        {
            get => _connectionName;
            set => SetProperty(ref _connectionName, value);
        }

        private string _connectionValue;
        [DataMember]
        [Required]
        [StringLength(8000)]
        public string ConnectionValue
        {
            get => _connectionValue;
            set => SetProperty(ref _connectionValue, value);
        }

        private bool _isEncrypted = false;
        [DataMember]
        public bool IsEncrypted
        {
            get => _isEncrypted;
            set => SetProperty(ref _isEncrypted, value);
        }

        private string _encryptionKey;
        [DataMember]
        [StringLength(50)]
        public string EncryptionKey
        {
            get => _encryptionKey;
            set => SetProperty(ref _encryptionKey, value);
        }

        public bool Equals(Connection other)
        {
            return other != null && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj is Connection connection)
                return Equals(connection);
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}