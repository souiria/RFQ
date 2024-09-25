using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Settings.Commercial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Settings
{
    [TestClass]
    public class ServiceConfigTests
    {
        [TestMethod]
        public void GetServiceName_ReturnsAssignedValue()
        {
            var serviceConfig = new ServiceConfig { ServiceName = "test" };
            var result = serviceConfig.ServiceName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetServiceName_ReturnsAssignedValue2()
        {
            var serviceConfig = new ServiceConfig { ServiceName = "test2" };
            var result = serviceConfig.ServiceName;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetServiceName_RaisesPropertyChanged()
        {
            var serviceConfig = new ServiceConfig();
            serviceConfig.PropertyChanged += (sender, e) => { Assert.AreEqual("ServiceName", e.PropertyName); };
            serviceConfig.ServiceName = "test";
        }

        [TestMethod]
        public void GetIsEnabledParameterName_ReturnsAssignedValue()
        {
            var serviceConfig = new ServiceConfig { IsEnabledParameterName = "test" };
            var result = serviceConfig.IsEnabledParameterName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetIsEnabledParameterName_ReturnsAssignedValue2()
        {
            var serviceConfig = new ServiceConfig { IsEnabledParameterName = "test2" };
            var result = serviceConfig.IsEnabledParameterName;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetIsEnabledParameterName_RaisesPropertyChanged()
        {
            var serviceConfig = new ServiceConfig();
            serviceConfig.PropertyChanged += (sender, e) => { Assert.AreEqual("IsEnabledParameterName", e.PropertyName); };
            serviceConfig.IsEnabledParameterName = "test";
        }

        [TestMethod]
        public void GetIsEnabled_ReturnsAssignedValue()
        {
            var serviceConfig = new ServiceConfig();
            var result = serviceConfig.IsEnabled;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetIsEnabled_ReturnsAssignedValue2()
        {
            var serviceConfig = new ServiceConfig { IsEnabled = true };
            var result = serviceConfig.IsEnabled;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SetIsEnabled_RaisesPropertyChanged()
        {
            var serviceConfig = new ServiceConfig();
            serviceConfig.PropertyChanged += (sender, e) => { Assert.AreEqual("IsEnabled", e.PropertyName); };
            serviceConfig.IsEnabled = true;
        }

        [TestMethod]
        public void GetValueParameterName_ReturnsAssignedValue()
        {
            var serviceConfig = new ServiceConfig { ValueParameterName = "test" };
            var result = serviceConfig.ValueParameterName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetValueParameterName_ReturnsAssignedValue2()
        {
            var serviceConfig = new ServiceConfig { ValueParameterName = "test2" };
            var result = serviceConfig.ValueParameterName;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetValueParameterName_RaisesPropertyChanged()
        {
            var serviceConfig = new ServiceConfig();
            serviceConfig.PropertyChanged += (sender, e) => { Assert.AreEqual("ValueParameterName", e.PropertyName); };
            serviceConfig.ValueParameterName = "test";
        }

        [TestMethod]
        public void GetValue_ReturnsAssignedValue()
        {
            var serviceConfig = new ServiceConfig { Value = "test" };
            var result = serviceConfig.Value;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetValue_ReturnsAssignedValue2()
        {
            var serviceConfig = new ServiceConfig { Value = "test2" };
            var result = serviceConfig.Value;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetValue_RaisesPropertyChanged()
        {
            var serviceConfig = new ServiceConfig();
            serviceConfig.PropertyChanged += (sender, e) => { Assert.AreEqual("Value", e.PropertyName); };
            serviceConfig.Value = "test";
        }

        [TestMethod]
        public void GetConnection_ReturnsAssignedConnection()
        {
            var connection = new Connection { Id = Guid.NewGuid() };
            var serviceConfig = new ServiceConfig { Connection = connection };
            var result = serviceConfig.Connection;
            Assert.AreEqual(connection, result);
        }

        [TestMethod]
        public void SetConnection_RaisesPropertyChanged()
        {
            var serviceConfig = new ServiceConfig();
            serviceConfig.PropertyChanged += (sender, e) => { Assert.AreEqual("Connection", e.PropertyName); };
            serviceConfig.Connection = new Connection { Id = Guid.NewGuid() };
        }

        [TestMethod]
        public void GetValueType_ReturnsAssignedValueType()
        {
            var serviceConfig = new ServiceConfig { ValueType = ConfigType.Numbers };
            var result = serviceConfig.ValueType;
            Assert.AreEqual(ConfigType.Numbers, result);
        }

        [TestMethod]
        public void GetValueType_ReturnsAssignedValueType2()
        {
            var serviceConfig = new ServiceConfig { ValueType = ConfigType.Strings };
            var result = serviceConfig.ValueType;
            Assert.AreEqual(ConfigType.Strings, result);
        }

        [TestMethod]
        public void SetValueType_RaisesPropertyChanged()
        {
            var serviceConfig = new ServiceConfig();
            serviceConfig.PropertyChanged += (sender, e) => { Assert.AreEqual("ValueType", e.PropertyName); };
            serviceConfig.ValueType = ConfigType.Strings;
        }

        [TestMethod]
        public void Constructor_String_String_Bool_IsSuccessful()
        {
            var serviceConfig = new ServiceConfig("test", "test2", true);

            Assert.AreEqual("test", serviceConfig.ServiceName);
            Assert.AreEqual("test2", serviceConfig.IsEnabledParameterName);
            Assert.AreEqual(true, serviceConfig.IsEnabled);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_String_String_ConfigType_String_When3rdParamIsNumbers_When4thParamIsNotANumber_ThrowsException()
        {
            new ServiceConfig(null, null, ConfigType.Numbers, "dog");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_String_String_ConfigType_String_When3rdParamIsNumbers_When4thParamWillNotParse_ThrowsException()
        {
            new ServiceConfig(null, null, ConfigType.Numbers, "9" + int.MaxValue.ToString());
        }

        [TestMethod]
        public void Constructor_String_String_ConfigType_String_When3rdParamIsNumbers_IsSuccessful()
        {
            var serviceConfig = new ServiceConfig("test", "test2", ConfigType.Numbers, "4");

            Assert.AreEqual("test", serviceConfig.ServiceName);
            Assert.AreEqual("test2", serviceConfig.ValueParameterName);
            Assert.AreEqual(ConfigType.Numbers, serviceConfig.ValueType);
            Assert.AreEqual("4", serviceConfig.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_String_String_ConfigType_String_When3rdParamIsNotNumbers_When4thParamIsNotAValidType_ThrowsException()
        {
            new ServiceConfig("test", "test2", ConfigType.All, new ServiceConfig());
        }

        [TestMethod]
        public void Constructor_String_String_ConfigType_String_When3rdParamIsNumbers_When4thParamIsNull_IsSuccessful()
        {
            var serviceConfig = new ServiceConfig("test", "test2", ConfigType.Numbers);

            Assert.AreEqual("test", serviceConfig.ServiceName);
            Assert.AreEqual("test2", serviceConfig.ValueParameterName);
            Assert.AreEqual(ConfigType.Numbers, serviceConfig.ValueType);
            Assert.AreEqual("0", serviceConfig.Value);
        }

        [TestMethod]
        public void Constructor_String_String_ConfigType_String_When4thParamIsNull_IsSuccessful()
        {
            var serviceConfig = new ServiceConfig("test", "test2", ConfigType.All);

            Assert.AreEqual("test", serviceConfig.ServiceName);
            Assert.AreEqual("test2", serviceConfig.ValueParameterName);
            Assert.AreEqual(ConfigType.All, serviceConfig.ValueType);
            Assert.IsNull(serviceConfig.Value);
        }

        [TestMethod]
        public void Constructor_String_String_ConfigType_String_IsSuccessful()
        {
            var serviceConfig = new ServiceConfig("test", "test2", ConfigType.Connections, "test3", "test4", false);

            Assert.AreEqual("test", serviceConfig.ServiceName);
            Assert.AreEqual("test2", serviceConfig.ValueParameterName);
            Assert.AreEqual(ConfigType.Connections, serviceConfig.ValueType);
            Assert.AreEqual("test3", serviceConfig.Value);
            Assert.AreEqual("test4", serviceConfig.IsEnabledParameterName);
            Assert.AreEqual(false, serviceConfig.IsEnabled);
        }


    }
}
