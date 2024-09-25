using System;
using Common.Core.Contracts.Models.Core.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Logging
{
    [TestClass]
    public class AuditTrailSearchModelTests
    {
        [TestMethod]
        public void GetModelName_ReturnsAssignedValue()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { ModelName = "test" };
            var result = auditTrailSearchModel.ModelName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetModelName_ReturnsAssignedValue2()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { ModelName = "test2" };
            var result = auditTrailSearchModel.ModelName;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void GetMaterialNumber_ReturnsAssignedValue()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { MaterialNumber = "test" };
            var result = auditTrailSearchModel.MaterialNumber;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetMaterialNumber_ReturnsAssignedValue2()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { MaterialNumber = "test2" };
            var result = auditTrailSearchModel.MaterialNumber;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void GetSupplierCode_ReturnsAssignedValue()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { SupplierCode = "test" };
            var result = auditTrailSearchModel.SupplierCode;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetSupplierCode_ReturnsAssignedValue2()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { SupplierCode = "test2" };
            var result = auditTrailSearchModel.SupplierCode;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void GetBusinessUnitCode_ReturnsAssignedValue()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { BusinessUnitCode = "test" };
            var result = auditTrailSearchModel.BusinessUnitCode;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetBusinessUnitCode_ReturnsAssignedValue2()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel { BusinessUnitCode = "test2" };
            var result = auditTrailSearchModel.BusinessUnitCode;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void GetFromDate_ReturnsAssignedValue()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel();
            var result = auditTrailSearchModel.FromDate;
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetFromDate_ReturnsAssignedValue2()
        {
            var now = DateTime.UtcNow;
            var auditTrailSearchModel = new AuditTrailSearchModel { FromDate = now };
            var result = auditTrailSearchModel.FromDate;
            Assert.AreEqual(now, result);
        }

        [TestMethod]
        public void GetToDate_ReturnsAssignedValue()
        {
            var auditTrailSearchModel = new AuditTrailSearchModel();
            var result = auditTrailSearchModel.ToDate;
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetToDate_ReturnsAssignedValue2()
        {
            var now = DateTime.UtcNow;
            var auditTrailSearchModel = new AuditTrailSearchModel { ToDate = now };
            var result = auditTrailSearchModel.ToDate;
            Assert.AreEqual(now, result);
        }
    }
}
