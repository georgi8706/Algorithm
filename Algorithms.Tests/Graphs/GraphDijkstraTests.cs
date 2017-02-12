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
            Graph graph = CreateSimpleGraph();

            var dijekstraFidner = new GraphDijkstra();
            dijekstraFidner.SetGraph(graph);

            List<KeyValuePair<Node, int>> pathDistances = dijekstraFidner.FindDistances(0);

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

            if (pathDistances.Count != expectedDistances.Length)
            {
                foreach (KeyValuePair<Node, int> distToNode in pathDistances)
                {
                    Assert.AreEqual(distToNode.Value, expectedDistances[distToNode.Key.Index]);
                }
            }
            else
            {
                Assert.Fail();
            }
        }

        private Graph CreateSimpleGraph()
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
    }
}
