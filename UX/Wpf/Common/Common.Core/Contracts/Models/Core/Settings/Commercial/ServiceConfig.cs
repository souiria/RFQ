using System;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Settings.Commercial
{
    /// <summary>
    /// A model that represents configurations for services. This is the model used by the H1ServiceSettings service.
    /// </summary>
    [DataContract, Serializable]
    public class ServiceConfig : BaseModel<Guid>
    {

        private string _serviceName;
        /// <summary>
        /// The name of the service the configuration belongs to.
        /// </summary>
        [DataMember]
        public string ServiceName
        {
            get => _serviceName;
            set => SetProperty(ref _serviceName, value);
        }

        private string _isEnabledParameterName;
        /// <summary>
        /// The name of the service property that will contain whether the configuration is enabled or disabled.
        /// </summary>
        [DataMember]
        public string IsEnabledParameterName
        {
            get => _isEnabledParameterName;
            set => SetProperty(ref _isEnabledParameterName, value);
        }

        private bool _isEnabled;
        /// <summary>
        /// Whether the configuration is enabled or disabled.
        /// </summary>
        [DataMember]
        public bool IsEnabled
        {
            get => _isEnabled;
            set => SetProperty(ref _isEnabled, value);
        }

        private string _valueParameterName;
        /// <summary>
        /// The name of the service property that will contain the value of the service configuration.
        /// </summary>
        [DataMember]
        public string ValueParameterName
        {
            get => _valueParameterName;
            set => SetProperty(ref _valueParameterName, value);
        }

        //TODO: Modify the value property to be of an object type that can store a string, int or Connection type. This will depreciate the Connection property.

        private string _value;
        /// <summary>
        /// The value of this service configuration.
        /// </summary>
        [DataMember]
        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        private Connection _connection;
        /// <summary>
        /// The value of this service configuration if the value to be stored is of a connection type.
        /// </summary>
        [DataMember]
        public Connection Connection
        {
            get => _connection;
            set => SetProperty(ref _connection, value);
        }

        private ConfigType _valueType;
        /// <summary>
        /// The value type that this service configuration contains.
        /// </summary>
        [DataMember]
        public ConfigType ValueType
        {
            get => _valueType;
            set => SetProperty(ref _valueType, value);
        }
        /// <summary>
        /// Creates a new empty <see cref="ServiceConfig"/>.
        /// </summary>
        public ServiceConfig()
        { }

        /// <summary>
        /// Creates a new <see cref="ServiceConfig"/> which has no value and only implements an toggle to enabled or disable the setting.
        /// </summary>
        /// <param name="serviceName">The name of the service this setting belongs to</param>
        /// <param name="isEnabledParameterName">The name of the IsEnabled parameter. This must match the name of the property in your service.</param>
        /// <param name="isEnabledDefault">The value that decide whether the setting is enabled or disabled by default</param>
        public ServiceConfig(string serviceName, string isEnabledParameterName, bool isEnabledDefault)
        {
            ServiceName = serviceName;
            IsEnabledParameterName = isEnabledParameterName;
            IsEnabled = isEnabledDefault;

            ValueParameterName = null;
            Value = null;
            ValueType = ConfigType.All;
        }

        /// <summary>
        /// Creates a new <see cref="ServiceConfig"/> which implements a modifiable value and is always enabled.
        /// can manipulate about the created setting.
        /// </summary>
        /// <param name="serviceName">The name of the service this setting belongs to</param>
        /// <param name="valueParameterName">The name of the modifiable value parameter. This must match the name of the property in your service.</param>
        /// <param name="valueType">The type of the value to be stored</param>
        /// <param name="defaultValue">The value that is set when the setting is first created</param>
        /// <param name="isEnabledParameterName">The name of the property that contains the IsEnabled value in the service.</param>
        /// <param name="isEnabled">Whether the setting is enabled or disabled.</param>
        public ServiceConfig(string serviceName, string valueParameterName, ConfigType valueType, object defaultValue = null, string isEnabledParameterName = null, bool isEnabled = true)
        {
            ServiceName = serviceName;
            ValueParameterName = valueParameterName;
            ValueType = valueType;
            IsEnabled = isEnabled;
            IsEnabledParameterName = isEnabledParameterName;

            //Validation
            if (defaultValue != null)
            {
                switch (valueType)
                {
                    case ConfigType.Numbers:
                        if (IsValueValidType(defaultValue, ConfigType.Numbers) && int.TryParse(defaultValue.ToString(), out _))
                            Value = defaultValue.ToString();
                        else
                            throw new ArgumentException(nameof(defaultValue));
                        break;

                    default:
                        if (IsValueValidType(defaultValue, ConfigType.All))
                            Value = defaultValue.ToString();
                        else
                            throw new ArgumentException(nameof(defaultValue));
                        break;
                }
            }
            else
            {
                switch (valueType)
                {
                    case ConfigType.Numbers:
                        Value = default(int).ToString();
                        break;

                    default:
                        Value = null;
                        break;
                }
            }
        }

        private bool IsValueValidType(object obj, ConfigType valueType)
        {
            switch (valueType)
            {
                case ConfigType.All:
                    return obj is Connection || obj is string || obj is int;

                case ConfigType.Connections:
                    return obj is Connection;

                case ConfigType.Numbers:
                    return obj is string || obj is int;

                case ConfigType.Strings:
                    return obj is string;

                default:
                    throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null);
            }
        }
    }
}
