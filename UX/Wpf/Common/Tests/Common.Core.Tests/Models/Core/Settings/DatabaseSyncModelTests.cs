using System;
using Common.Core.Contracts.Models.Core.Settings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Settings
{
    [TestClass]
    public class DatabaseSyncModelTests
    {
        [TestMethod]
        public void GetIsDatabaseSyncEnabled_ReturnsAssignedValue()
        {
            var databaseSyncModel = new DatabaseSyncModel { IsDatabaseSyncEnabled = null };
            var result = databaseSyncModel.IsDatabaseSyncEnabled;
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetIsDatabaseSyncEnabled_ReturnsAssignedValue2()
        {
            var databaseSyncModel = new DatabaseSyncModel { IsDatabaseSyncEnabled = false };
            var result = databaseSyncModel.IsDatabaseSyncEnabled;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetIsDatabaseSyncEnabled_RaisesPropertyChanged()
        {
            var databaseSyncModel = new DatabaseSyncModel();
            databaseSyncModel.PropertyChanged += (sender, e) => { Assert.AreEqual("IsDatabaseSyncEnabled", e.PropertyName); };
            databaseSyncModel.IsDatabaseSyncEnabled = null;
        }

        [TestMethod]
        public void GetH1ConfigurationSettingGuid_ReturnsAssignedValue()
        {
            var databaseSyncModel = new DatabaseSyncModel();
            var result = databaseSyncModel.H1ConfigurationSettingGuid;
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetH1ConfigurationSettingGuid_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var databaseSyncModel = new DatabaseSyncModel { H1ConfigurationSettingGuid = guid };
            var result = databaseSyncModel.H1ConfigurationSettingGuid;
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void SetH1ConfigurationSettingGuid_RaisesPropertyChanged()
        {
            var databaseSyncModel = new DatabaseSyncModel();
            databaseSyncModel.PropertyChanged += (sender, e) => { Assert.AreEqual("H1ConfigurationSettingGuid", e.PropertyName); };
            databaseSyncModel.H1ConfigurationSettingGuid = Guid.NewGuid();
        }
    }
}
