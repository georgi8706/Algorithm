using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.Common.BinaryTree;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphBiconnectivityTests
    {
        [TestMethod]
        public void GraphBiconnectivityTests1()
        {
            Graph graph = CreateSimpleGraph();

            var biConnectivityFinder = new GraphBiconnectivity();
            biConnectivityFinder.SetGraph(graph);

            List<int> points = biConnectivityFinder.FindArticulationPoints();

            var expectedPoints = new List<int>() { 7, 0, 6, 4 };

            CollectionAssert.AreEquivalent(points, expectedPoints);

            BuildTree();
        }

        private void BuildTree()
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
        }

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            // Component 1
            graph.InsertNode(0, new int[] { 1, 2, 6, 7, 9 });
            graph.InsertNode(1, new int[] { 0, 6 });
            graph.InsertNode(2, new int[] { 0, 7 });
            graph.InsertNode(3, new int[] { 4 });
            graph.InsertNode(4, new int[] { 3, 6, 10 });
            graph.InsertNode(5, new int[] { 7 });
            graph.InsertNode(6, new int[] { 0, 1, 4, 8, 10, 11 });
            graph.InsertNode(7, new int[] { 0, 2, 5, 9 });
            graph.InsertNode(8, new int[] { 6, 11 });
            graph.InsertNode(9, new int[] { 0, 7 });
            graph.InsertNode(10, new int[] { 4, 6 });
            graph.InsertNode(11, new int[] { 6, 8 });

            graph.CreateEdges();

            return graph;
        }
    }
}
