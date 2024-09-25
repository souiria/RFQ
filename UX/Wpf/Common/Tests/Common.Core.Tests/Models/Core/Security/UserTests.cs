using System;
using Common.Core.Contracts.Models.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Security
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void GetId_ReturnsAssignedValue()
        {
            var user = new User();

            var result = user.Id;

            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void GetId_ReturnsAssignedValue2()
        {
            var guid = Guid.NewGuid();
            var user = new User { Id = guid };

            var result = user.Id;

            Assert.AreEqual(guid, result);
        }

        [TestMethod]
        public void SetId_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("Id", e.PropertyName); };

            user.Id = Guid.NewGuid();
        }

        [TestMethod]
        public void GetUsername_ReturnsAssignedValue()
        {
            var user = new User { Username = "test" };

            var result = user.Username;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetUsername_ReturnsAssignedValue2()
        {
            var user = new User { Username = "test2" };

            var result = user.Username;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetUsername_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("Username", e.PropertyName); };

            user.Username = "test";
        }

        [TestMethod]
        public void GetName_ReturnsAssignedValue()
        {
            var user = new User { Name = "test" };

            var result = user.Name;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetName_ReturnsAssignedValue2()
        {
            var user = new User { Name = "test2" };

            var result = user.Name;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetName_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("Name", e.PropertyName); };

            user.Name = "test";
        }

        [TestMethod]
        public void GetFirstName_ReturnsAssignedValue()
        {
            var user = new User { FirstName = "test" };

            var result = user.FirstName;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetFirstName_ReturnsAssignedValue2()
        {
            var user = new User { FirstName = "test2" };

            var result = user.FirstName;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetFirstName_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("FirstName", e.PropertyName); };

            user.FirstName = "test";
        }

        [TestMethod]
        public void GetSurname_ReturnsAssignedValue()
        {
            var user = new User { Surname = "test" };

            var result = user.Surname;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetSurname_ReturnsAssignedValue2()
        {
            var user = new User { Surname = "test2" };

            var result = user.Surname;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetSurname_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("Surname", e.PropertyName); };

            user.Surname = "test";
        }

        [TestMethod]
        public void GetEmailAddress_ReturnsAssignedValue()
        {
            var user = new User { EmailAddress = "test" };

            var result = user.EmailAddress;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetEmailAddress_ReturnsAssignedValue2()
        {
            var user = new User { EmailAddress = "test2" };

            var result = user.EmailAddress;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetEmailAddress_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("EmailAddress", e.PropertyName); };

            user.EmailAddress = "test";
        }

        [TestMethod]
        public void GetLogon_ReturnsAssignedValue()
        {
            var user = new User { Logon = "test" };

            var result = user.Logon;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetLogon_ReturnsAssignedValue2()
        {
            var user = new User { Logon = "test2" };

            var result = user.Logon;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetLogon_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("Logon", e.PropertyName); };

            user.Logon = "test";
        }

        [TestMethod]
        public void GetLastLogin_ReturnsAssignedValue()
        {
            var user = new User();

            var result = user.LastLogin;

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetLastLogin_ReturnsAssignedValue2()
        {
            var now = DateTime.UtcNow;
            var user = new User { LastLogin = now };

            var result = user.LastLogin;

            Assert.AreEqual(now, result);
        }

        [TestMethod]
        public void SetLastLogin_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("LastLogin", e.PropertyName); };

            user.LastLogin = DateTime.UtcNow;
        }

        [TestMethod]
        public void GetFirstLogin_ReturnsAssignedValue()
        {
            var user = new User();

            var result = user.FirstLogin;

            Assert.AreEqual(null, result);
        }

        [TestMethod]
        public void GetFirstLogin_ReturnsAssignedValue2()
        {
            var now = DateTime.UtcNow;
            var user = new User { FirstLogin = now };

            var result = user.FirstLogin;

            Assert.AreEqual(now, result);
        }

        [TestMethod]
        public void SetFirstLogin_RaisesPropertyChanged()
        {
            var user = new User();
            user.PropertyChanged += (sender, e) => { Assert.AreEqual("FirstLogin", e.PropertyName); };

            user.FirstLogin = DateTime.UtcNow;
        }

        [TestMethod]
        public void Equals_User_When1stParamIsNull_ReturnsFalse()
        {
            var user = new User();
            var result = user.Equals(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_User_ReturnsFalse()
        {
            var user = new User { Id = Guid.NewGuid() };
            var user2 = new User { Id = Guid.NewGuid() };

            var result = user.Equals(user2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_User_ReturnsTrue()
        {
            var guid = Guid.NewGuid();
            var user = new User { Id = guid };
            var user2 = new User { Id = guid };

            var result = user.Equals(user2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsUser_ReturnsFalse()
        {
            var user = new User { Id = Guid.NewGuid() };
            var user2 = new User { Id = Guid.NewGuid() };
            var result = user.Equals((object)user2);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsUser_ReturnsTrue()
        {
            var guid = Guid.NewGuid();
            var user = new User { Id = guid };
            var user2 = new User { Id = guid };
            var result = user.Equals((object)user2);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsOtherType_ReturnsFalse()
        {
            var user = new User { Id = Guid.NewGuid() };

            var result = user.Equals((object)null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsOtherType_ReturnsFalse2()
        {
            var user = new User { Id = Guid.NewGuid() };

            var result = user.Equals(54);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsGuidHashCode()
        {
            var guidHashCode = Guid.Empty.GetHashCode();
            var user = new User();
            var result = user.GetHashCode();

            Assert.AreEqual(guidHashCode, result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsGuidHashCode2()
        {
            var guid = Guid.NewGuid();
            var guidHashCode = guid.GetHashCode();
            var user = new User { Id = guid };
            var result = user.GetHashCode();

            Assert.AreEqual(guidHashCode, result);
        }
    }
}
