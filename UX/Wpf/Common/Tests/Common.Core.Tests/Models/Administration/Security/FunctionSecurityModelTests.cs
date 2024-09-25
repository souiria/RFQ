using System;
using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class FunctionSecurityModelTests
    {
        [TestMethod]
        public void Get_ActiveDirectoryGroup_ReturnsNull()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();

            // act
            var result = functionSecurityModel.ActiveDirectoryGroup;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_ActiveDirectoryGroup_Returns_ActiveDirectoryGroup()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();
            functionSecurityModel.ActiveDirectoryGroup = "ActiveDirectoryGroup";

            // act
            var result = functionSecurityModel.ActiveDirectoryGroup;

            // assert
            Assert.AreEqual("ActiveDirectoryGroup", result);
        }

        [TestMethod]
        public void Get_LabelKey_ReturnsNull()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();

            // act
            var result = functionSecurityModel.LabelKey;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_LabelKey_Returns_LabelKey()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();
            functionSecurityModel.LabelKey = "LabelKey";

            // act
            var result = functionSecurityModel.LabelKey;

            // assert
            Assert.AreEqual("LabelKey", result);
        }

        [TestMethod]
        public void Get_DisplayLabel_ReturnsNull()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();

            // act
            var result = functionSecurityModel.DisplayLabel;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_DisplayLabel_Returns_DisplayLabel()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();
            functionSecurityModel.DisplayLabel = "DisplayLabel";

            // act
            var result = functionSecurityModel.DisplayLabel;

            // assert
            Assert.AreEqual("DisplayLabel", result);
        }

        [TestMethod]
        public void Get_DisplayId_ReturnsZero()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();

            // act
            var result = functionSecurityModel.DisplayId;

            // assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Get_DisplayId_Returns_DisplayId()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();
            functionSecurityModel.DisplayId = 47;

            // act
            var result = functionSecurityModel.DisplayId;

            // assert
            Assert.AreEqual(47, result);
        }

        [TestMethod]
        public void Get_DisplayName_ReturnsNull()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();

            // act
            var result = functionSecurityModel.DisplayName;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_DisplayName_Returns_DisplayName()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();
            functionSecurityModel.DisplayName = "DisplayName";

            // act
            var result = functionSecurityModel.DisplayName;

            // assert
            Assert.AreEqual("DisplayName", result);
        }

        [TestMethod]
        public void Get_ImageSource_ReturnsNull()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();

            // act
            var result = functionSecurityModel.ImageSource;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_ImageSource_Returns_ImageSource()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();
            functionSecurityModel.ImageSource = "ImageSource";

            // act
            var result = functionSecurityModel.ImageSource;

            // assert
            Assert.AreEqual("ImageSource", result);
        }

        [TestMethod]
        public void Get_Modules_ReturnsNull()
        {
            // arrange
            var functionSecurityModel = new FunctionSecurityModel();

            // act
            var result = functionSecurityModel.Modules;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Get_Modules_Returns_Modules()
        {
            // arrange
            var moduleHierarchyModel = new FunctionSecurityModel
            {
                Modules = new ObservableCollection<ModuleSecurityModel>()
            };

            // act
            var result = moduleHierarchyModel.Modules;

            // assert
            CollectionAssert.AreEqual(new ObservableCollection<ModuleSecurityModel>(), result);
        }
    }
}
