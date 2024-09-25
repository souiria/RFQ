using System;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class FieldSecurityModelTests
    {
        [TestMethod]
        public void Get_DisplayName_ReturnsNull()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();

            // act
            var result = fieldSecurityModel.DisplayName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_DisplayName_Returns_DisplayName()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();
            fieldSecurityModel.DisplayName = "DisplayName";

            // act
            var result = fieldSecurityModel.DisplayName;

            // assert
            Assert.AreEqual("DisplayName", result);
        }

        [TestMethod]
        public void Get_LabelKey_ReturnsNull()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();

            // act
            var result = fieldSecurityModel.LabelKey;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_LabelKey_Returns_LabelKey()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();
            fieldSecurityModel.LabelKey = "LabelKey";

            // act
            var result = fieldSecurityModel.LabelKey;

            // assert
            Assert.AreEqual("LabelKey", result);
        }

        [TestMethod]
        public void Get_VariableName_ReturnsNull()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();

            // act
            var result = fieldSecurityModel.VariableName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_VariableName_Returns_VariableName()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();
            fieldSecurityModel.VariableName = "VariableName";

            // act
            var result = fieldSecurityModel.VariableName;

            // assert
            Assert.AreEqual("VariableName", result);
        }

        [TestMethod]
        public void Get_ParentViewId_ReturnsMinusNewGuid00000000()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();

            // act
            var result = fieldSecurityModel.ParentViewId;

            // assert
            Assert.AreEqual(new Guid("00000000-0000-0000-0000-000000000000"), result);
        }

        [TestMethod]
        public void Set_ParentViewId_Returns_ParentViewId()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();
            var testGuid = new Guid();

            // act
            fieldSecurityModel.ParentViewId = testGuid;
            var result = fieldSecurityModel.ParentViewId;

            // assert
            Assert.AreEqual(testGuid, result);
        }

        [TestMethod]
        public void Get_IsSelected_Returns_False()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel();

            // act
            var result = fieldSecurityModel.IsSelected;

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Get_IsSelected_Returns_IsSelected()
        {
            // arrange
            var fieldSecurityModel = new FieldSecurityModel()
            {
                IsSelected = null
            };

            // act
            var result = fieldSecurityModel.IsSelected;

            // assert
            Assert.AreEqual(null, result);
        }
    }
}
