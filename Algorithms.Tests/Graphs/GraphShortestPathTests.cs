using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Graphs;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphShortestDistanceTests
    {
        GraphShortestDistanceBetweenTwoNodes _graphDistanceFinder = new GraphShortestDistanceBetweenTwoNodes();

        [TestMethod]
        public void ShortestDistance1()
        {
            Graph graph = CreateSimpleGraph1();
            _graphDistanceFinder.SetGraph(graph);

            // Test a pair of nodes
            int distance = _graphDistanceFinder.Find(1, 2);
            Assert.AreEqual(distance, 1);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(2, 1);
            Assert.AreEqual(distance, -1); // -1 means that there is no path
        }

        [TestMethod]
        public void ShortestDistance2()
        {
            Graph graph = CreateSimpleGraph2();
            _graphDistanceFinder.SetGraph(graph);

            // Test a pair of nodes
            int distance = _graphDistanceFinder.Find(1, 6);
            Assert.AreEqual(distance, 2);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(1, 5);
            Assert.AreEqual(distance, -1); // -1 means that there is no path

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(5, 6);
            Assert.AreEqual(distance, 3);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(5, 8);
            Assert.AreEqual(distance, 1); 
        }

        [TestMethod]
        public void ShortestDistance3()
        {
            Graph graph = CreateSimpleGraph3();
            _graphDistanceFinder.SetGraph(graph);

            // Test a pair of nodes
            int distance = _graphDistanceFinder.Find(11, 7);
            Assert.AreEqual(distance, 3);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(11, 21);
            Assert.AreEqual(distance, 3);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(21, 4);
            Assert.AreEqual(distance, -1); // -1 means that there is no path

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(19, 14);
            Assert.AreEqual(distance, 2);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(1, 4);
            Assert.AreEqual(distance, 2);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(1, 11);
            Assert.AreEqual(distance, -1); // -1 means that there is no path

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(31, 21);
            Assert.AreEqual(distance, -1); // -1 means that there is no path

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(11, 14);
            Assert.AreEqual(distance, 4);

            // Test a pair of nodes
            distance = _graphDistanceFinder.Find(11, 31);
            Assert.AreEqual(distance, 4);
        }

        [TestMethod]
        public void ShortestDistance4()
        {
            Graph graph = CreateSimpleGraph4();
            _graphDistanceFinder.SetGraph(graph);

            // Test a pair of nodes
            int distance = _graphDistanceFinder.Find(0, 5);
            Assert.AreEqual(distance, 3);
        }

        private Graph CreateSimpleGraph1()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1 }, 1);
            graph.InsertNode(1, null, 2);
 
            return graph;
        }

        private Graph CreateSimpleGraph2()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 3 }, 1);
            graph.InsertNode(1, new int[] { 3 }, 2);
            graph.InsertNode(2, new int[] { 3, 4 }, 3);
            graph.InsertNode(3, new int[] { 5 }, 4);
            graph.InsertNode(4, new int[] { 2, 6, 7 }, 5);
            graph.InsertNode(5, null, 6);
            graph.InsertNode(6, new int[] { 7 }, 7);
            graph.InsertNode(7, null, 8);

            return graph;
        }

        private Graph CreateSimpleGraph3()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1 }, 11);
            graph.InsertNode(1, new int[] { 2, 3 }, 4);
            graph.InsertNode(2, new int[] { 1, 4 }, 12);
            graph.InsertNode(3, new int[] { 6, 2, 5 }, 1);
            graph.InsertNode(4, new int[] { 3, 5 }, 19);
            graph.InsertNode(5, new int[] { 7, 8 }, 21);
            graph.InsertNode(6, new int[] { 5 }, 7);
            graph.InsertNode(7, null, 31);
            graph.InsertNode(8, new int[] { 8 }, 14);

            return graph;
        }

        private Graph CreateSimpleGraph4()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 1, 2 });
            graph.InsertNode(1, new int[] { 3 });
            graph.InsertNode(2, new int[] { 1, 4 });
            graph.InsertNode(3, new int[] { 4 });
            graph.InsertNode(4, new int[] { 5 });
            graph.InsertNode(5);

            return graph;
        }
    }
}
