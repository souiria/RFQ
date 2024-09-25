using System;
using System.Linq;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Contracts.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Base
{
    public class NewBaseModel : BaseModel<Guid>
    {

    }

    public class NewBaseEntityModel : IEntity<object>
    {
        object IEntity.Id
        {
            get => Id;
            set => Id = value;
        }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public object Id { get; set; }
    }

    [TestClass]
    public class BaseModelTest
    {
        [TestMethod]
        public void Inheriting_From_BaseModel_Is_Successful()
        {
            //Arrange
            var baseModel = new NewBaseModel
            {
                ExtensionData = null,
                CreatedBy = new Guid(),
                Name = "MyTestBaseModel",
                CreatedDate = DateTime.Now,
                CrudOperationType = CrudOperationType.Create,
                Error = "Error",
                Id = new Guid(),
                IsActive = true,
                IsRowChecked = false,
                ModifiedBy = new Guid(),
                ModifiedDate = DateTime.Now,
                Version = new byte[500]
            };

            //Act


            //Assert
            Assert.AreEqual(baseModel.Name, "MyTestBaseModel");
        }

        [TestMethod]
        public void Inheriting_From_BaseModel_And_Setting_Properties_Is_Successful()
        {
            //Arrange
            var baseModel = new NewBaseModel();


            //Act
            baseModel.ExtensionData = null;
            baseModel.CreatedBy = new Guid();
            baseModel.Name = "MyTestBaseModel";
            baseModel.CreatedDate = DateTime.Now;
            baseModel.CrudOperationType = CrudOperationType.Create;
            baseModel.Error = "Error";
            baseModel.Id = new Guid();
            baseModel.IsActive = true;
            baseModel.IsRowChecked = false;
            baseModel.ModifiedBy = new Guid();
            baseModel.ModifiedDate = DateTime.Now;
            baseModel.Version = new byte[500];

            var extensionData = baseModel.ExtensionData;
            var createdBy = baseModel.CreatedBy;
            var name = baseModel.Name;
            var createdDate = baseModel.CreatedDate;
            var crudOperationType = baseModel.CrudOperationType;
            var error = baseModel.Error;
            var id = baseModel.Id;
            var isActive = baseModel.IsActive;
            var isRowChecked = baseModel.IsRowChecked;
            var modifiedBy = baseModel.ModifiedBy;
            var modifiedDate = baseModel.ModifiedDate;
            var version = baseModel.Version;


            //Assert
            Assert.AreEqual(extensionData, null);
        }

        [TestMethod]
        public void Adding_Errors_To_BaseModel_Is_Successful()
        {
            //Arrange
            var baseModel = new NewBaseModel();

            //Act
            baseModel.UpdateErrors("Name", "That is a bad name!");

            //Assert
            Assert.IsTrue(baseModel.HasErrors());
        }

        [TestMethod]
        public void Adding_Errors_To_BaseModel_For_Same_Property_Has_A_Count_Of_One()
        {
            //Arrange
            var baseModel = new NewBaseModel();

            //Act
            baseModel.UpdateErrors("Name", "That is a bad name!");
            baseModel.UpdateErrors("Name", "That is a really bad name!");

            //Assert
            Assert.IsTrue(baseModel.GetErrors().Count == 1);
        }

        [TestMethod]
        public void Adding_Errors_To_BaseModel_For_Same_Property_Only_Stores_The_Last_Error()
        {
            //Arrange
            var baseModel = new NewBaseModel();

            //Act
            baseModel.UpdateErrors("Name", "That is a bad name!");
            baseModel.UpdateErrors("Name", "That is a really bad name!");

            //Assert
            Assert.AreEqual(baseModel.GetErrors().First().Value, "That is a really bad name!");
        }

        [TestMethod]
        public void Adding_Errors_To_BaseModel_For_Same_Property_With_Empty_Error_Removes_Property()
        {
            //Arrange
            var baseModel = new NewBaseModel();

            //Act
            baseModel.UpdateErrors("Name", "That is a bad name!");
            baseModel.UpdateErrors("Name", "");

            //Assert
            Assert.IsTrue(baseModel.GetErrors().Count == 0);
        }

        [TestMethod]
        public void Creating_A_New_BaseEntityModel_Is_Successful()
        {
            //Arrange
            var baseModel = new NewBaseEntityModel();

            //Act
            baseModel.Id = new object();
            baseModel.CreatedBy = new Guid();
            baseModel.CreatedDate = DateTime.Now;
            baseModel.ModifiedDate = DateTime.Now;
            baseModel.ModifiedBy = new Guid();
            var createdBy = baseModel.CreatedBy;
            var createdDate = baseModel.CreatedDate;
            var id = baseModel.Id;
            var modifiedBy = baseModel.ModifiedBy;
            var modifiedDate = baseModel.ModifiedDate;

            //Assert
            Assert.IsTrue(baseModel.GetType() == typeof(NewBaseEntityModel));
        }

        [TestMethod]
        public void GetId_ReturnsNotEmptyGuid()
        {
            //arrange
            var baseModel = new NewBaseModel();

            //act
            var result = baseModel.Id;

            //assert
            Assert.AreNotEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var baseModel = new NewBaseModel { Id = id };

            //act
            var result = baseModel.Id;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetIEntityId_ReturnsNotEmptyGuid()
        {
            //arrange
            var baseModel = new NewBaseModel();

            //act
            var result = ((IEntity)baseModel).Id;

            //assert
            Assert.AreNotEqual(Guid.Empty, result);
        }

        [TestMethod]
        public void SetIEntityId_IsSuccessful()
        {
            //arrange
            var id = Guid.NewGuid();
            var baseModel = new NewBaseModel();
            ((IEntity)baseModel).Id = id;

            //act
            var result = ((IEntity)baseModel).Id;

            //assert
            Assert.AreEqual(id, result);
        }

        [TestMethod]
        public void GetIndexedPropertyName_ReturnsEmptyString()
        {
            //arrange
            var baseModel = new NewBaseModel();

            //act
            var result = baseModel[""];

            //assert
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetCreatedDate_ReturnsNotDefaultDateTime()
        {
            //arrange
            var baseModel = new NewBaseModel();

            //act
            var result = baseModel.CreatedDate;

            //assert
            Assert.AreNotEqual(default(DateTime), result);
        }

        [TestMethod]
        public void GetModifiedDate_ReturnsNotDefaultDateTime()
        {
            //arrange
            var baseModel = new NewBaseModel();

            //act
            var result = baseModel.ModifiedDate;

            //assert
            Assert.AreNotEqual(default(DateTime), result);
        }
    }
}
