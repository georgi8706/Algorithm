﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    public class GraphTraversingWithDFS
    {
        Graph _graph;
        List<int> _visitedNodes;

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            graph.InsertNode(0, new int[] { 3, 6 });
            graph.InsertNode(1, new int[] { 2, 3, 4, 5, 6 });
            graph.InsertNode(2, new int[] { 1, 4, 5 });
            graph.InsertNode(3, new int[] { 0, 1, 5 });
            graph.InsertNode(4, new int[] { 1, 2, 6 });
            graph.InsertNode(5, new int[] { 1, 2, 3 });
            graph.InsertNode(6, new int[] { 0, 1, 4 });

            return graph;
        }

        public void Run()
        {
            Graph graph = CreateSimpleGraph();

            bool useRecursiveAlgorithm = true;

            TraverseGraph(graph, 4, useRecursiveAlgorithm);

            string algorithm = useRecursiveAlgorithm ? "recursive algorithm" : "iterative algorithm";

            Console.Write("DFS traversal result using " + algorithm + ": " + String.Join(", ", _visitedNodes) + "\n");
        }

        /// <summary>
        /// Traverses all the nodes of the graph starting from a given node.
        /// </summary>
        public List<int> TraverseGraph(Graph graph, int startNode, bool useReqursiveTraversing)
        {
            _graph = graph;
            _visitedNodes = new List<int>();

            if (useReqursiveTraversing)
            {
                TraverseGraphUsingRecursion(startNode);
            }
            else
            {
                TraverseGraphUsingIteration(startNode);
            }

            return _visitedNodes;
        }

        private void TraverseGraphUsingIteration(int node)
        {
            var nodes = new Stack<int>();
            nodes.Push(node);

            while (nodes.Count > 0)
            {
                node = nodes.Pop();

                if (!_visitedNodes.Contains(node))
                {
                    _visitedNodes.Add(node);

                    var predecessors = _graph[node].PredecessorsIndexes;

                    predecessors.Reverse();

                    foreach (var predecessor in predecessors)
                    {
                        nodes.Push(predecessor);
                    }
                }
            }
        }

        private void TraverseGraphUsingRecursion(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return;
            }

            _visitedNodes.Add(nodeIndex);

            foreach (var predecessor in _graph[nodeIndex].PredecessorsIndexes)
            {
                TraverseGraphUsingRecursion(predecessor);
            }
        }
    }
}
