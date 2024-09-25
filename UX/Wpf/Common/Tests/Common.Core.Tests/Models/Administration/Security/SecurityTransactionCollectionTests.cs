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
    public class SecurityTransactionCollectionTests
    {
        [TestMethod]
        public void GetCanLoadMore_ReturnsFalse()
        {
            //arrange
            var securityTransactionCollection = new SecurityTransactionCollection();

            //act
            var result = securityTransactionCollection.CanLoadMore;

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetCanLoadMore_IsSuccessful()
        {
            //arrange
            var securityTransactionCollection = new SecurityTransactionCollection { CanLoadMore = true };

            //act
            var result = securityTransactionCollection.CanLoadMore;

            //assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void GetTransactions_ReturnsNotNull()
        {
            //arrange
            var securityTransactionCollection = new SecurityTransactionCollection();

            //act
            var result = securityTransactionCollection.Transactions;

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SetTransactions_IsSuccessful()
        {
            //arrange
            var transactions = new List<SecurityChangeTransaction> { new SecurityChangeTransaction() };
            var securityTransactionCollection = new SecurityTransactionCollection { Transactions = transactions };

            //act
            var result = securityTransactionCollection.Transactions;

            //assert
            Assert.AreEqual(transactions, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_SecurityTransactionCollection_WithNull1stParam_ThrowsException()
        {
            //arrange //assert
            var securityTransactionCollection = new SecurityTransactionCollection(null);

            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_SecurityTransactionCollection_IsSuccessful()
        {
            //arrange //act
            var collection = new SecurityTransactionCollection
            {
                CanLoadMore = true,
                Transactions = new List<SecurityChangeTransaction>
                    {new SecurityChangeTransaction(), new SecurityChangeTransaction()}
            };
            var securityTransactionCollection = new SecurityTransactionCollection(collection);

            //assert
            Assert.AreEqual(collection.CanLoadMore, securityTransactionCollection.CanLoadMore);
            CollectionAssert.AreEqual(collection.Transactions, securityTransactionCollection.Transactions);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_SecurityChangeTransactions_WithNull1stParam_ThrowsException()
        {
            //arrange //assert
            var securityTransactionCollection = new SecurityTransactionCollection(null, false);

            //assert
            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_SecurityChangeTransactions_IsSuccessful()
        {
            //arrange //act
            var collection = new List<SecurityChangeTransaction>
                {new SecurityChangeTransaction(), new SecurityChangeTransaction()};
            var securityTransactionCollection = new SecurityTransactionCollection(collection, true);

            //assert
            CollectionAssert.AreEqual(collection, securityTransactionCollection.Transactions);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_SecurityTransactionCollection_WithNull1stParam_ThrowsException()
        {
            //arrange 
            var securityTransactionCollection = new SecurityTransactionCollection();

            //act //assert
            securityTransactionCollection.Add((SecurityTransactionCollection)null);
        }

        [TestMethod]
        public void Add_SecurityTransactionCollection_AddsToTransactions()
        {
            //arrange 
            var collection = new SecurityTransactionCollection
            {
                Transactions = new List<SecurityChangeTransaction>
                    {new SecurityChangeTransaction(), new SecurityChangeTransaction()}
            };
            var securityTransactionCollection = new SecurityTransactionCollection();

            //act
            securityTransactionCollection.Add(collection);

            //assert
            CollectionAssert.AreEquivalent(collection.Transactions, securityTransactionCollection.Transactions);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_SecurityChangeTransaction_WithNull1stParam_ThrowsException()
        {
            //arrange 
            var securityTransactionCollection = new SecurityTransactionCollection();

            //act //assert
            securityTransactionCollection.Add((SecurityChangeTransaction)null);
        }

        [TestMethod]
        public void Add_SecurityChangeTransaction_AddsToTransactions()
        {
            //arrange 
            var securityChangeTransaction = new SecurityChangeTransaction();
            var securityTransactionCollection = new SecurityTransactionCollection();

            //act 
            securityTransactionCollection.Add(securityChangeTransaction);

            //assert
            Assert.AreEqual(1, securityTransactionCollection.Transactions.Count);
            Assert.AreEqual(securityChangeTransaction, securityTransactionCollection.Transactions[0]);
        }
    }
}
