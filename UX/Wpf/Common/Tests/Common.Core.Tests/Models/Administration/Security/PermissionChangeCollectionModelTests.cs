using System;
using System.Collections.Generic;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class PermissionChangeCollectionModelTests
    {
        [TestMethod]
        public void GetRoles_ReturnsNotNull()
        {
            //arrange
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel();

            //act
            var result = permissionChangeCollectionModel.Roles;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetRoles_IsSuccessful()
        {
            //arrange
            var roles = new List<Group> { new Group(Guid.NewGuid(), "Group") };
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel
            {
                Roles = roles
            };

            //act
            var result = permissionChangeCollectionModel.Roles;

            //assert
            CollectionAssert.AreEqual(roles, result);
        }

        [TestMethod]
        public void GetViews_ReturnsNotNull()
        {
            //arrange
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel();

            //act
            var result = permissionChangeCollectionModel.Views;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetViews_IsSuccessful()
        {
            //arrange
            var views = new List<ViewHierarchyModel> { new ViewHierarchyModel() };
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel
            {
                Views = views
            };

            //act
            var result = permissionChangeCollectionModel.Views;

            //assert
            CollectionAssert.AreEqual(views, result);
        }

        [TestMethod]
        public void GetFields_ReturnsNotNull()
        {
            //arrange
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel();

            //act
            var result = permissionChangeCollectionModel.Fields;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetFields_IsSuccessful()
        {
            //arrange
            var fields = new List<FieldHierarchyModel> { new FieldHierarchyModel() };
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel
            {
                Fields = fields
            };

            //act
            var result = permissionChangeCollectionModel.Fields;

            //assert
            CollectionAssert.AreEqual(fields, result);
        }

        [TestMethod]
        public void GetOwnedModules_ReturnsNotNull()
        {
            //arrange
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel();

            //act
            var result = permissionChangeCollectionModel.OwnedModules;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetOwnedModules_IsSuccessful()
        {
            //arrange
            var ownedModules = new List<ModuleOwnerModel> { new ModuleOwnerModel(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()) };
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel
            {
                OwnedModules = ownedModules
            };

            //act
            var result = permissionChangeCollectionModel.OwnedModules;

            //assert
            CollectionAssert.AreEqual(ownedModules, result);
        }

        [TestMethod]
        public void Constructor_Groups_IsSuccessful()
        {
            //arrange
            var groups = new List<Group> { new Group(Guid.NewGuid(), "Group") };

            //act
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel(groups);

            //assert
            Assert.IsNotNull(permissionChangeCollectionModel);
        }

        [TestMethod]
        public void Constructor_ViewHierarchyModels_FieldHierarchyModels_IsSuccessful()
        {
            //arrange
            var views = new List<ViewHierarchyModel> { new ViewHierarchyModel() };
            var fields = new List<FieldHierarchyModel> { new FieldHierarchyModel() };

            //act
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel(views, fields);

            //assert
            CollectionAssert.AreEqual(views, permissionChangeCollectionModel.Views);
            CollectionAssert.AreEqual(fields, permissionChangeCollectionModel.Fields);
        }

        [TestMethod]
        public void Constructor_Groups_ViewHierarchyModels_FieldHierarchyModels_ModuleOwnerModels_IsSuccessful()
        {
            //arrange
            var roles = new List<Group> { new Group() };
            var views = new List<ViewHierarchyModel> { new ViewHierarchyModel() };
            var fields = new List<FieldHierarchyModel> { new FieldHierarchyModel() };
            var ownedModules = new List<ModuleOwnerModel> { new ModuleOwnerModel() };

            //act
            var permissionChangeCollectionModel = new PermissionChangeCollectionModel(roles, views, fields, ownedModules);

            //assert
            CollectionAssert.AreEqual(roles, permissionChangeCollectionModel.Roles);
            CollectionAssert.AreEqual(views, permissionChangeCollectionModel.Views);
            CollectionAssert.AreEqual(fields, permissionChangeCollectionModel.Fields);
            CollectionAssert.AreEqual(ownedModules, permissionChangeCollectionModel.OwnedModules);
        }

    }
}
