using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LongestIncreasingSubsequence
    {
        int[] _inputSeq;
        int[] _longestSubsequenceAtIndex;
        int[] _prev;

        public void Run()
        {
            // For this sequence:
            // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 - indexes
            // 1, 2, 2, 3, 4, 3, 4, 5, 6, 6, 1  - longest increasing subsequences
            int[] inputSeq = new int[] { 3, 14, 5, 12, 15, 7, 8, 9, 11, 10, 1 };

            //int[] inputSeq = Utils.GenerateRandomIntegerArray(30, 100);

            var lis = FindLongestIncreasingSubsequence(inputSeq);

            Console.WriteLine("Longest increasing subsequence (LIS)");
            Console.WriteLine("  Length: {0}", lis.Length);
            Console.WriteLine("  Sequence: ");

            lis.Print();
        }

        public int[] FindLongestIncreasingSubsequence(int[] inputSeq)
        {
            if (inputSeq.Length < 1)
            {
                return inputSeq;
            }

            _inputSeq = inputSeq;
            _prev = new int[_inputSeq.Length];

            int longestSeqLen = 0;
            int longestSeqIndex = 0;

            // Find LIS max length and index of its last element at each index / O(n) 
            _longestSubsequenceAtIndex = new int[_inputSeq.Length];
            for (int i = 0; i < _inputSeq.Length; i++)
            {
                int maxLength;
                int lastElement;

                if (i == 0)
                {
                    maxLength = 0;
                    lastElement = -1;
                }
                else
                {
                    GetLISMaxLengthAndLastElement(i, out maxLength, out lastElement);
                }

                _longestSubsequenceAtIndex[i] = maxLength + 1;
                _prev[i] = lastElement;

                if (maxLength > longestSeqLen)
                {
                    longestSeqLen = maxLength;
                    longestSeqIndex = i;
                }
            }

            int lastIndex = longestSeqIndex;
            var lis = new List<int>();
            while (lastIndex != -1)
            {
                lis.Add(_inputSeq[lastIndex]);

                lastIndex = _prev[lastIndex];
            }

            lis.Reverse();
            return lis.ToArray();
        }

        private void GetLISMaxLengthAndLastElement(int x, out int maxLength, out int lastElementIndex)
        {
            maxLength = 0;
            lastElementIndex = -1;

            for (int i = 0; i < _longestSubsequenceAtIndex.Length; i++)
            {
                if (_longestSubsequenceAtIndex[i] == 0)
                {
                    break;
                }

                if (_inputSeq[i] < _inputSeq[x] && maxLength < _longestSubsequenceAtIndex[i])
                {
                    maxLength = _longestSubsequenceAtIndex[i];
                    lastElementIndex = i;
                }
            }
        }
    }
}
