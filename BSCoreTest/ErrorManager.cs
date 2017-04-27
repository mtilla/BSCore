using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSCore.Error;
using System.Threading;

namespace BSCoreTest
{
    [TestClass]
    public class ErrorManager
    {
        BSCore.Error.ErrorManager _manager;
        [TestInitialize]
        public void TestInit()
        {
            _manager = new BSCore.Error.ErrorManager(new BSCore.CoreManager());

        }
        [TestCleanup]
        public void TestCleanup()
        {
            _manager = null;
            Assert.IsNull(_manager);
        }

        [TestMethod]
        public void ErrorTest()
        {
            for (int i = 0; i < 10; i++)
            {

                Error err = new Error();
                Console.WriteLine(err.Timestamp);
                //Thread.Sleep(1000);
            }

        }
    }
}
