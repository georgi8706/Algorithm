using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.Common.BinaryTree;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class BinaryTreeTests
    {
        [TestMethod]
        public void BinaryTreeTestDFS()
        {
            Tree<int> tree = BuildSimpleTree();
        }

        private Tree<int> BuildSimpleTree()
        {

            var left = new Node<int>(5);
            var right = new Node<int>(11);

            right = new Node<int>(6, left, right);
            left = new Node<int>(2);

            var rootLeft = new Node<int>(7, left, right);

            left = new Node<int>(4);
            right = new Node<int>(9, left);

            var rootRight = new Node<int>(5, null, right);

            var root = new Node<int>(2, rootLeft, rootRight);

            var tree = new Tree<int>(root);

            return tree;
        }
    }
}
