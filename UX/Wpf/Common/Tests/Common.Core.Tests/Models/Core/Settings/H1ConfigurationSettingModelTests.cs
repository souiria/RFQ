using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Settings
{
    [TestClass]
    public class H1ConfigurationSettingModelTests
    {
        [TestMethod]
        public void GetH1FunctionGuid_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            var result = h1ConfigurationSettingModel.H1FunctionGuid;
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetH1FunctionGuid_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { H1FunctionGuid = guid };
            var result = h1ConfigurationSettingModel.H1FunctionGuid;
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void SetH1FunctionGuid_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("H1FunctionGuid", e.PropertyName); };
            h1ConfigurationSettingModel.H1FunctionGuid = Guid.NewGuid();
        }

        [TestMethod]
        public void GetH1ModuleGuid_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            var result = h1ConfigurationSettingModel.H1ModuleGuid;
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetH1ModuleGuid_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { H1ModuleGuid = guid };
            var result = h1ConfigurationSettingModel.H1ModuleGuid;
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void SetH1ModuleGuid_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("H1ModuleGuid", e.PropertyName); };
            h1ConfigurationSettingModel.H1ModuleGuid = Guid.NewGuid();
        }

        [TestMethod]
        public void GetH1ConfigurationKeyGuid_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            var result = h1ConfigurationSettingModel.H1ConfigurationKeyGuid;
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetH1ConfigurationKeyGuid_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { H1ConfigurationKeyGuid = guid };
            var result = h1ConfigurationSettingModel.H1ConfigurationKeyGuid;
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void SetH1ConfigurationKeyGuid_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("H1ConfigurationKeyGuid", e.PropertyName); };
            h1ConfigurationSettingModel.H1ConfigurationKeyGuid = Guid.NewGuid();
        }

        [TestMethod]
        public void GetH1ConfigParameterValue_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { H1ConfigParameterValue = "test" };
            var result = h1ConfigurationSettingModel.H1ConfigParameterValue;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetH1ConfigParameterValue_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { H1ConfigParameterValue = "test2" };
            var result = h1ConfigurationSettingModel.H1ConfigParameterValue;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetH1ConfigParameterValue_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("H1ConfigParameterValue", e.PropertyName); };
            h1ConfigurationSettingModel.H1ConfigParameterValue = "test";
        }

        [TestMethod]
        public void GetIsEncrypted_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            var result = h1ConfigurationSettingModel.IsEncrypted;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetIsEncrypted_ReturnsAssignedValue2()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { IsEncrypted = true };
            var result = h1ConfigurationSettingModel.IsEncrypted;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SetIsEncrypted_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("IsEncrypted", e.PropertyName); };
            h1ConfigurationSettingModel.IsEncrypted = true;
        }

        [TestMethod]
        public void GetH1EncryptionKey_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { H1EncryptionKey = "test" };
            var result = h1ConfigurationSettingModel.H1EncryptionKey;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetH1EncryptionKey_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { H1EncryptionKey = "test2" };
            var result = h1ConfigurationSettingModel.H1EncryptionKey;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetH1EncryptionKey_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("H1EncryptionKey", e.PropertyName); };
            h1ConfigurationSettingModel.H1EncryptionKey = "test";
        }

        [TestMethod]
        public void GetIsActive_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            var result = h1ConfigurationSettingModel.IsActive;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GetIsActive_ReturnsAssignedValue2()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { IsActive = false };
            var result = h1ConfigurationSettingModel.IsActive;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetIsActive_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("IsActive", e.PropertyName); };
            h1ConfigurationSettingModel.IsActive = false;
        }

        [TestMethod]
        public void GetRemarks_ReturnsAssignedValue()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { Remarks = "test" };
            var result = h1ConfigurationSettingModel.Remarks;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetRemarks_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel { Remarks = "test2" };
            var result = h1ConfigurationSettingModel.Remarks;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetRemarks_RaisesPropertyChanged()
        {
            var h1ConfigurationSettingModel = new H1ConfigurationSettingModel();
            h1ConfigurationSettingModel.PropertyChanged += (sender, e) => { Assert.AreEqual("Remarks", e.PropertyName); };
            h1ConfigurationSettingModel.Remarks = "test";
        }
    }
}
