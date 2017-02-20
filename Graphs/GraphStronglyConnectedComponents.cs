using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;
using Algorithms.Common;

namespace Algorithms
{
    // Algorithm of Kosaraju-Sharir
    public class GraphStronglyConnectedComponents
    {
        Graph _graph;

        Stack<int> _componentPath;

        List<int>[] _reverseGraph;

        List<int> _visitedNodes = new List<int>();

        List<List<int>> _components;

        List<int> _singleComponent;

        public void SetGraph(Graph graph)
        {
            _componentPath = new Stack<int>();

            _visitedNodes = new List<int>();

            _graph = graph;
        }

        public List<List<int>> FindStronglyConnectedComponents()
        {
            _components = new List<List<int>>();

            BuildReverseGraph();

            _visitedNodes.Clear();

            foreach (Node node in _graph.Nodes)
            {
                DFS(node.Index);
            }

            _visitedNodes.Clear();

            while(_componentPath.Count > 0)
            {
                int node = _componentPath.Pop();

                if(!_visitedNodes.Contains(node))
                {
                    _singleComponent = new List<int>();
                    ReverseDFS(node);
                    _components.Add(_singleComponent);
                }
            }

            return _components;
        }

        private void BuildReverseGraph()
        {
            _reverseGraph = new List<int>[_graph.Count];

            for (int node = 0; node < _graph.Count; node++)
            {
                _reverseGraph[node] = new List<int>();
            }

            for (int node = 0; node < _graph.Count; node++)
            {
                foreach (var childNode in _graph[node].Children)
                {
                    _reverseGraph[childNode].Add(node);
                }
            }
        }

        private void DFS(int node)
        {
            if (!_visitedNodes.Contains(node))
            {
                _visitedNodes.Add(node);

                foreach (var child in _graph[node].Children)
                {
                    DFS(child);
                }

                _componentPath.Push(node);
            }
        }

        private void ReverseDFS(int node)
        {
            if (!_visitedNodes.Contains(node))
            {
                _visitedNodes.Add(node);

                _singleComponent.Add(node);

                foreach (var child in _reverseGraph[node])
                {
                    ReverseDFS(child);
                }
            }
        }
    }
}
