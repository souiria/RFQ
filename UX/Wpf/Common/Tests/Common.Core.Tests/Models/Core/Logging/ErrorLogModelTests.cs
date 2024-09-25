using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Core.Logging;
using Common.Core.Infrastructure.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Core.Tests.Models.Core.Logging
{
    [TestClass]
    public class ErrorLogModelTests
    {
        [TestMethod]
        public void GetContent_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.Content = "Test";
            Assert.AreEqual("Test", errorLogModel.Content);
        }

        [TestMethod]
        public void GetContent_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.Content = "Test2";
            Assert.AreEqual("Test2", errorLogModel.Content);
        }
        
        [TestMethod]
        public void GetErrorType_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.ErrorType = ErrorType.Exception;
            Assert.AreEqual(ErrorType.Exception, errorLogModel.ErrorType);
        }

        [TestMethod]
        public void GetErrorType_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.ErrorType = ErrorType.Logging;
            Assert.AreEqual(ErrorType.Logging, errorLogModel.ErrorType);
        }
        
        [TestMethod]
        public void GetExceptionType_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.ExceptionType = "Test";
            Assert.AreEqual("Test", errorLogModel.ExceptionType);
        }

        [TestMethod]
        public void GetExceptionType_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.ExceptionType = "Test2";
            Assert.AreEqual("Test2", errorLogModel.ExceptionType);
        }
        
        [TestMethod]
        public void GetCallingMethod_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.CallingMethod = "Test";
            Assert.AreEqual("Test", errorLogModel.CallingMethod);
        }

        [TestMethod]
        public void GetCallingMethod_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.CallingMethod = "Test2";
            Assert.AreEqual("Test2", errorLogModel.CallingMethod);
        }
        
        [TestMethod]
        public void GetClassName_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.ClassName = "Test";
            Assert.AreEqual("Test", errorLogModel.ClassName);
        }

        [TestMethod]
        public void GetClassName_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.ClassName = "Test2";
            Assert.AreEqual("Test2", errorLogModel.ClassName);
        }
        
        [TestMethod]
        public void GetMethodName_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.MethodName = "Test";
            Assert.AreEqual("Test", errorLogModel.MethodName);
        }

        [TestMethod]
        public void GetMethodName_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.MethodName = "Test2";
            Assert.AreEqual("Test2", errorLogModel.MethodName);
        }
        
        [TestMethod]
        public void GetPhysicalFileName_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.PhysicalFileName = "Test";
            Assert.AreEqual("Test", errorLogModel.PhysicalFileName);
        }

        [TestMethod]
        public void GetPhysicalFileName_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.PhysicalFileName = "Test2";
            Assert.AreEqual("Test2", errorLogModel.PhysicalFileName);
        }
        
        [TestMethod]
        public void GetStackTrace_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.StackTrace = "Test";
            Assert.AreEqual("Test", errorLogModel.StackTrace);
        }

        [TestMethod]
        public void GetStackTrace_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.StackTrace = "Test2";
            Assert.AreEqual("Test2", errorLogModel.StackTrace);
        }
        
        [TestMethod]
        public void GetInnerException_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.InnerException = "Test";
            Assert.AreEqual("Test", errorLogModel.InnerException);
        }

        [TestMethod]
        public void GetInnerException_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            errorLogModel.InnerException = "Test2";
            Assert.AreEqual("Test2", errorLogModel.InnerException);
        }
        [TestMethod]
        public void GetSnapShotData_ReturnsAssignedValue()
        {
            var errorLogModel = new ErrorLogModel();
            var data = "0123456789abcdef".Compress();
            errorLogModel.SnapShotData = data;
            Assert.AreEqual(data, errorLogModel.SnapShotData);
        }

        [TestMethod]
        public void GetSnapShotData_ReturnsAssignedValue2()
        {
            var errorLogModel = new ErrorLogModel();
            var data = "fedcba9876543210".Compress();
            errorLogModel.SnapShotData = data;
            Assert.AreEqual(data, errorLogModel.SnapShotData);
        }
    }
}
