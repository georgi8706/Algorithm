using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class MoveDownRightSum
    {
        int[,] _table;
        List<int> _seq;

        // Key string "x,y" with value sum
        Dictionary<string, double> _sumsAtCells;

        int[,] tableSums;

        public void Run()
        {
            int[,] table =
            {
                {2, 6, 1, 8, 9, 4, 2},
                {1, 8, 0, 3, 5, 6, 7},
                {3, 4, 8, 7, 2, 1, 8},
                {0, 9, 2, 8, 1, 7, 9},
                {2, 7, 1, 9, 7, 8, 2},
                {4, 5, 6, 1, 2, 5, 6},
                {9, 3, 5, 2, 8, 1, 9},
                {2, 3, 4, 1, 7, 2, 8}
            };

            TimeUtils.StartWatch();

            double sum;
            var actualSeq = FindLargestSumAndSequence(table, out sum);

            TimeUtils.StopWatch();

            actualSeq.Print();

            Console.WriteLine("Sum: " + sum);
        }

        public int[] FindLargestSumAndSequence(int[,] inputTable, out double sum)
        {
            _table = inputTable;
            _sumsAtCells = new Dictionary<string, double>();

            int x = _table.GetLength(1);
            int y = _table.GetLength(0);

            tableSums = new int[y, x];

            sum = CalcSum(x - 1, y - 1); // TODO Start from last

            _seq = new List<int>();
            CalcSequence(x - 1, y - 1);

            _seq.Reverse();

            return _seq.ToArray();
        }

        private double CalcSum(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            string place = x.ToString() + "," + y.ToString();

            if (_sumsAtCells.ContainsKey(place))
            {
                double val;
                _sumsAtCells.TryGetValue(place, out val);

                return val;
            }

            double sumTop = CalcSum(x, y - 1);
            double sumLeft = CalcSum(x - 1, y);

            double cellSum = sumTop > sumLeft ? sumTop : sumLeft;

            cellSum += _table[y, x];
            _sumsAtCells.Add(place, cellSum);

            tableSums[y, x] = (int)cellSum;

            return cellSum;
        }

        private void CalcSequence(int x, int y)
        {
            if (x >= 0 && y >= 0)
            {
                double sumTop = 0;
                if (y > 0)
                {
                    sumTop = tableSums[y - 1, x];
                }

                double sumLeft = 0;
                if (x > 0)
                {
                    sumLeft = tableSums[y, x - 1];
                }

                if (sumTop > sumLeft)
                {
                    _seq.Add(_table[y, x]);
                    CalcSequence(x, y - 1);

                }
                else
                {
                    _seq.Add(_table[y, x]);
                    CalcSequence(x - 1, y);
                }
            }
        }
    }
}
