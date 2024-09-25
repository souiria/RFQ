using System;
using System.Collections.Generic;
using Common.Core.Contracts.Models.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Security
{
    [TestClass]
    public class GroupTests
    {
        [TestMethod]
        public void GetId_ReturnsAssignedValue()
        {
            var group = new Group();
            var guid = Guid.NewGuid();
            group.Id = guid;
            Assert.AreEqual(guid, group.Id);
        }

        [TestMethod]
        public void GetId_ReturnsAssignedValue2()
        {
            var group = new Group();
            Assert.AreEqual(Guid.Empty, group.Id);
        }

        [TestMethod]
        public void GetActiveDirectoryName_ReturnsAssignedValue()
        {
            var group = new Group();
            group.ActiveDirectoryName = "test";
            Assert.AreEqual("test", group.ActiveDirectoryName);
        }

        [TestMethod]
        public void GetActiveDirectoryName_ReturnsAssignedValue2()
        {
            var group = new Group();
            group.ActiveDirectoryName = "test2";
            Assert.AreEqual("test2", group.ActiveDirectoryName);
        }

        [TestMethod]
        public void GetMemberOf_ReturnsAssignedValue()
        {
            var group = new Group();
            var data = new List<string> { "test", "test2", "test3" };
            group.MemberOf = data;
            CollectionAssert.AreEqual(data, group.MemberOf);
        }

        [TestMethod]
        public void GetMemberOf_ReturnsAssignedValue2()
        {
            var group = new Group();
            var data = new List<string> { "test4" };
            group.MemberOf = data;
            CollectionAssert.AreEqual(data, group.MemberOf);
        }

        [TestMethod]
        public void GetIsSelected_ReturnsAssignedValue()
        {
            var group = new Group();
            group.IsSelected = true;
            Assert.AreEqual(true, group.IsSelected);
        }

        [TestMethod]
        public void GetIsSelected_ReturnsAssignedValue2()
        {
            var group = new Group();
            group.IsSelected = false;
            Assert.AreEqual(false, group.IsSelected);
        }

        [TestMethod]
        public void SetIsSelected_RaisesPropertyChanged()
        {
            var group = new Group();
            group.PropertyChanged += (sender, e) => { Assert.AreEqual("IsSelected", e.PropertyName); };


            group.IsSelected = true;
        }

        [TestMethod]
        public void Equals_Group_When1stParamIsNull_ReturnsFalse()
        {
            var group = new Group();
            var result = group.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Group_ReturnsFalse()
        {
            var group = new Group { Id = Guid.NewGuid() };
            var group2 = new Group { Id = Guid.NewGuid() };

            var result = group.Equals(group2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Equals_Group_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            var group = new Group { Id = id };
            var group2 = new Group { Id = id };

            var result = group.Equals(group2);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsNull_ReturnsFalse()
        {
            var group = new Group();
            var result = group.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_WithGroup_ReturnsFalse()
        {
            var group = new Group { Id = Guid.NewGuid() };
            var group2 = new Group { Id = Guid.NewGuid() };

            var result = group.Equals((object)group2);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Equals_Object_WithGroup_ReturnsTrue()
        {
            var id = Guid.NewGuid();
            var group = new Group { Id = id };
            var group2 = new Group { Id = id };

            var result = group.Equals((object)group2);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Equals_Object_WithOtherType_ReturnsFalse()
        {
            var group = new Group { Id = Guid.NewGuid() };

            var result = group.Equals(32);

            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsGuidHashCode()
        {
            var emptyGuidHashCode = Guid.Empty.GetHashCode();
            var group = new Group();
            var result = group.GetHashCode();

            Assert.AreEqual(emptyGuidHashCode, result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsGuidHashCode2()
        {
            var guid = Guid.NewGuid();
            var guidHashCode = guid.GetHashCode();
            var group = new Group { Id = guid };
            var result = group.GetHashCode();

            Assert.AreEqual(guidHashCode, result);
        }

        [TestMethod]
        public void Constructor_Guid_String_IsSuccessful()
        {
            var group = new Group(Guid.Empty, null);

            Assert.AreEqual(Guid.Empty, group.Id);
            Assert.AreEqual(null, group.ActiveDirectoryName);
        }

        [TestMethod]
        public void Constructor_Guid_String_IsSuccessful2()
        {
            var guid = Guid.NewGuid();
            var group = new Group(guid, "test");

            Assert.AreEqual(guid, group.Id);
            Assert.AreEqual("test", group.ActiveDirectoryName);
        }
    }
}
