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
    public class H1ConfigurationKeyModelTests
    {
        [TestMethod]
        public void GetKeyName_ReturnsAssignedValue()
        {
            var h1ConfigurationKeyModel = new H1ConfigurationKeyModel { KeyName = "test" };
            var result = h1ConfigurationKeyModel.KeyName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetKeyName_ReturnsAssignedValue2()
        {
            var h1ConfigurationKeyModel = new H1ConfigurationKeyModel { KeyName = "test2" };
            var result = h1ConfigurationKeyModel.KeyName;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetKeyName_RaisesPropertyChanged()
        {
            var h1ConfigurationKeyModel = new H1ConfigurationKeyModel();
            h1ConfigurationKeyModel.PropertyChanged += (sender, e) => { Assert.AreEqual("KeyName", e.PropertyName); };
            h1ConfigurationKeyModel.KeyName = "test";
        }

        [TestMethod]
        public void GetIsActive_ReturnsAssignedValue()
        {
            var h1ConfigurationKeyModel = new H1ConfigurationKeyModel();
            var result = h1ConfigurationKeyModel.IsActive;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GetIsActive_ReturnsAssignedValue2()
        {
            var h1ConfigurationKeyModel = new H1ConfigurationKeyModel { IsActive = false };
            var result = h1ConfigurationKeyModel.IsActive;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetIsActive_RaisesPropertyChanged()
        {
            var h1ConfigurationKeyModel = new H1ConfigurationKeyModel();
            h1ConfigurationKeyModel.PropertyChanged += (sender, e) => { Assert.AreEqual("IsActive", e.PropertyName); };
            h1ConfigurationKeyModel.IsActive = false;
        }
    }
}
