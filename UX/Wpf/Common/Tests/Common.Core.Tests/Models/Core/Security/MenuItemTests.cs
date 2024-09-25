using Common.Core.Contracts.Models.Core.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Security
{
    [TestClass]
    public class MenuItemTests
    {
        [TestMethod]
        public void GetLabelKey_ReturnsAssignedValue()
        {
            var menuItem = new MenuItem { LabelKey = "test" };

            var result = menuItem.LabelKey;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetLabelKey_ReturnsAssignedValue2()
        {
            var menuItem = new MenuItem { LabelKey = "test2" };

            var result = menuItem.LabelKey;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetLabelKey_RaisesPropertyChanged()
        {
            var menuItem = new MenuItem();
            menuItem.PropertyChanged += (sender, e) => { Assert.AreEqual("LabelKey", e.PropertyName); };

            menuItem.LabelKey = "test";
        }
        [TestMethod]
        public void GetActiveDirectoryGroup_ReturnsAssignedValue()
        {
            var menuItem = new MenuItem { ActiveDirectoryGroup = "test" };

            var result = menuItem.ActiveDirectoryGroup;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetActiveDirectoryGroup_ReturnsAssignedValue2()
        {
            var menuItem = new MenuItem { ActiveDirectoryGroup = "test2" };

            var result = menuItem.ActiveDirectoryGroup;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetActiveDirectoryGroup_RaisesPropertyChanged()
        {
            var menuItem = new MenuItem();
            menuItem.PropertyChanged += (sender, e) => { Assert.AreEqual("ActiveDirectoryGroup", e.PropertyName); };

            menuItem.ActiveDirectoryGroup = "test";
        }

        [TestMethod]
        public void GetDisplayName_ReturnsAssignedValue()
        {
            var menuItem = new MenuItem { DisplayName = "test" };

            var result = menuItem.DisplayName;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetDisplayName_ReturnsAssignedValue2()
        {
            var menuItem = new MenuItem { DisplayName = "test2" };

            var result = menuItem.DisplayName;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetDisplayName_RaisesPropertyChanged()
        {
            var menuItem = new MenuItem();
            menuItem.PropertyChanged += (sender, e) => { Assert.AreEqual("DisplayName", e.PropertyName); };

            menuItem.DisplayName = "test";
        }

        [TestMethod]
        public void GetParentAdGroup_ReturnsAssignedValue()
        {
            var menuItem = new MenuItem { ParentAdGroup = "test" };

            var result = menuItem.ParentAdGroup;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetParentAdGroup_ReturnsAssignedValue2()
        {
            var menuItem = new MenuItem { ParentAdGroup = "test2" };

            var result = menuItem.ParentAdGroup;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetParentAdGroup_RaisesPropertyChanged()
        {
            var menuItem = new MenuItem();
            menuItem.PropertyChanged += (sender, e) => { Assert.AreEqual("ParentAdGroup", e.PropertyName); };

            menuItem.ParentAdGroup = "test";
        }

        [TestMethod]
        public void GetViewName_ReturnsAssignedValue()
        {
            var menuItem = new MenuItem { ViewName = "test" };

            var result = menuItem.ViewName;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetViewName_ReturnsAssignedValue2()
        {
            var menuItem = new MenuItem { ViewName = "test2" };

            var result = menuItem.ViewName;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetViewName_RaisesPropertyChanged()
        {
            var menuItem = new MenuItem();
            menuItem.PropertyChanged += (sender, e) => { Assert.AreEqual("ViewName", e.PropertyName); };

            menuItem.ViewName = "test";
        }

        [TestMethod]
        public void GetDisplayId_ReturnsAssignedValue()
        {
            var menuItem = new MenuItem { DisplayId = 7 };

            var result = menuItem.DisplayId;

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void GetDisplayId_ReturnsAssignedValue2()
        {
            var menuItem = new MenuItem { DisplayId = 42 };

            var result = menuItem.DisplayId;

            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void SetDisplayId_RaisesPropertyChanged()
        {
            var menuItem = new MenuItem();
            menuItem.PropertyChanged += (sender, e) => { Assert.AreEqual("DisplayId", e.PropertyName); };

            menuItem.DisplayId = 7;
        }

        [TestMethod]
        public void GetImageSource_ReturnsAssignedValue()
        {
            var menuItem = new MenuItem { ImageSource = "test" };

            var result = menuItem.ImageSource;

            Assert.AreEqual("test", result);
        }

        [TestMethod]
        public void GetImageSource_ReturnsAssignedValue2()
        {
            var menuItem = new MenuItem { ImageSource = "test2" };

            var result = menuItem.ImageSource;

            Assert.AreEqual("test2", result);
        }

        [TestMethod]
        public void SetImageSource_RaisesPropertyChanged()
        {
            var menuItem = new MenuItem();
            menuItem.PropertyChanged += (sender, e) => { Assert.AreEqual("ImageSource", e.PropertyName); };

            menuItem.ImageSource = "test";
        }
    }
}
