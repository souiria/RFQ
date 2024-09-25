using System;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Base
{
    public class NewExternalDataSourceModel : ExternalDataSourceModel<int>
    {

    }

    [TestClass]
    public class ExternalDataSourceModelTest
    {
        [TestMethod]
        public void Creating_A_New_NewExternalDataSourceModel_Is_Successful()
        {
            //Arrange
            var baseModel = new NewExternalDataSourceModel();

            //Act
            baseModel.Id = 1;
            baseModel.CreatedBy = new Guid();
            baseModel.CreatedDate = DateTime.Now;
            baseModel.ModifiedDate = DateTime.Now;
            baseModel.ModifiedBy = new Guid();
            baseModel.Version = new byte[500];
            var createdBy = baseModel.CreatedBy;
            var createdDate = baseModel.CreatedDate;
            var id = baseModel.Id;
            var modifiedBy = baseModel.ModifiedBy;
            var modifiedDate = baseModel.ModifiedDate;
            var version = baseModel.Version;

            //Assert
            Assert.IsTrue(baseModel.GetType() == typeof(NewExternalDataSourceModel));
        }

        [TestMethod]
        public void GetIEntityId_ReturnsDefaultType()
        {
            //arrange
            var baseModel = new NewExternalDataSourceModel();

            //act
            var result = ((IEntity)baseModel).Id;

            //assert
            Assert.AreEqual(default(int), result);
        }

        [TestMethod]
        public void SetIEntityId_IsSuccessful()
        {
            //arrange
            var baseModel = new NewExternalDataSourceModel();
            ((IEntity)baseModel).Id = 32;
            //act
            var result = ((IEntity)baseModel).Id;

            //assert
            Assert.AreEqual(32, result);
        }
    }
}
