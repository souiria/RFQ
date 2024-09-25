using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Filtering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Filtering
{
    [TestClass]
    public class FilterCollectionModelTests
    {
        [TestMethod]
        public void GetInternalFilterCollection_ReturnsNull()
        {
            //arrange
            var filterCollectionModel = new FilterCollectionModel();

            //act
            var result = filterCollectionModel.InternalFilterCollection;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetInternalFilterCollection_IsSuccessful()
        {
            //arrange
            var internalFilters = new List<InternalFilterModel> { new InternalFilterModel() };
            var filterCollectionModel = new FilterCollectionModel { InternalFilterCollection = internalFilters };

            //act
            var result = filterCollectionModel.InternalFilterCollection.ToList();

            //assert
            CollectionAssert.AreEqual(internalFilters, result);
        }

        [TestMethod]
        public void GetIsAnd_ReturnsFalse()
        {
            //arrange
            var filterCollectionModel = new FilterCollectionModel();

            //act
            var result = filterCollectionModel.IsAnd;

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SetIsAnd_IsSuccessful()
        {
            //arrange
            var filterCollectionModel = new FilterCollectionModel { IsAnd = true };

            //act
            var result = filterCollectionModel.IsAnd;

            //assert
            Assert.AreEqual(true, result);
        }
    }
}
