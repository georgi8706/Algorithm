using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphMSTresolvedViaKruskalTests
    {
        [TestMethod]
        public void GraphMSTresolvedViaKruskalTest()
        {
            Graph graph = CreateSimpleGraph();

            var mstFinder = new GraphMSTresolvedViaKruskal();
            mstFinder.SetGraph(graph);

            List<int> mstPath = mstFinder.FindMST();

            var expectedMSTpath = new List<int>() { 1, 2, 3};

            CollectionAssert.AreEqual(mstPath, expectedMSTpath);
        }

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            // Component 1
            graph.InsertNode(0, new int[] { 1, 4, 3 }, '1');
            graph.InsertNode(1, new int[] { 0, 2 }, '2');
            graph.InsertNode(2, new int[] { 1, 4 }, '3');
            graph.InsertNode(3, new int[] { 0 }, '4');
            graph.InsertNode(4, new int[] { 0, 2 }, '5');

            // Component 2
            graph.InsertNode(5, new int[] { 6, 7 }, '6');
            graph.InsertNode(6, new int[] { 5, 7 }, '7');
            graph.InsertNode(7, new int[] { 5, 6 }, '8');

            return graph;
        }
    }
}
