using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.Common.Tree;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void TreeTestDFS()
        {
            Tree<int> tree = BuildSimpleTree();

            List<int> results = tree.TraverseDFS();

            var expectedResults = new List<int> { 14, 19, 23, 6, 10, 21, 15, 3 };
            
            CollectionAssert.AreEqual(results, expectedResults);
        }

        [TestMethod]
        public void TreeTestBFS()
        {
            Tree<int> tree = BuildSimpleTree();

            List<int> results = tree.TraverseBFS();

            var expectedResults = new List<int> { 14, 19, 15, 23, 6, 3, 10, 21 };

            CollectionAssert.AreEqual(results, expectedResults);
        }

        [TestMethod]
        public void TreeTestTraversePreorder()
        {
            Tree<int> tree = BuildSimpleTree();

            List<int> results = tree.TraversePreorder();

            var expectedResults = new List<int> { 14, 19, 23, 6, 10, 21, 15, 3 };

            CollectionAssert.AreEqual(results, expectedResults);
        }

        [TestMethod]
        public void TreeTestTraverseInorder()
        {
            Tree<int> tree = BuildSimpleTree();

            List<int> results = tree.TraverseInorder();

            var expectedResults = new List<int> { 23, 19, 10, 6, 21, 14, 3, 15 };

            CollectionAssert.AreEqual(results, expectedResults);
        }

        [TestMethod]
        public void TreeTestTraversePostorder()
        {
            Tree<int> tree = BuildSimpleTree();

            List<int> results = tree.TraversePostorder();

            var expectedResults = new List<int> { 23, 10, 21, 6, 19, 3, 15, 14 };

            CollectionAssert.AreEqual(results, expectedResults);
        }

        private Tree<int> BuildSimpleTree()
        {
            Tree<int> tree =
                         new Tree<int>(14, new Tree<int>(19,
                                     new Tree<int>(23),
                                     new Tree<int>(6,
                                        new Tree<int>(10),
                                        new Tree<int>(21))),
                               new Tree<int>(15,
                                     new Tree<int>(3))
                         );

            return tree;
        }
    }
}
