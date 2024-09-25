using System;
using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class ModuleHierarchyModelTests
    {
        [TestMethod]
        public void GetViews_ReturnsNull()
        {
            // arrange
            var moduleHierarchyModel = new ModuleHierarchyModel();

            // act
            var result = moduleHierarchyModel.Views;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetViews_IsSuccessful()
        {
            // arrange
            var moduleHierarchyModel = new ModuleHierarchyModel
            {
                Views = new ObservableCollection<ViewHierarchyModel>()
            };

            // act
            var result = moduleHierarchyModel.Views;

            // assert
            CollectionAssert.AreEqual(new ObservableCollection<ViewHierarchyModel>(), result);
        }

        [TestMethod]
        public void GetIsSelected_ReturnsFalse()
        {
            // arrange
            var moduleHierarchyModel = new ModuleHierarchyModel();

            // act
            var result = moduleHierarchyModel.IsSelected;

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetIsSelected_IsSuccessful()
        {
            // arrange
            var moduleHierarchyModel = new ModuleHierarchyModel
            {
                IsSelected = true
            };

            // act
            var result = moduleHierarchyModel.IsSelected;

            // assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ModuleMasterModel_WithNull1stParam_ThrowsException()
        {
            // arrange //act //assert
            var moduleHierarchyModel = new ModuleHierarchyModel(null);

            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_ModuleMasterModel_IsSuccessful()
        {
            // arrange
            var moduleMasterModel = new H1ModuleMasterModel();

            // act
            var moduleHierarchyModel = new ModuleHierarchyModel(moduleMasterModel);

            // assert
            Assert.IsNotNull(moduleHierarchyModel);
        }
    }
}
