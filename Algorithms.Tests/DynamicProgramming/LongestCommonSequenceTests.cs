using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Algorithms.Tests.Dynamic_Programming
{
    [TestClass]
    public class LongestCommonSequenceTests
    {
        LongestCommonSequence _testableClass = new LongestCommonSequence();

        [TestMethod]
        public void Test1_Base()
        {
            string A = "ABCBDAB";
            string B = "BDCABA";

            string lcs = _testableClass.FindLongestCommonSequence(A, B);

            var expectedSeq = "BCBA";

            Assert.AreEqual(lcs, expectedSeq);
        }
    }
}
