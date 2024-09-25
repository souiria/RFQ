using System.Collections.ObjectModel;
using Common.Core.Contracts.Models.Administration.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Security
{
    [TestClass]
    public class ViewSecurityModelTests
    {
        [TestMethod]
        public void GetDisplayId_ReturnsZero()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.DisplayId;

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SetDisplayId_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { DisplayId = 40 };

            //act 
            var result = viewSecurityModel.DisplayId;

            //assert
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void GetDisplayLabel_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.DisplayLabel;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetDisplayLabel_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { DisplayLabel = "DisplayLabel" };

            //act 
            var result = viewSecurityModel.DisplayLabel;

            //assert
            Assert.AreEqual("DisplayLabel", result);
        }

        [TestMethod]
        public void GetParentDisplayId_ReturnsZero()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.ParentDisplayId;

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SetParentDisplayId_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { ParentDisplayId = 40 };

            //act 
            var result = viewSecurityModel.ParentDisplayId;

            //assert
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void GetGrandParentDisplayId_ReturnsZero()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.GrandParentDisplayId;

            //assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SetGrandParentDisplayId_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { GrandParentDisplayId = 40 };

            //act 
            var result = viewSecurityModel.GrandParentDisplayId;

            //assert
            Assert.AreEqual(40, result);
        }

        [TestMethod]
        public void GetDisplayName_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.DisplayName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetDisplayName_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { DisplayName = "DisplayName" };

            //act 
            var result = viewSecurityModel.DisplayName;

            //assert
            Assert.AreEqual("DisplayName", result);
        }

        [TestMethod]
        public void GetLabelKey_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.LabelKey;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetLabelKey_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { LabelKey = "LabelKey" };

            //act 
            var result = viewSecurityModel.LabelKey;

            //assert
            Assert.AreEqual("LabelKey", result);
        }

        [TestMethod]
        public void GetParentModuleLabelKey_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.ParentModuleLabelKey;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetParentModuleLabelKey_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { ParentModuleLabelKey = "ParentModuleLabelKey" };

            //act 
            var result = viewSecurityModel.ParentModuleLabelKey;

            //assert
            Assert.AreEqual("ParentModuleLabelKey", result);
        }

        [TestMethod]
        public void GetParentFunctionLabelKey_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.ParentFunctionLabelKey;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetParentFunctionLabelKey_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { ParentFunctionLabelKey = "ParentFunctionLabelKey" };

            //act 
            var result = viewSecurityModel.ParentFunctionLabelKey;

            //assert
            Assert.AreEqual("ParentFunctionLabelKey", result);
        }

        [TestMethod]
        public void GetImageSource_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.ImageSource;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetImageSource_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { ImageSource = "ImageSource" };

            //act 
            var result = viewSecurityModel.ImageSource;

            //assert
            Assert.AreEqual("ImageSource", result);
        }

        [TestMethod]
        public void GetViewName_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.ViewName;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetViewName_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { ViewName = "ViewName" };

            //act 
            var result = viewSecurityModel.ViewName;

            //assert
            Assert.AreEqual("ViewName", result);
        }

        [TestMethod]
        public void GetActiveDirectoryGroup_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.ActiveDirectoryGroup;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetActiveDirectoryGroup_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { ActiveDirectoryGroup = "ActiveDirectoryGroup" };

            //act 
            var result = viewSecurityModel.ActiveDirectoryGroup;

            //assert
            Assert.AreEqual("ActiveDirectoryGroup", result);
        }

        [TestMethod]
        public void GetFields_ReturnsNull()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.Fields;

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void SetFields_IsSuccessful()
        {
            //arrange
            var fields = new ObservableCollection<FieldSecurityModel>
                { new FieldSecurityModel(), new FieldSecurityModel()};
            var viewSecurityModel = new ViewSecurityModel { Fields = fields };

            //act 
            var result = viewSecurityModel.Fields;

            //assert
            CollectionAssert.AreEqual(fields, result);
        }

        [TestMethod]
        public void GetIsSelected_ReturnsFalse()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel();

            //act 
            var result = viewSecurityModel.IsSelected;

            //assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void SetIsSelected_IsSuccessful()
        {
            //arrange
            var viewSecurityModel = new ViewSecurityModel { IsSelected = null };

            //act 
            var result = viewSecurityModel.IsSelected;

            //assert
            Assert.AreEqual(null, result);
        }
    }
}
