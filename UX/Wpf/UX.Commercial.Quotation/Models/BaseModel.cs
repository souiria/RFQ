using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;

namespace UX.Commercial.Quotation.Models
{
    [DataContract, Serializable]
    public abstract class BaseModel<T> : BindableBase, IEntity<T>, IDataErrorInfo, IExtensibleDataObject
    {
        public BaseModel()
        {
            if (typeof(T) == typeof(Guid))
                Id = (T)Convert.ChangeType(Guid.NewGuid(), typeof(T));
        }


        [DataMember, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }
        object IEntity.Id
        {
            get => Id;
            set => Id = (T)Convert.ChangeType(value, typeof(T));
        }

        private string _name;
        [NotMapped, DataMember]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private DateTime? _createdDate;

        [DataMember, DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get => _createdDate ?? DateTime.UtcNow;
            set => SetProperty(ref _createdDate, value);
        }

        private DateTime? _modifiedDate;
        [DataMember, DataType(DataType.DateTime)]
        public DateTime? ModifiedDate
        {
            //Modified By Ajay: 18-Nov-2017
            //It should always record modified date on its own, since same is being done for entities

            //get => _modifiedDate;
            get => _modifiedDate ?? DateTime.UtcNow;
            set => SetProperty(ref _modifiedDate, value);
        }

        private Guid _createdBy;
        [DataMember]
        public Guid CreatedBy
        {
            get => _createdBy;
            set => SetProperty(ref _createdBy, value);
        }

        private Guid _modifiedBy;
        [DataMember]
        public Guid ModifiedBy
        {
            get => _modifiedBy;
            set => SetProperty(ref _modifiedBy, value);
        }

        private bool? _isRowChecked = false;
        [NotMapped, DataMember]
        public bool? IsRowChecked
        {
            get => _isRowChecked;
            set => SetProperty(ref _isRowChecked, value);
        }

        //TODO: Discuss making this field mapped.
        private bool _isActive = true;
        [NotMapped, DataMember]
        public virtual bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        private byte[] _version;
        [NotMapped, DataMember, Timestamp]
        public byte[] Version
        {
            get => _version;
            set => SetProperty(ref _version, value);
        }

        private CrudOperationType _crudOperationType;
        [NotMapped, DataMember]
        public CrudOperationType CrudOperationType
        {
            get => _crudOperationType;
            set => SetProperty(ref _crudOperationType, value);
        }

        public virtual string this[string propertyName] => string.Empty;

        private string _error;
        [NotMapped, DataMember]
        public string Error
        {
            get => _error;
            set => SetProperty(ref _error, value);
        }

        private ExtensionDataObject _theData;
        [NotMapped/*, DataMember*/]
        public virtual ExtensionDataObject ExtensionData { get => _theData; set => _theData = value; }

        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        public void UpdateErrors(string propertyName, string errorMsg)
        {
            if (_errors.ContainsKey(propertyName))
            {
                if (string.IsNullOrEmpty(errorMsg))
                    _errors.Remove(propertyName);
                else
                    _errors[propertyName] = errorMsg;
            }
            else
            {
                if (!string.IsNullOrEmpty(errorMsg))
                    _errors.Add(propertyName, errorMsg);
            }
        }

        public bool HasErrors()
        {
            return _errors.Count > 0;
        }

        public Dictionary<string, string> GetErrors()
        {
            return _errors;
        }
    }
}
