using System;
using Algorithms;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.Tests.Dynamic_Programming
{
    [TestClass]
    public class LongestIncreasingSubsequenceTests
    {
        LongestIncreasingSubsequence _testableClass = new LongestIncreasingSubsequence();
        [TestMethod]
        public void Test1_Numbers()
        {
            var sequence = new int[] { 30, 1, 20, 2, 3, -1 };
            var expectedSeq = new int[] { 1, 2, 3 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test2_Numbers()
        {
            var sequence = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };
            var expectedSeq = new int[] { 3, 5, 7, 8, 9, 11 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test3_Numbers()
        {
            var sequence = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1, 12, 13, 14, 20, 15, 30, 16, 17, 40, 18, 19, 20 };
            var expectedSeq = new int[] { 3, 5, 7, 8, 9, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test4_Numbers()
        {
            var sequence = new int[] { 3, 4 };
            var expectedSeq = new int[] { 3, 4 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test5_Number()
        {
            var sequence = new int[] { 5 };
            var expectedSeq = new int[] { 5 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test6_EmptySequence()
        {
            var sequence = new int[] { };
            var expectedSeq = new int[] { };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test7_EqualNumbers()
        {
            var sequence = new int[] { 1, 1, 1 };
            var expectedSeq = new int[] { 1 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test8_DecreasingNumbers()
        {
            var sequence = new int[] { 3, 2, 1 };
            var expectedSeq = new int[] { 3 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        public void Test9_IncreasingNumbers()
        {
            var sequence = new int[] { 1, 2, 3 };
            var expectedSeq = new int[] { 1, 2, 3 };
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            CollectionAssert.AreEqual(expectedSeq, actualSeq);
        }

        [TestMethod]
        [Timeout(500)]
        public void Test10_Performance5000Numbers()
        {
            var sequence = Enumerable.Range(1, 5000).ToArray();
            sequence[500] = 0;
            sequence[2000] = 0;
            sequence[4999] = 0;
            var actualSeq = _testableClass.FindLongestIncreasingSubsequence(sequence);
            Assert.AreEqual(4997, actualSeq.Length);
        }
    }
}
