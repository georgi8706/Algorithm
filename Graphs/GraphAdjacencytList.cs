using System;
using System.Collections.Generic;

namespace Algorithms.Graphs_AdjacencyLists
{
    public class Node
    {
        dynamic _value;

        List<int> _childrenIndexes = new List<int>();

        public Node()
        {
            // Node without children
        }

        public Node(int[] childrenIndexes)
        {
            _childrenIndexes.AddRange(childrenIndexes);
        }

        public List<int> ChildrenIndexes
        {
            get
            {
                return _childrenIndexes;
            }
        }

        public int Index { get; set; }

        public dynamic Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }

    /// <summary>
    /// Graph implemented with adjacency list.
    /// </summary>
    public class Graph
    {
        List<Node> _nodes = new List<Node>();

        public List<Node> Nodes
        {
            get
            {
                return _nodes;
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
        /// Returns the number of the nodes in the graph.
        /// </summary>
        public int Count
        {
            get
            {
                return _nodes.Count;
            }
        }


        public void InsertNode(int index, int[] children = null, dynamic value = null)
        {
            Node node;

            if (children != null)
            {
                node = new Node(children);
            }
            else
            {
                node = new Node();
            }

            node.Index = index;

            if (value != null)
            {
                node.Value = value;
            }
            else
            {
                node.Value = index;
            }

            _nodes.Insert(index, node);
        }

        /// <summary>
        /// Returns the first node that has the given value.
        /// </summary>
        public int GetNodeIdFromValue(int nodeValue)
        {
            foreach(Node node in Nodes)
            {
                if(node.Value == nodeValue)
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
            for(int row = 0; row < dependencyTable.Count; row++)
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
