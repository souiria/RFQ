using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class UXRegionsModelTests
    {
        [TestMethod]
        public void get_RegionName_ReturnsNull()
        {
            // arrange
            var uXRegionsModel = new UXRegionsModel();

            // act
            var result = uXRegionsModel.RegionName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_RegionName_Returns_RegionName()
        {
            // arrange
            var uXRegionsModel = new UXRegionsModel();
            uXRegionsModel.RegionName = "RegionName";

            // act
            var result = uXRegionsModel.RegionName;

            // assert
            Assert.AreEqual("RegionName", result);
        }

        [TestMethod]
        public void get_IsRowChecked_ReturnsNull()
        {
            // arrange
            var uXRegionsModel = new UXRegionsModel();

            // act
            uXRegionsModel.IsRowChecked = null;
            var result = uXRegionsModel.IsRowChecked;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_IsRowChecked_Returns_IsRowChecked()
        {
            // arrange
            var uXRegionsModel = new UXRegionsModel();
            uXRegionsModel.IsRowChecked = true;

            // act
            var result = uXRegionsModel.IsRowChecked;

            // assert
            Assert.IsTrue(result.Value);
        }
    }
}
