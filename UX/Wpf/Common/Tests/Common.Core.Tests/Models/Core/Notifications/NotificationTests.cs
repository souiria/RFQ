using System;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Notifications
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void GetHeader_ReturnsAssignedValue()
        {
            var errorLogModel = new Notification();
            errorLogModel.Header = "Test";
            Assert.AreEqual("Test", errorLogModel.Header);
        }

        [TestMethod]
        public void GetHeader_ReturnsAssignedValue2()
        {
            var errorLogModel = new Notification();
            errorLogModel.Header = "Test2";
            Assert.AreEqual("Test2", errorLogModel.Header);
        }

        [TestMethod]
        public void GetBody_ReturnsAssignedValue()
        {
            var errorLogModel = new Notification();
            errorLogModel.Body = "Test";
            Assert.AreEqual("Test", errorLogModel.Body);
        }

        [TestMethod]
        public void GetBody_ReturnsAssignedValue2()
        {
            var errorLogModel = new Notification();
            errorLogModel.Body = "Test2";
            Assert.AreEqual("Test2", errorLogModel.Body);
        }

        [TestMethod]
        public void GetDateSent_ReturnsAssignedValue()
        {
            var errorLogModel = new Notification();
            var data = DateTime.UtcNow;
            errorLogModel.DateSent = data;
            Assert.AreEqual(data, errorLogModel.DateSent);
        }

        [TestMethod]
        public void GetDateSent_ReturnsAssignedValue2()
        {
            var errorLogModel = new Notification();
            var data = DateTime.MaxValue;
            errorLogModel.DateSent = data;
            Assert.AreEqual(data, errorLogModel.DateSent);
        }
        
        [TestMethod]
        public void GetChannel_ReturnsAssignedValue()
        {
            var errorLogModel = new Notification();
            var data = "Test";
            errorLogModel.Channel = data;
            Assert.AreEqual(data, errorLogModel.Channel);
        }

        [TestMethod]
        public void GetChannel_ReturnsAssignedValue2()
        {
            var errorLogModel = new Notification();
            var data = "Test2";
            errorLogModel.Channel = data;
            Assert.AreEqual(data, errorLogModel.Channel);
        }

        [TestMethod]
        public void GetIsRead_ReturnsAssignedValue()
        {
            var errorLogModel = new Notification();
            errorLogModel.IsRead = false;
            Assert.AreEqual(false, errorLogModel.IsRead);
        }

        [TestMethod]
        public void GetIsRead_ReturnsAssignedValue2()
        {
            var errorLogModel = new Notification();
            errorLogModel.IsRead = true;
            Assert.AreEqual(true, errorLogModel.IsRead);
        }
    }
}
