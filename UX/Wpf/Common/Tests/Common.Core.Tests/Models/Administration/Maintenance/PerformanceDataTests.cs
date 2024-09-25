using System;
using Common.Core.Contracts.Models.Administration.Maintenance;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Administration.Maintenance
{
    [TestClass]
    public class PerformanceDataTests
    {
        [TestMethod]
        public void get_EventType_ReturnsNull()
        {
            // arrange
            var performanceData = new PerformanceData();

            // act
            var result = performanceData.EventType;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_EventType_Returns_EventType()
        {
            // arrange
            var performanceData = new PerformanceData();
            performanceData.EventType = "EventType";

            // act
            var result = performanceData.EventType;

            // assert
            Assert.AreEqual("EventType", result);
        }

        [TestMethod]
        public void get_Event_ReturnsNull()
        {
            // arrange
            var performanceData = new PerformanceData();

            // act
            var result = performanceData.Event;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_Event_Returns_Event()
        {
            // arrange
            var performanceData = new PerformanceData();
            performanceData.Event = "Event";

            // act
            var result = performanceData.Event;

            // assert
            Assert.AreEqual("Event", result);
        }

        [TestMethod]
        public void get_Time_ReturnsNull()
        {
            // arrange
            var performanceData = new PerformanceData();

            // act
            var result = performanceData.Time;

            // assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void get_Time_Returns_Time()
        {
            // arrange
            var performanceData = new PerformanceData();
            performanceData.Time = "Time";

            // act
            var result = performanceData.Time;

            // assert
            Assert.AreEqual("Time", result);
        }
    }
}
