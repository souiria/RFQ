using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class SecurityChangeTransactionTests
    {
        [TestMethod]
        public void GetId_ReturnsEmptyGuid()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction();

            //act
            var result = securityChangeTransaction.Id;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var securityChangeTransaction = new SecurityChangeTransaction { Id = id };

            //act
            var result = securityChangeTransaction.Id;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetUserGuid_ReturnsEmptyGuid()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction();

            //act
            var result = securityChangeTransaction.UserGuid;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetUserGuid_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var securityChangeTransaction = new SecurityChangeTransaction { UserGuid = id };

            //act
            var result = securityChangeTransaction.UserGuid;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetCreatedDate_ReturnsDefaultDateTime()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction();

            //act
            var result = securityChangeTransaction.CreatedDate;

            //assert
            Assert.AreEqual(default(DateTime), result);
        }

        [TestMethod]
        public void SetCreatedDate_IsSuccessful()
        {
            //arrange
            var now = DateTime.UtcNow;
            var securityChangeTransaction = new SecurityChangeTransaction { CreatedDate = now };

            //act
            var result = securityChangeTransaction.CreatedDate;

            //assert
            Assert.AreEqual(now, result);
        }

        [TestMethod]
        public void GetCreatedBy_ReturnsNull()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction();

            //act
            var result = securityChangeTransaction.CreatedBy;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetCreatedBy_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var securityChangeTransaction = new SecurityChangeTransaction { CreatedBy = id };

            //act
            var result = securityChangeTransaction.CreatedBy;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetHelpdeskId_ReturnsNull()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction();

            //act
            var result = securityChangeTransaction.HelpdeskId;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetHelpdeskId_IsSuccessful()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction { HelpdeskId = "HelpdeskId" };

            //act
            var result = securityChangeTransaction.HelpdeskId;

            //assert
            Assert.AreEqual("HelpdeskId", result);
        }

        [TestMethod]
        public void GetHelpdeskDesc_ReturnsNull()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction();

            //act
            var result = securityChangeTransaction.HelpdeskDesc;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetHelpdeskDesc_IsSuccessful()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction { HelpdeskDesc = "HelpdeskDesc" };

            //act
            var result = securityChangeTransaction.HelpdeskDesc;

            //assert
            Assert.AreEqual("HelpdeskDesc", result);
        }

        [TestMethod]
        public void GetChangeDetails_ReturnsNull()
        {
            //arrange
            var securityChangeTransaction = new SecurityChangeTransaction();

            //act
            var result = securityChangeTransaction.ChangeDetails;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetChangeDetails_IsSuccessful()
        {
            //arrange
            var changeDetails = new List<SecurityChangeDetail> { new SecurityChangeDetail() };
            var securityChangeTransaction = new SecurityChangeTransaction { ChangeDetails = changeDetails };

            //act
            var result = securityChangeTransaction.ChangeDetails;

            //assert
            CollectionAssert.AreEqual(changeDetails, result);
        }
    }
}
