using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Notifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Notifications
{
    [TestClass]
    public class SubscriptionServiceTests
    {
        [TestMethod]
        public void GetFunctionName_ReturnsAssignedValue()
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.FunctionName = "test";
            Assert.AreEqual("test", subscriptionService.FunctionName);
        }

        [TestMethod]
        public void GetFunctionName_ReturnsAssignedValue2()
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.FunctionName = "otherTest";
            Assert.AreEqual("otherTest", subscriptionService.FunctionName);
        }

        [TestMethod]
        public void SetFunctionName_RaisesPropertyChanged()
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.PropertyChanged += (sender, e) => { Assert.AreEqual("FunctionName", e.PropertyName); };

            subscriptionService.FunctionName = "otherTest";
        }

        [TestMethod]
        public void GetServiceName_ReturnsAssignedValue()
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.ServiceName = "test";
            Assert.AreEqual("test", subscriptionService.ServiceName);
        }

        [TestMethod]
        public void GetServiceName_ReturnsAssignedValue2()
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.ServiceName = "otherTest";
            Assert.AreEqual("otherTest", subscriptionService.ServiceName);
        }

        [TestMethod]
        public void SetServiceName_RaisesPropertyChanged()
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.PropertyChanged += (sender, e) => { Assert.AreEqual("ServiceName", e.PropertyName); };

            subscriptionService.ServiceName = "otherTest";
        }

        [TestMethod]
        public void GetChannels_ReturnsAssignedValue()
        {
            var channels = new List<SubscriptionChannel>();
            var subscriptionService = new SubscriptionService { Channels = channels };
            CollectionAssert.AreEqual(channels, subscriptionService.Channels);
        }

        [TestMethod]
        public void GetChannels_ReturnsAssignedValue2()
        {
            var channels = new List<SubscriptionChannel> { new SubscriptionChannel(), new SubscriptionChannel() };
            var subscriptionService = new SubscriptionService { Channels = channels };
            CollectionAssert.AreEqual(channels, subscriptionService.Channels);
        }

        [TestMethod]
        public void SetChannels_RaisesPropertyChanged()
        {
            var subscriptionService = new SubscriptionService();
            subscriptionService.PropertyChanged += (sender, e) => { Assert.AreEqual("Channels", e.PropertyName); };

            subscriptionService.Channels = new List<SubscriptionChannel>();
        }
    }
}
