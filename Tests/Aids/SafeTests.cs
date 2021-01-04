using System;
using System.Collections.Generic;
using System.Threading;
using MaskShop.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaskShop.Tests.Aids
{
    [TestClass]
    public class SafeTests : BaseTests
    {
        private LogTests.TestLogBook _logBook;

        [TestInitialize]
        public void TestInitialize()
        {
            Type = typeof(Safe);
            _logBook = new LogTests.TestLogBook();
            Log.logBook = _logBook;
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Log.logBook = null;
        }

        [TestMethod]
        public void RunTest()
        {
            var newLogBook = new LogTests.TestLogBook();
            Safe.Run(() => Log.logBook = newLogBook);
            Assert.IsNull(newLogBook.LoggedException);
        }

        [TestMethod]
        public void RunFunctionTest()
        {
            var actual = Safe.Run(() => "Result", "Error");
            Assert.AreEqual("Result", actual);
            Assert.IsNull(_logBook.LoggedException);
        }

        [TestMethod]
        public void RunFailingFunctionTest()
        {
            var actual = Safe.Run(() => throw new NotImplementedException(), "Error");
            Assert.AreEqual("Error", actual);
            var exception = _logBook.LoggedException;
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(NotImplementedException));
        }

        [TestMethod]
        public void RunMethodTest()
        {
            var newLogBook = new LogTests.TestLogBook();
            Safe.Run(() => Log.logBook = newLogBook);
            Assert.IsNull(newLogBook.LoggedException);
        }

        [TestMethod]
        public void RunFailingMethodTest()
        {
            Safe.Run(() => throw new ArgumentOutOfRangeException());
            var exception = _logBook.LoggedException;
            Assert.IsNotNull(exception);
            Assert.IsInstanceOfType(exception, typeof(ArgumentOutOfRangeException));
        }

        [TestMethod]
        public void RunInsideRunTest()
        {
            Safe.Run(() =>
            {
                Safe.Run(() => throw new ArgumentException());

                throw new AggregateException();
            });
            Assert.AreEqual(2, _logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[0], typeof(ArgumentException));
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[1], typeof(AggregateException));
        }

        [TestMethod]
        public void RunInsideRunLockedTest()
        {
            Safe.Run(() =>
            {
                Safe.Run(() => throw new ArgumentException(), true);

                throw new AggregateException();
            }, true);
            Assert.AreEqual(2, _logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[0], typeof(ArgumentException));
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[1], typeof(AggregateException));
        }

        [TestMethod]
        public void RunInSeparateThreadsTest()
        {
            var list = new List<string>();
            startThreads(list);
            validateList(list);
            Assert.AreEqual(2, _logBook.LoggedExceptions.Count);
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[0], typeof(ArgumentNullException));
            Assert.IsInstanceOfType(_logBook.LoggedExceptions[1], typeof(ArithmeticException));
        }

        private static void startThreads(ICollection<string> l)
        {
            var t1 = new Thread(() =>
                method(l, "method1: ", () => throw new ArgumentNullException()));
            var t2 = new Thread(() =>
                method(l, "method2: ", () => throw new ArithmeticException()));
            t1.Start();
            Thread.Sleep(1000);
            t2.Start();
            Thread.Sleep(1000);
        }

        private static void method(ICollection<string> list, string message, Action exception)
        {
            Safe.Run(() =>
            {
                Safe.Run(() =>
                {
                    for (var i = 0; i < 10; i++)
                    {
                        list.Add(message + DateTime.Now);
                        Thread.Sleep(1);
                    }

                    exception();
                }, true);
                list.Add(message + DateTime.Now);
            }, true);
        }

        private static void validateList(IReadOnlyList<string> l)
        {
            Assert.AreEqual(22, l.Count);

            for (var i = 0; i < 22; i++)
            {
                Assert.IsTrue(
                    i < 11
                        ? l[i].StartsWith("method1:")
                        : l[i].StartsWith("method2:"),
                    $"list[{i}] = {l[i]}");
            }
        }
    }
}