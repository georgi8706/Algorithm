using System;
using Algorithms;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.Dynamic_Programming
{
    [TestClass]
    public class MoveDownRightSumTests
    {
        MoveDownRightSum _testableClass = new MoveDownRightSum();

        [TestMethod]
        public void Test1_Numbers()
        {
            int[,] table =
            {
                {2, 6, 1, 8, 9, 4, 2},
                {1, 8, 0, 3, 5, 6, 7},
                {3, 4, 8, 7, 2, 1, 8},
                {0, 9, 2, 8, 1, 7, 9},
                {2, 7, 1, 9, 7, 8, 2},
                {4, 5, 6, 1, 2, 5, 6},
                {9, 3, 5, 2, 8, 1, 9},
                {2, 3, 4, 1, 7, 2, 8}
            };

            var expectedSeq = new int[] { 2, 6, 8, 4, 8, 7, 8, 9, 7, 8, 5, 6, 9, 8 };
            double expectedSum = 95;

            double actualSum;
            var actualSeq = _testableClass.FindLargestSumAndSequence(table, out actualSum);

            CollectionAssert.AreEqual(expectedSeq, actualSeq);
            Assert.AreEqual(actualSum, expectedSum);
        }
    }
}
