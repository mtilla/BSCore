﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace BSCoreTest
{
    [TestClass]
    public class DirectoryScanner
    {
        [TestMethod]
        public void DirScanTest()
        {
            
            //String scanPath = "C:\\Scanner";
            BSCore.IO.IOManager scanner = new BSCore.IO.IOManager();
            Thread.Sleep(1000 * 15);
        }
    }
}
