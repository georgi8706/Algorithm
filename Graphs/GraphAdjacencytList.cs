using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Algorithms.Graphs_AdjacencyLists
{
    [DebuggerDisplay("{Index}, {Value.ToString()}")]
    public class Node
    {
        List<int> _childrenIndexes = new List<int>();

        public Node(int index, int[] childrenIndexes = null, dynamic value = null)
        {
            // Node without children
            Index = index;

            if (value != null)
            {
                Value = value;
            }
            else
            {
                Value = index;
            }

            if (childrenIndexes != null)
            {
                _childrenIndexes.AddRange(childrenIndexes);
            }
        }

        public int Index { get; protected set; }

        public dynamic Value { get; set; }

        // The indexes of the children nodes
        public List<int> Children
        {
            get
            {
                return _childrenIndexes;
            }
        }
    }

    [DebuggerDisplay("[{Node1.Index}, {Node2.Index}][{Node1.Value.ToString()}-{Node2.Value.ToString()}]Weight: {Weight}")]
    public class Edge : IComparable<Edge>
    {
        public Edge(Node node1, Node node2, double weight = 0)
        {
            Weight = weight;

            Node1 = node1;
            Node2 = node2;
        }

        public Node Node1 { get; set; }
        public Node Node2 { get; set; }

        public double Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int compareRes = -1;
            if (this.Weight > other.Weight)
            {
                compareRes = 1;
            }

            return compareRes;
        }

        public bool IsEqual(Edge other)
        {
            bool isEqual =
                (this.Node1 == other.Node1 || this.Node1 == other.Node2) &&
                (this.Node2 == other.Node1 || this.Node2 == other.Node2) &&
                this.Weight == other.Weight;

            return isEqual;
        }
    }

    /// <summary>
    /// Graph implemented with adjacency list.
    /// </summary>
    public class Graph
    {
        List<Node> _nodes = new List<Node>();
        List<Edge> _edges = new List<Edge>();

        public Graph(bool isDirected = false)
        {
            IsDirected = isDirected;
        }

        public bool IsDirected { get; protected set; }

        public List<Node> Nodes
        {
            get
            {
                return _nodes;
            }
        }

        public List<Edge> Edges
        {
            get
            {
                return _edges;
            }
        }

        /// <summary>
        /// Returns a node at a given position. 
        /// </summary>
        public Node this[int index]
        {
            get
            {
                if (index >= 0 && index < _nodes.Count)
                {
                    return _nodes[index];
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Returns a list with edges between two nodes.
        /// </summary>
        public List<Edge> this[int node1, int node2]
        {
            get
            {
                var edges = new List<Edge>();

                foreach (Edge edge in Edges)
                {
                    if ((edge.Node1.Index == node1 && edge.Node2.Index == node2) ||
                        (edge.Node1.Index == node2 && edge.Node2.Index == node1))
                    {
                        edges.Add(edge);
                    }
                }

                return edges;
            }
        }

        /// <summary>
        /// Returns the number of the nodes in the graph.
        /// </summary>
        public int Count
        {
            get
            {
                return _nodes.Count;
            }
        }

        public void CreateEdges()
        {
            foreach (Node node in Nodes)
            {
                foreach (int child in node.Children)
                {
                    if (!IsDirected)
                    {
                        bool isEdgeAlreadyAdded = _edges.Count(edge => edge.Node1.Index == child && edge.Node2.Index == node.Index) > 0;

                        if (isEdgeAlreadyAdded)
                        {
                            continue;
                        }
                    }

                    _edges.Add(new Edge(node, Nodes[child]));
                }
            }
        }

        public void InsertNode(int index, int[] children = null, dynamic value = null)
        {
            Node node = new Node(index, children, value);

            _nodes.Insert(index, node);
        }

        /// <summary>
        /// Deletes an edge (undirected).
        /// </summary>
        public void DeleteEdge(Edge edge)
        {
            if (Edges.Contains(edge))
            {
                edge.Node1.Children.Remove(edge.Node2.Index);
                edge.Node2.Children.Remove(edge.Node1.Index);

                _edges.Remove(edge);
            }
        }

        /// <summary>
        /// Returns the first node index that has the given value.
        /// </summary>
        public int GetNodeIndexFromValue(int nodeValue)
        {
            foreach (Node node in Nodes)
            {
                if (node.Value == nodeValue)
                {
                    return node.Index;
                }
            }

            return -1; // not found
        }

        /// <summary>
        /// Creates the graph nodes and dependencies from a table NxN, where N is the number of nodes in the graph.
        /// Each cell of the table is a character 'N' or 'Y', where Y means there is a directed edge between the two nodes
        /// described by the cell coordinates and N means there is not.
        /// </summary>
        public void CreateFromDependencyTable(List<string> dependencyTable)
        {
            for (int row = 0; row < dependencyTable.Count; row++)
            {
                var children = new List<int>();
                for (int col = 0; col < dependencyTable[row].Length; col++)
                {
                    if (dependencyTable[row][col] == 'Y')
                    {
                        children.Add(col);
                    }
                }

                InsertNode(row, children.ToArray(), null);
            }
        }
    }
}
