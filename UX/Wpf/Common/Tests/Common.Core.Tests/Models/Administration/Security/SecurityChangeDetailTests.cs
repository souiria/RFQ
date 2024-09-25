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
    public class SecurityChangeDetailTests
    {
        [TestMethod]
        public void GetId_ReturnsEmptyGuid()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail();

            //act
            var result = securityChangeDetail.Id;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var securityChangeDetail = new SecurityChangeDetail { Id = id };

            //act
            var result = securityChangeDetail.Id;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetTransactionId_ReturnsEmptyGuid()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail();

            //act
            var result = securityChangeDetail.TransactionId;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetTransactionId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var securityChangeDetail = new SecurityChangeDetail { TransactionId = id };

            //act
            var result = securityChangeDetail.TransactionId;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetSecurityId_ReturnsEmptyGuid()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail();

            //act
            var result = securityChangeDetail.SecurityId;

            //assert
            Assert.AreEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetSecurityId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var securityChangeDetail = new SecurityChangeDetail { SecurityId = id };

            //act
            var result = securityChangeDetail.SecurityId;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetSecurityName_ReturnsNull()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail();

            //act
            var result = securityChangeDetail.SecurityName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetSecurityName_IsSuccessful()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail { SecurityName = "SecurityName" };

            //act
            var result = securityChangeDetail.SecurityName;

            //assert
            Assert.AreEqual("SecurityName", result);
        }

        [TestMethod]
        public void GetDetailType_ReturnsDefaultDetailType()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail();

            //act
            var result = securityChangeDetail.DetailType;

            //assert
            Assert.AreEqual(default(DetailType), result);
        }

        [TestMethod]
        public void SetDetailType_IsSuccessful()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail { DetailType = DetailType.Field };

            //act
            var result = securityChangeDetail.DetailType;

            //assert
            Assert.AreEqual(DetailType.Field, result);
        }
        [TestMethod]
        public void GetOperation_ReturnsDefaultOperation()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail();

            //act
            var result = securityChangeDetail.Operation;

            //assert
            Assert.AreEqual(default(Operation), result);
        }

        [TestMethod]
        public void SetOperation_IsSuccessful()
        {
            //arrange
            var securityChangeDetail = new SecurityChangeDetail { Operation = Operation.Remove };

            //act
            var result = securityChangeDetail.Operation;

            //assert
            Assert.AreEqual(Operation.Remove, result);
        }
    }
}
