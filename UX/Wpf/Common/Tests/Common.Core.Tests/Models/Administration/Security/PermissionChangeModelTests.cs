using System;
using System.Collections.Generic;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class PermissionChangeModelTests
    {
        [TestMethod]
        public void GetId_ReturnsEmptyGuid()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.Id;

            //assert
            Assert.AreNotEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var permissionChangeModel = new PermissionChangeModel
            {
                Id = id
            };

            //act
            var result = permissionChangeModel.Id;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetHelpdeskId_ReturnsNull()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.HelpdeskId;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetHelpdeskId_IsSuccessful()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel
            {
                HelpdeskId = "HelpdeskId"
            };

            //act
            var result = permissionChangeModel.HelpdeskId;

            //assert
            Assert.AreEqual("HelpdeskId", result);
        }

        [TestMethod]
        public void GetHelpdeskDesc_ReturnsNull()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.HelpdeskDesc;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetHelpdeskDesc_IsSuccessful()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel
            {
                HelpdeskDesc = "HelpdeskDesc"
            };

            //act
            var result = permissionChangeModel.HelpdeskDesc;

            //assert
            Assert.AreEqual("HelpdeskDesc", result);
        }

        [TestMethod]
        public void GetUserGuid_ReturnsEmptyGuid()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.UserGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetUserGuid_IsSuccessful()
        {
            //arrange
            var guid = Guid.NewGuid();
            var permissionChangeModel = new PermissionChangeModel
            {
                UserGuid = guid
            };

            //act
            var result = permissionChangeModel.UserGuid;

            //assert
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void GetCreatedDate_ReturnsNotDefaultDateTime()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.CreatedDate;

            //assert
            Assert.AreNotEqual(default(DateTime), result);
        }

        [TestMethod]
        public void SetCreatedDate_IsSuccessful()
        {
            //arrange
            var dateTime = DateTime.UtcNow;
            var permissionChangeModel = new PermissionChangeModel
            {
                CreatedDate = dateTime
            };

            //act
            var result = permissionChangeModel.CreatedDate;

            //assert
            Assert.AreEqual(dateTime, result);
        }

        [TestMethod]
        public void GetCreatedBy_ReturnsNull()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.CreatedBy;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetCreatedBy_IsSuccessful()
        {
            //arrange
            var guid = Guid.NewGuid();
            var permissionChangeModel = new PermissionChangeModel
            {
                CreatedBy = guid
            };

            //act
            var result = permissionChangeModel.CreatedBy;

            //assert
            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void GetAdded_ReturnsNotNull()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.Added;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetAdded_IsSuccessful()
        {
            //arrange
            var added = new PermissionChangeCollectionModel(new List<Group>
            {
                new Group(Guid.NewGuid(), "Group")
            });
            var permissionChangeModel = new PermissionChangeModel
            {
                Added = added
            };

            //act
            var result = permissionChangeModel.Added;

            //assert
            Assert.AreEqual(added, result);
        }

        [TestMethod]
        public void GetRemoved_ReturnsNotNull()
        {
            //arrange
            var permissionChangeModel = new PermissionChangeModel();

            //act
            var result = permissionChangeModel.Removed;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetRemoved_IsSuccessful()
        {
            //arrange
            var removed = new PermissionChangeCollectionModel(new List<Group>
            {
                new Group(Guid.NewGuid(), "Group")
            });
            var permissionChangeModel = new PermissionChangeModel
            {
                Removed = removed
            };

            //act
            var result = permissionChangeModel.Removed;

            //assert
            Assert.AreEqual(removed, result);
        }

        [TestMethod]
        public void Constructor_Guid_NullableGuid_IsSuccessful()
        {
            //arrange
            var guid = Guid.NewGuid();

            //act
            var permissionChangeModel = new PermissionChangeModel(guid, null);

            //assert
            Assert.IsNotNull(permissionChangeModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Guid_NullableGuid_PermissionChangeCollectionModel_WithNull3rdParam_ThrowsException()
        {
            //arrange //act //assert
            new PermissionChangeModel(Guid.Empty, null, null);

            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_Guid_NullableGuid_PermissionChangeCollectionModel_IsSuccessful()
        {
            //arrange
            var added = new PermissionChangeCollectionModel(new List<Group>
            {
                new Group(Guid.NewGuid(), "Group")
            });

            //act
            var permissionChangeModel = new PermissionChangeModel(Guid.Empty, null, added);

            //assert
            Assert.IsNotNull(permissionChangeModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Guid_NullableGuid_PermissionChangeCollectionModel_PermissionChangeCollectionModel_WithNull3rdParam_ThrowsException()
        {
            //arrange 
            var removed = new PermissionChangeCollectionModel();

            //act //assert
            new PermissionChangeModel(Guid.Empty, null, null, removed);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_Guid_NullableGuid_PermissionChangeCollectionModel_PermissionChangeCollectionModel_WithNull4thParam_ThrowsException()
        {
            //arrange 
            var added = new PermissionChangeCollectionModel();

            //act //assert
            new PermissionChangeModel(Guid.Empty, null, added, null);

            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_Guid_NullableGuid_PermissionChangeCollectionModel_PermissionChangeCollectionModel_IsSuccessful()
        {
            //arrange
            var added = new PermissionChangeCollectionModel();
            var removed = new PermissionChangeCollectionModel(new List<Group>
            {
                new Group(Guid.NewGuid(), "Group")
            });

            //act
            var permissionChangeModel = new PermissionChangeModel(Guid.Empty, null, added, removed);

            //assert
            Assert.IsNotNull(permissionChangeModel);
        }
    }
}
