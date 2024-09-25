using System;
using Common.Core.Contracts.Models.Core.Settings.Commercial;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Settings
{
    [TestClass]
    public class ConnectionTests
    {
        [TestMethod]
        public void GetConnectionName_ReturnsAssignedResults()
        {
            var connection = new Connection { ConnectionName = "test" };
            var result = connection.ConnectionName;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetConnectionName_ReturnsAssignedResults2()
        {
            var connection = new Connection { ConnectionName = "test2" };
            var result = connection.ConnectionName;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetConnectionName_RaisesPropertyChanged()
        {
            var connection = new Connection();
            connection.PropertyChanged += (sender, e) => { Assert.AreEqual("ConnectionName", e.PropertyName); };
            connection.ConnectionName = "test";
        }

        [TestMethod]
        public void GetConnectionValue_ReturnsAssignedResults()
        {
            var connection = new Connection { ConnectionValue = "test" };
            var result = connection.ConnectionValue;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetConnectionValue_ReturnsAssignedResults2()
        {
            var connection = new Connection { ConnectionValue = "test2" };
            var result = connection.ConnectionValue;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetConnectionValue_RaisesPropertyChanged()
        {
            var connection = new Connection();
            connection.PropertyChanged += (sender, e) => { Assert.AreEqual("ConnectionValue", e.PropertyName); };
            connection.ConnectionValue = "test";
        }

        [TestMethod]
        public void GetIsEncrypted_ReturnsAssignedResults()
        {
            var connection = new Connection();
            var result = connection.IsEncrypted;
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void GetIsEncrypted_ReturnsAssignedResults2()
        {
            var connection = new Connection { IsEncrypted = true };
            var result = connection.IsEncrypted;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void SetIsEncrypted_RaisesPropertyChanged()
        {
            var connection = new Connection();
            connection.PropertyChanged += (sender, e) => { Assert.AreEqual("IsEncrypted", e.PropertyName); };
            connection.IsEncrypted = true;
        }

        [TestMethod]
        public void GetEncryptionKey_ReturnsAssignedResults()
        {
            var connection = new Connection { EncryptionKey = "test" };
            var result = connection.EncryptionKey;
            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetEncryptionKey_ReturnsAssignedResults2()
        {
            var connection = new Connection { EncryptionKey = "test2" };
            var result = connection.EncryptionKey;
            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetEncryptionKey_RaisesPropertyChanged()
        {
            var connection = new Connection();
            connection.PropertyChanged += (sender, e) => { Assert.AreEqual("EncryptionKey", e.PropertyName); };
            connection.EncryptionKey = "test";
        }

        [TestMethod]
        public void Equals_Connection_When1stParamIsNull_ReturnsFalse()
        {
            var connection = new Connection();
            var result = connection.Equals(null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Connection_ReturnsFalse()
        {
            var connection = new Connection { Id = Guid.NewGuid() };
            var connection2 = new Connection { Id = Guid.NewGuid() };
            var result = connection.Equals(connection2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Connection_ReturnsTrue()
        {
            var guid = Guid.NewGuid();
            var connection = new Connection { Id = guid };
            var connection2 = new Connection { Id = guid };
            var result = connection.Equals(connection2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsConnection_ReturnsTrue()
        {
            var guid = Guid.NewGuid();
            var connection = new Connection { Id = guid };
            var connection2 = new Connection { Id = guid };
            var result = connection.Equals((object)connection2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsConnection_ReturnsFalse()
        {
            var connection = new Connection { Id = Guid.NewGuid() };
            var connection2 = new Connection { Id = Guid.NewGuid() };
            var result = connection.Equals((object)connection2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsOtherType_ReturnsFalse()
        {
            var guid = Guid.NewGuid();
            var connection = new Connection { Id = guid };
            var result = connection.Equals((object)null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Equals_Object_When1stParamIsOtherType_ReturnsFalse2()
        {
            var guid = Guid.NewGuid();
            var connection = new Connection { Id = guid };
            var result = connection.Equals(45);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCode_ReturnsGuidHashCode()
        {
            var guid = Guid.NewGuid();
            var guidHashCode = guid.GetHashCode();
            var connection = new Connection { Id = guid };
            var result = connection.GetHashCode();
            Assert.AreEqual(guidHashCode, result);
        }
    }
}
