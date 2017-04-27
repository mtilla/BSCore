using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BSCoreTest
{
    [TestClass]
    public class CoreManager
    {
        private BSCore.CoreManager _manager;
        [TestInitialize]
        public void TestInit()
        {
            _manager = new BSCore.CoreManager();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            _manager = null;
            Assert.IsNull(_manager);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsNotNull(_manager);
        }
    }
}
