using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms
{
    public class GraphSalaryCalculator
    {
        Graph _graph;
        List<int> _visitedNodes = new List<int>();
        int[] _salaries;


        public void SetGraph(Graph graph)
        {
            _graph = graph;
        }

        /// <summary>
        /// Returns a list with the salaries ordered by the node indexes. 
        /// For example the first salary will be of the employee on node with index 0.
        /// </summary>
        public List<int> Calculate(Graphs_AdjacencyLists.Graph graph)
        {
            _salaries = new int[_graph.Count];//Enumerable.Repeat(1, _graph.Count).ToArray();

            // Find the big bosses. These are the nodes that do not have any managers (node without any parents).
            List<int> bigBosses = new List<int>();

            foreach (var node in _graph.Nodes)
            {
                bool isBigBoss = true;

                foreach (var node2 in _graph.Nodes)
                {
                    if (node2.Children.Contains(node.Index))
                    {
                        isBigBoss = false;
                        break;
                    }
                }

                if (isBigBoss)
                {
                    bigBosses.Add(node.Index);
                }
            }

            foreach(int bigBoss in bigBosses)
            {
                CalculateSalary(bigBoss);
            }
      
            return _salaries.ToList();
        }

        /// <summary>
        /// Traverses a graph by DFS recursively.
        /// </summary>
        private int CalculateSalary(int nodeIndex)
        {
            if (_visitedNodes.Contains(nodeIndex))
            {
                return _salaries[nodeIndex];
            }

            _visitedNodes.Add(nodeIndex);

            int salary;

            if (_graph[nodeIndex].Children.Count > 0)
            {
                // Salary is sum of children salaries
                salary = 0;

                foreach (var child in _graph[nodeIndex].Children)
                {
                    salary += CalculateSalary(child);
                }
            }
            else
            {
                salary = 1;
            }

            _salaries[nodeIndex] = salary;

            return _salaries[nodeIndex];
        }
    }
}
