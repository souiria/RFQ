using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class ViewHierarchyModelTests
    {
        [TestMethod]
        public void GetFields_ReturnsNull()
        {
            //arrange
            var viewHierarchyModel = new ViewHierarchyModel();

            //act
            var result = viewHierarchyModel.Fields;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFields_IsSuccessful()
        {
            //arrange
            var fields = new ObservableCollection<FieldHierarchyModel>
                {new FieldHierarchyModel(), new FieldHierarchyModel()};
            var viewHierarchyModel = new ViewHierarchyModel
            {
                Fields = fields
            };

            //act
            var result = viewHierarchyModel.Fields;

            //assert
            CollectionAssert.AreEqual(fields, result);
        }

        [TestMethod]
        public void GetIsSelected_ReturnsFalse()
        {
            //arrange
            var viewHierarchyModel = new ViewHierarchyModel();

            //act
            var result = viewHierarchyModel.IsSelected;

            //assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetIsSelected_IsSuccessful()
        {
            //arrange
            var viewHierarchyModel = new ViewHierarchyModel { IsSelected = null };

            //act
            var result = viewHierarchyModel.IsSelected;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_H1ViewMasterModel_WithNull1stParam_ThrowsException()
        {
            //arrange //act //assert
            var viewHierarchyModel = new ViewHierarchyModel(null);

            Assert.Fail();
        }

        [TestMethod]
        public void Constructor_H1ViewMasterModel_IsSuccessful()
        {
            //arrange //act
            var viewHierarchyModel = new ViewHierarchyModel(new H1ViewMasterModel());

            //assert
            Assert.IsNotNull(viewHierarchyModel);
        }
    }
}
