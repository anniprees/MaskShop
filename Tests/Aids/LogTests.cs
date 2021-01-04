using System;
using System.Collections.Generic;
using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{
    [TestClass]
    public class LogTests : BaseTests
    {
        internal class TestLogBook : ILogBook
        {

            public string LoggedMessage { get; private set; }
            public Exception LoggedException { get; private set; }
            public List<Exception> LoggedExceptions { get; } = new List<Exception>();

            public void WriteEntry(string message)
            {
                LoggedMessage = message;
            }

            public void WriteEntry(Exception e)
            {
                LoggedException = e;
                LoggedExceptions.Add(e);
            }

        }

        private TestLogBook _logBook;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            Type = typeof(Log);
            _logBook = new TestLogBook();
        }

        [TestCleanup]
        public void TestCleanup() => Log.logBook = null;

        [TestMethod]
        public void MessageTest()
        {
            var message = GetRandom.String();
            Log.Message(message);
            Assert.IsNull(_logBook.LoggedMessage);
            Log.logBook = _logBook;
            Log.Message(message);
            Assert.AreEqual(message, _logBook.LoggedMessage);
        }

        [TestMethod]
        public void ExceptionTest()
        {
            var exception = new NotImplementedException();
            Log.Exception(exception);
            Assert.IsNull(_logBook.LoggedException);
            Log.logBook = _logBook;
            Log.Exception(exception);
            Assert.AreEqual(exception, _logBook.LoggedException);
        }

    }

}


