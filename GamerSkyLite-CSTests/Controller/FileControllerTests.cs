using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamerSkyLite_CS.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamerSkyLite_CS.Controller.Tests
{
    [TestClass()]
    public class FileControllerTests
    {
        [TestMethod()]
        public void PathCombineTest()
        {
            Assert.IsTrue(FileController.PathCombine("C:\\", "\\1.txt") == "C:\\1.txt");
            Assert.IsTrue(FileController.PathCombine("C:\\", "1.txt") == "C:\\1.txt");
            Assert.IsTrue(FileController.PathCombine("C:", "\\1.txt") == "C:\\1.txt");
            Assert.IsTrue(FileController.PathCombine("C:", "1.txt") == "C:\\1.txt");
        }

        [TestMethod()]
        public void LinkCombineTest()
        {
            Assert.IsTrue(FileController.LinkCombine("http://www.website.com/", "/Router") == "http://www.website.com/Router");
            Assert.IsTrue(FileController.LinkCombine("http://www.website.com/", "Router") == "http://www.website.com/Router");
            Assert.IsTrue(FileController.LinkCombine("http://www.website.com", "/Router") == "http://www.website.com/Router");
            Assert.IsTrue(FileController.LinkCombine("http://www.website.com", "Router") == "http://www.website.com/Router");
        }
    }
}