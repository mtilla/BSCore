using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSCoreTest
{
    [TestClass]
    public class CoreManager
    {
        private BSCore.CoreManager manager;
        [TestInitialize]
        public void TestInit()
        {
            manager = new BSCore.CoreManager();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            manager = null;
            Assert.IsNull(manager);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(manager);
        }
    }
}
