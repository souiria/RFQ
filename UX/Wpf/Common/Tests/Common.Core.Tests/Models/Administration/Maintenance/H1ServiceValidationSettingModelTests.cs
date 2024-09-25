using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class H1ServiceValidationSettingModelTests
    {
        [TestMethod]
        public void get_ServiceName_ReturnsServiceName()
        {
            // arrange
            var h1ServiceValidationSettingModel = new H1ServiceValidationSettingModel();
            h1ServiceValidationSettingModel.ServiceName = "ServiceName";

            // act
            var result = h1ServiceValidationSettingModel.ServiceName;

            // assert
            Assert.AreEqual("ServiceName", result);
        }

        [TestMethod]
        public void get_ReferencedServiceName_Returns_ReferencedServiceName()
        {
            // arrange
            var h1ServiceValidationSettingModel = new H1ServiceValidationSettingModel();
            h1ServiceValidationSettingModel.ReferencedServiceName = "ReferencedServiceName";

            // act
            var result = h1ServiceValidationSettingModel.ReferencedServiceName;

            // assert
            Assert.AreEqual("ReferencedServiceName", result);
        }

        [TestMethod]
        public void get_IsServiceValidationEnabled_Returns_IsServiceValidationEnabled()
        {
            // arrange
            var h1ServiceValidationSettingModel = new H1ServiceValidationSettingModel();
            h1ServiceValidationSettingModel.IsServiceValidationEnabled = true;

            // act
            var result = h1ServiceValidationSettingModel.IsServiceValidationEnabled;

            // assert
            Assert.IsTrue(result);
        }

    }
}