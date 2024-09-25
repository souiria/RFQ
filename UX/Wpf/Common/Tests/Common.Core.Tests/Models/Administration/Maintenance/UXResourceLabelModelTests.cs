using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class UXResourceLabelModelTests
    {
        [TestMethod]
        public void get_UXLanguageGuid_Returns_MinusNewGuid00000000()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();

            // act
            var result = uXResourceLabelModel.UXLanguageGuid;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void get_UXLanguageGuid_Returns_UXLanguageGuid()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();
            var testGuid = new Guid();
            uXResourceLabelModel.UXLanguageGuid = testGuid;

            // act
            var result = uXResourceLabelModel.UXLanguageGuid;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void get_LabelCode_ReturnsNull()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();

            // act
            var result = uXResourceLabelModel.LabelCode;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_LabelCode_Returns_LabelCode()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();
            uXResourceLabelModel.LabelCode = "LabelCode";

            // act
            var result = uXResourceLabelModel.LabelCode;

            // assert
            Assert.AreEqual("LabelCode", result);
        }

        [TestMethod]
        public void get_LabelValue_ReturnsNull()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();

            // act
            var result = uXResourceLabelModel.LabelValue;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_LabelValue_Returns_LabelValue()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();
            uXResourceLabelModel.LabelValue = "LabelValue";

            // act
            var result = uXResourceLabelModel.LabelValue;

            // assert
            Assert.AreEqual("LabelValue", result);
        }

        [TestMethod]
        public void get_LabelPurpose_ReturnsNull()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();

            // act
            var result = uXResourceLabelModel.LabelPurpose;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_LabelPurpose_Returns_LabelPurpose()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();
            uXResourceLabelModel.LabelPurpose = "LabelPurpose";

            // act
            var result = uXResourceLabelModel.LabelPurpose;

            // assert
            Assert.AreEqual("LabelPurpose", result);
        }

        [TestMethod]
        public void get_IsActive_Returns_IsActive()
        {
            // arrange
            var uXResourceLabelModel = new UXResourceLabelModel();
            uXResourceLabelModel.IsActive = true;

            // act
            var result = uXResourceLabelModel.IsActive;

            // assert
            Assert.IsTrue(result);
        }
    }
}
