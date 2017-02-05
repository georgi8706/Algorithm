using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Algorithms.Tests.Dynamic_Programming
{
    [TestClass]
    public class SubsetSumTests
    {
        SubsetSumWithoutRepetition _testableClass = new SubsetSumWithoutRepetition();

        [TestMethod]
        public void Test1_WithoutRepetiotion()
        {
            int[] input = { 3, 5, -1, 10, 5, 7 };

            var actualSeq = _testableClass.CalcPossibleSums(input, 19);

            var expectedSeq = new List<int>{ 5, 10, -1, 5 };

            CollectionAssert.AreEqual(actualSeq, expectedSeq);
        }

        [TestMethod]
        public void Test2_WithRepetition()
        {
            int[] input = { 3, 5, -1, 10, 5, 7 };

            var actualSeq = _testableClass.CalcPossibleSums(input, 19);

            var expectedSeq = new List<int> { 5, 10, -1, 5 };

            CollectionAssert.AreEqual(actualSeq, expectedSeq);
        }
    }
}
