using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.Graphs_AdjacencyLists;

namespace Algorithms.Tests.Graphs
{
    [TestClass]
    public class GraphSalaryCalculatorTests
    {
        [TestMethod]
        public void GraphSalaryTest()
        {
            Graph graph = CreateSimpleGraph();

            var salaryCalculator = new GraphSalaryCalculator();
            salaryCalculator.SetGraph(graph);

            List<int> salaries = salaryCalculator.Calculate(graph);

            var expectedSalaries = new List<int>() { 1, 6, 3, 1, 4, 2 };

            CollectionAssert.AreEqual(salaries, expectedSalaries);
        }

        private Graph CreateSimpleGraph()
        {
            var graph = new Graph();

            var dependencyTable = new List<string>{"NNNNNN",
                                                   "YNYNNY",
                                                   "YNNNNY",
                                                   "NNNNNN",
                                                   "YNYNNN",
                                                   "YNNYNN"};

            graph.CreateFromDependencyTable(dependencyTable);

            return graph;
        }
    }
}
