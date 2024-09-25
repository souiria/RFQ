using System;
using Common.Core.Contracts.Models.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Logging
{
    [TestClass]
    public class AuditTrailSqlModelTests
    {
        [TestMethod]
        public void GetMaterialNumber_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { MaterialNumber = "test" };
            var result = auditTrailSqlModel.MaterialNumber;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetMaterialNumber_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { MaterialNumber = "test2" };
            var result = auditTrailSqlModel.MaterialNumber;
            Assert.AreEqual("test2", result);
        }
        [TestMethod]
        public void GetSupplierCode_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { SupplierCode = "test" };
            var result = auditTrailSqlModel.SupplierCode;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetSupplierCode_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { SupplierCode = "test2" };
            var result = auditTrailSqlModel.SupplierCode;
            Assert.AreEqual("test2", result);
        }
        [TestMethod]
        public void GetBusinessUnitCode_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { BusinessUnitCode = "test" };
            var result = auditTrailSqlModel.BusinessUnitCode;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetBusinessUnitCode_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { BusinessUnitCode = "test2" };
            var result = auditTrailSqlModel.BusinessUnitCode;
            Assert.AreEqual("test2", result);
        }
        [TestMethod]
        public void GetModelName_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { ModelName = "test" };
            var result = auditTrailSqlModel.ModelName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetModelName_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { ModelName = "test2" };
            var result = auditTrailSqlModel.ModelName;
            Assert.AreEqual("test2", result);
        }
        [TestMethod]
        public void GetFieldName_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { FieldName = "test" };
            var result = auditTrailSqlModel.FieldName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetFieldName_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { FieldName = "test2" };
            var result = auditTrailSqlModel.FieldName;
            Assert.AreEqual("test2", result);
        }
        [TestMethod]
        public void GetNewValue_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { NewValue = "test" };
            var result = auditTrailSqlModel.NewValue;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetNewValue_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { NewValue = "test2" };
            var result = auditTrailSqlModel.NewValue;
            Assert.AreEqual("test2", result);
        }
        [TestMethod]
        public void GetOldValue_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { OldValue = "test" };
            var result = auditTrailSqlModel.OldValue;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetOldValue_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { OldValue = "test2" };
            var result = auditTrailSqlModel.OldValue;
            Assert.AreEqual("test2", result);
        }
        [TestMethod]
        public void GetAction_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { Action = "test" };
            var result = auditTrailSqlModel.Action;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetAction_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { Action = "test2" };
            var result = auditTrailSqlModel.Action;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void GetItemGuid_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel();
            var result = auditTrailSqlModel.ItemGuid;
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetItemGuid_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var auditTrailSqlModel = new AuditTrailSQLModel { ItemGuid = guid };
            var result = auditTrailSqlModel.ItemGuid;
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void GetBatchGuid_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel();
            var result = auditTrailSqlModel.BatchGuid;
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetBatchGuid_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var auditTrailSqlModel = new AuditTrailSQLModel { BatchGuid = guid };
            var result = auditTrailSqlModel.BatchGuid;
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void GetModifiedByUserName_ReturnsAssignedValue()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { ModifiedByUserName = "test" };
            var result = auditTrailSqlModel.ModifiedByUserName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetModifiedByUserName_ReturnsAssignedValue2()
        {
            var auditTrailSqlModel = new AuditTrailSQLModel { ModifiedByUserName = "test2" };
            var result = auditTrailSqlModel.ModifiedByUserName;
            Assert.AreEqual("test2", result);
        }
    }
}
