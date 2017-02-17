using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphStronglyConnectedComponentsTests
    {
        [TestMethod]
        public void GraphStronglyConnectedComponentsTests1()
        {
            Graph graph = CreateSimpleGraph();

            var stronglyConnectedComponentsFinder = new GraphStronglyConnectedComponents();
            stronglyConnectedComponentsFinder.SetGraph(graph);

            List<List<int>> components = stronglyConnectedComponentsFinder.FindStronglyConnectedComponents();

            var component1 = new List<int>() { 5 };
            var component2 = new List<int>() { 7, 12 };
            var component3 = new List<int>() { 0, 1, 2, 6, 9, 13 };
            var component4 = new List<int>() { 11 };
            var component5 = new List<int>() { 8 };
            var component6 = new List<int>() { 10 };
            var component7 = new List<int>() { 3, 4 };

            var expectedComponents = new List<List<int>>() { component1, component2, component3, component4, component5, component6, component7 };

            CollectionAssert.AreEqual(components, expectedComponents);
        }

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1, 11, 13 });
            graph.InsertNode(1, new int[] { 6 });
            graph.InsertNode(2, new int[] { 0 });
            graph.InsertNode(3, new int[] { 4 });
            graph.InsertNode(4, new int[] { 3, 6 });
            graph.InsertNode(5, new int[] { 13 });
            graph.InsertNode(6, new int[] { 0, 11 });
            graph.InsertNode(7, new int[] { 12 });
            graph.InsertNode(8, new int[] { 6, 11 });
            graph.InsertNode(9, new int[] { 0 });
            graph.InsertNode(10, new int[] { 4, 6, 10 });
            graph.InsertNode(11);
            graph.InsertNode(12, new int[] { 7 });
            graph.InsertNode(13, new int[] { 2, 9 });

            return graph;
        }
    }
}
