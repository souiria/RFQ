using System;
using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class FunctionHierarchyModelTests
    {
        [TestMethod]
        public void GetIsSelected_OnNewObject_ReturnsFalse()
        {
            // arrange
            var functionHierarchyModel = new FunctionHierarchyModel();

            // act
            var result = functionHierarchyModel.IsSelected;

            // assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetIsSelected_AfterAssigning_ReturnsAssignedValue()
        {
            // arrange
            var functionHierarchyModel = new FunctionHierarchyModel { IsSelected = true };

            // act
            var result = functionHierarchyModel.IsSelected;

            // assert
            Assert.IsTrue(result.Value);
        }

        [TestMethod]
        public void GetModules_OnNewObject_ReturnsFalse()
        {
            // arrange
            var functionHierarchyModel = new FunctionHierarchyModel();

            // act
            var result = functionHierarchyModel.Modules;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetModules_AfterAssigning_ReturnsAssignedValue()
        {
            // arrange
            var modules = new ObservableCollection<ModuleHierarchyModel> { new ModuleHierarchyModel { Id = Guid.NewGuid() } };
            var functionHierarchyModel = new FunctionHierarchyModel { Modules = modules };

            // act
            var result = functionHierarchyModel.Modules;

            // assert
            CollectionAssert.AreEqual(modules, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WithH1FunctionMasterModelParam_BeingNull_ThrowsException()
        {
            //arrange //act //assert
            new FunctionHierarchyModel(null);

            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_WithH1FunctionMasterModelParam_IsSuccessful()
        {
            //arrange //act
            var functionHierarchyModel = new FunctionHierarchyModel(new H1FunctionMasterModel());

            //assert
            Assert.IsNotNull(functionHierarchyModel);
        }
    }
}
