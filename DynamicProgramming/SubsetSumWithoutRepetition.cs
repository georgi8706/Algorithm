using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class SubsetSumWithoutRepetition
    {
        Dictionary<int, int> _possibleSums;

        public void Run()
        {
            int[] input = { 3, 5, -1, 10, 5, 7 };

            var seq = CalcPossibleSums(input, 19);

            Console.Write(19 + " = ");
            Console.Write(String.Join(" + ", seq) + "\n");
        }

        public List<int> CalcPossibleSums(int[] input, int desiredSum)
        {
            _possibleSums = new Dictionary<int, int>();
            _possibleSums.Add(0, 0);

            CalcPossibleSums(input);

            return RestoreSumSequence(desiredSum);
        }

        private List<int> RestoreSumSequence(int desiredSum)
        {
            var subSequence = new List<int>();

            if (_possibleSums.ContainsKey(desiredSum))
            {
                while (desiredSum > 0)
                {
                    subSequence.Add(_possibleSums[desiredSum]);

                    desiredSum -= _possibleSums[desiredSum];
                }
            }

            return subSequence;
        }

        private void CalcPossibleSums(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                var newSums = new Dictionary<int, int>();

                foreach (var sum in _possibleSums)
                {
                    int newSum = input[i] + sum.Key;

                    if (!_possibleSums.ContainsKey(newSum))
                    {
                        newSums.Add(newSum, input[i]);
                    }
                }

                foreach (var sum in newSums)
                {
                    _possibleSums.Add(sum.Key, sum.Value);
                }
            }
        }
    }
}
