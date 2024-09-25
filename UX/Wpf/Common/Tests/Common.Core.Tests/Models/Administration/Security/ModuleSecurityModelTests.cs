using System;
using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class ModuleSecurityModelTests
    {
        [TestMethod]
        public void GetActiveDirectoryGroup_ReturnsNull()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.ActiveDirectoryGroup;

            //assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void SetActiveDirectoryGroup_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                ActiveDirectoryGroup = "ActiveDirectoryGroup"
            };

            //act
            var result = moduleSecurityModel.ActiveDirectoryGroup;

            //assert
            Assert.AreEqual("ActiveDirectoryGroup", result);
        }

        [TestMethod]
        public void GetLabelKey_ReturnsNull()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.LabelKey;

            //assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void SetLabelKey_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                LabelKey = "LabelKey"
            };

            //act
            var result = moduleSecurityModel.LabelKey;

            //assert
            Assert.AreEqual("LabelKey", result);
        }

        [TestMethod]
        public void GetDisplayId_ReturnsZero()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.DisplayId;

            //assert
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void SetDisplayId_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                DisplayId = 12
            };

            //act
            var result = moduleSecurityModel.DisplayId;

            //assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void GetParentDisplayId_ReturnsZero()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.ParentDisplayId;

            //assert
            Assert.AreEqual(0, result);
        }


        [TestMethod]
        public void SetParentDisplayId_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                ParentDisplayId = 35
            };

            //act
            var result = moduleSecurityModel.ParentDisplayId;

            //assert
            Assert.AreEqual(35, result);
        }

        [TestMethod]
        public void GetDisplayLabel_ReturnsNull()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.DisplayLabel;

            //assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void SetDisplayLabel_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                DisplayLabel = "DisplayLabel"
            };

            //act
            var result = moduleSecurityModel.DisplayLabel;

            //assert
            Assert.AreEqual("DisplayLabel", result);
        }

        [TestMethod]
        public void GetDisplayName_ReturnsNull()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.DisplayName;

            //assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void SetDisplayName_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                DisplayName = "DisplayName"
            };

            //act
            var result = moduleSecurityModel.DisplayName;

            //assert
            Assert.AreEqual("DisplayName", result);
        }

        [TestMethod]
        public void GetImageSource_ReturnsNull()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.ImageSource;

            //assert
            Assert.IsNull(result);
        }


        [TestMethod]
        public void SetImageSource_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                ImageSource = "ImageSource"
            };

            //act
            var result = moduleSecurityModel.ImageSource;

            //assert
            Assert.AreEqual("ImageSource", result);
        }

        [TestMethod]
        public void GetIsExpanded_ReturnsTrue()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.IsExpanded;

            //assert
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void SetIsExpanded_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                IsExpanded = false
            };

            //act
            var result = moduleSecurityModel.IsExpanded;

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetIsSelected_ReturnsFalse()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            //act
            var result = moduleSecurityModel.IsSelected;

            //assert
            Assert.AreEqual(false, result);
        }


        [TestMethod]
        public void SetIsSelected_IsSuccessful()
        {
            //arrange
            var moduleSecurityModel = new ModuleSecurityModel
            {
                IsSelected = null
            };

            //act
            var result = moduleSecurityModel.IsSelected;

            //assert
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetViews_ReturnsNull()
        {
            // arrange
            var moduleSecurityModel = new ModuleSecurityModel();

            // act
            var result = moduleSecurityModel.Views;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetViews_IsSuccessful()
        {
            // arrange
            var moduleHierarchyModel = new ModuleSecurityModel
            {
                Views = new ObservableCollection<ViewSecurityModel>()
            };

            // act
            var result = moduleHierarchyModel.Views;

            // assert
            CollectionAssert.AreEqual(new ObservableCollection<ViewSecurityModel>(), result);
        }
    }
}
