using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphDijkstraTests
    {
        [TestMethod]
        public void GraphDjikstraTest()
        {
            Graph graph = CreateSimpleGraph1();

            var dijekstraFidner = new GraphDijkstra();
            dijekstraFidner.SetGraph(graph);

            int[] distances = dijekstraFidner.FindDistances(0);

            var expectedDistances = new int[graph.Count];

            expectedDistances[0] = 0;
            expectedDistances[1] = 37;
            expectedDistances[2] = 26;
            expectedDistances[3] = -1;
            expectedDistances[4] = 20;
            expectedDistances[5] = 15;
            expectedDistances[6] = 10;
            expectedDistances[7] = 41;
            expectedDistances[8] = 12;
            expectedDistances[9] = 42;
            expectedDistances[10] = -1;
            expectedDistances[11] = 31;

            CollectionAssert.AreEqual(distances, expectedDistances);
        }

        [TestMethod]
        public void GraphDjikstraTest2()
        {
            Graph graph = CreateSimpleGraph2();

            var dijekstraFidner = new GraphDijkstra();
            dijekstraFidner.SetGraph(graph);

            int[] distances = dijekstraFidner.FindDistances(0);

            var expectedDistances = new int[graph.Count];

            expectedDistances[0] = 0;
            expectedDistances[1] = 8;
            expectedDistances[2] = 14;
            expectedDistances[3] = 3;
            expectedDistances[4] = 6;
            expectedDistances[5] = 12;
            expectedDistances[6] = 12;
            expectedDistances[7] = 11;

            CollectionAssert.AreEqual(distances, expectedDistances);
        }

        private Graph CreateSimpleGraph1()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 6, 8 });
            graph.InsertNode(1, new int[] { 4, 7, 9, 11 });
            graph.InsertNode(2, new int[] { 7, 8, 11 });
            graph.InsertNode(3, new int[] { 10 });
            graph.InsertNode(4, new int[] { 1, 5, 6, 11 });
            graph.InsertNode(5, new int[] { 4, 6, 8, 11 });
            graph.InsertNode(6, new int[] { 0, 4, 5 });
            graph.InsertNode(7, new int[] { 1, 2, 9, 11 });
            graph.InsertNode(8, new int[] { 0, 2, 5 });
            graph.InsertNode(9, new int[] { 1, 7 });
            graph.InsertNode(10, new int[] { 3 });
            graph.InsertNode(11, new int[] { 1, 2, 4, 5, 7 });

            graph.CreateEdges();

            // Set weights of the edges
            graph[0, 6][0].Weight = 10;
            graph[0, 8][0].Weight = 12;
            graph[5, 6][0].Weight = 6;
            graph[5, 8][0].Weight = 3;
            graph[4, 6][0].Weight = 17;
            graph[2, 8][0].Weight = 14;
            graph[4, 5][0].Weight = 5;
            graph[5, 11][0].Weight = 33;
            graph[2, 11][0].Weight = 9;
            graph[2, 7][0].Weight = 15;
            graph[1, 4][0].Weight = 20;
            graph[4, 11][0].Weight = 11;
            graph[7, 11][0].Weight = 20;
            graph[1, 11][0].Weight = 6;
            graph[1, 7][0].Weight = 26;
            graph[1, 9][0].Weight = 5;
            graph[7, 9][0].Weight = 3;
            graph[3, 10][0].Weight = 7;

            return graph;
        }

        private Graph CreateSimpleGraph2()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1, 3, 4 });
            graph.InsertNode(1, new int[] { 0, 3 });
            graph.InsertNode(2, new int[] { 4, 5 });
            graph.InsertNode(3, new int[] { 0, 1, 5, 7 });
            graph.InsertNode(4, new int[] { 0, 2, 7 });
            graph.InsertNode(5, new int[] { 2, 3, 6 });
            graph.InsertNode(6, new int[] { 5, 7 });
            graph.InsertNode(7, new int[] { 3, 4, 6 });

            graph.CreateEdges();

            graph[0, 1][0].Weight = 8;
            graph[0, 3][0].Weight = 3;
            graph[0, 4][0].Weight = 6;
            graph[1, 3][0].Weight = 6;
            graph[2, 4][0].Weight = 8;
            graph[2, 5][0].Weight = 9;
            graph[3, 5][0].Weight = 9;
            graph[3, 7][0].Weight = 9;
            graph[4, 7][0].Weight = 5;
            graph[5, 6][0].Weight = 8;
            graph[6, 7][0].Weight = 1;

            return graph;
        }
    }
}
