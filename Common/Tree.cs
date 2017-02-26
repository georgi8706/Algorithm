using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Common.Tree
{
    [DebuggerDisplay("{Value.ToString()}")]
    public class Node<T>
    {
        T _value;
        public List<Node<T>> _children;

        public List<Node<T>> Children
        {
            get
            {
                return _children;
            }
        }

        Node() { } // Forbid empty constructor

        public Node(T value)
        {
            _children = new List<Node<T>>();

            _value = value;
        }

        public T Value { get { return _value; } }

        public void AddChild(Node<T> child)
        {
            _children.Add(child);
        }
    }

    public class Tree<T>
    {
        Node<T> _root;

        // Members for internal calculations
        List<T> _visitedNodesValues = new List<T>();
        Queue<Node<T>> _visitedNodes = new Queue<Node<T>>();

        public Node<T> Root
        {
            get
            {
                return _root;
            }
            protected set
            {
                _root = value;
            }
        }

        private Tree() { } // Forbid empty constructor

        public Tree(T value)
        {
            Root = new Node<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) :
            this(value)
        {
            foreach (Tree<T> child in children)
            {
                Root.AddChild(child.Root);
            }
        }

        /// <summary>
        /// Traverses a binary tree in order: Left, Root, Right
        /// <remarks>As we use a regular tree and not a binary tree, we rely on the fact 
        /// that the first inserter child is the left and the second is the right.</remarks>
        /// </summary>
        public List<T> TraverseInorder()
        {
            _visitedNodesValues.Clear();

            TraverseInorder(_root);

            return _visitedNodesValues;
        }

        /// <summary>
        /// Traverses a binary tree in order: Root, Left, Right
        /// <remarks>As we use a regular tree and not a binary tree, we rely on the fact 
        /// that the first inserter child is the left and the second is the right.</remarks>
        /// </summary>
        public List<T> TraversePreorder()
        {
            _visitedNodesValues.Clear();

            TraversePreorder(_root);

            return _visitedNodesValues;
        }

        /// <summary>
        /// Traverses a binary tree in order: Left, Right, Root
        /// <remarks>As we use a regular tree and not a binary tree, we rely on the fact 
        /// that the first inserter child is the left and the second is the right.</remarks>
        /// </summary>
        public List<T> TraversePostorder()
        {
            _visitedNodesValues.Clear();

            TraversePostorder(_root);

            return _visitedNodesValues;
        }

        public List<T> TraverseDFS()
        {
            _visitedNodesValues.Clear();

            DFS(_root);

            return _visitedNodesValues;
        }

        public List<T> TraverseBFS()
        {
            _visitedNodesValues.Clear();
            _visitedNodes.Clear();

            BFS(_root);

            return _visitedNodesValues;
        }

        void DFS(Node<T> node)
        {
            _visitedNodesValues.Add(node.Value);

            foreach (var child in node.Children)
            {
                DFS(child);
            }
        }

        void BFS(Node<T> node)
        {
            _visitedNodesValues.Add(node.Value);

            foreach (var child in node.Children)
            {
                _visitedNodes.Enqueue(child);
            }

            if (_visitedNodes.Count > 0)
            {
                BFS(_visitedNodes.Dequeue());
            }
        }

        void TraverseInorder(Node<T> node)
        {
            // Check if the tree is a binary tree
            if (node.Children.Count < 3)
            {
                // Left
                if (node.Children.Count > 0)
                {
                    TraverseInorder(node.Children[0]);
                }

                // Root
                _visitedNodesValues.Add(node.Value);

                // Right
                if (node.Children.Count > 1)
                {
                    TraverseInorder(node.Children[1]);
                }
            }
            else
            {
                throw new System.InvalidOperationException("The tree is not a binary!");
            }
        }

        void TraversePreorder(Node<T> node)
        {
            // Root
            _visitedNodesValues.Add(node.Value);

            // Check if the tree is a binary tree
            if (node.Children.Count < 3)
            {
                // Left
                if (node.Children.Count > 0)
                {
                    TraversePreorder(node.Children[0]);
                }

                // Right
                if (node.Children.Count > 1)
                {
                    TraversePreorder(node.Children[1]);
                }
            }
            else
            {
                throw new System.InvalidOperationException("The tree is not a binary!");
            }
        }

        void TraversePostorder(Node<T> node)
        {
            // Check if the tree is a binary tree
            if (node.Children.Count < 3)
            {
                // Left
                if (node.Children.Count > 0)
                {
                    TraversePostorder(node.Children[0]);
                }

                // Right
                if (node.Children.Count > 1)
                {
                    TraversePostorder(node.Children[1]);
                }
            }
            else
            {
                throw new System.InvalidOperationException("The tree is not a binary!");
            }

            // Root
            _visitedNodesValues.Add(node.Value);
        }
    }
}
