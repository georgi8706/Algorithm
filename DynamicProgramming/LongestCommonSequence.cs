using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class LongestCommonSequence
    {
        const int NOT_CALCULATED = -1;

        private int[,] _lis;

        private string _A;
        private string _B;

        public string Run()
        {
            string A = "GCCCTAGCG";
            string B = "GCGCAATG";

            string lcs = FindLongestCommonSequence(A, B);

            return lcs;
        }

        public string FindLongestCommonSequence(string a, string b)
        {
            _A = a;
            _B = b;

            _lis = new int[a.Length, b.Length];

            InitializeLCS();

            CalcLIS(a.Length - 1, b.Length - 1);

            return PrintLcs(a.Length - 1, b.Length - 1);
        }

        private void InitializeLCS()
        {
            for (int x = 0; x < _A.Length; x++)
            {
                for (int y = 0; y < _B.Length; y++)
                {
                    _lis[x, y] = NOT_CALCULATED;
                }
            }
        }

        private int CalcLIS(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (_lis[x, y] == NOT_CALCULATED)
            {
                int left = CalcLIS(x - 1, y);
                int top = CalcLIS(x, y - 1);

                _lis[x, y] = Math.Max(left, top);

                if (_A[x] == _B[y])
                {
                    int lcsBothMinusOne = 1 + CalcLIS(x - 1, y - 1);
                    _lis[x, y] = Math.Max(_lis[x, y], lcsBothMinusOne);
                }
            }

            return _lis[x, y];
        }

        private string PrintLcs(int x, int y)
        {
            var lcsLetters = new List<char>();

            while (x >= 0 && y >=0 )
            {
                if ((_A[x] == _B[y]) && (CalcLIS(x - 1, y - 1) + 1 == _lis[x, y]) )
                {
                    lcsLetters.Add(_A[x]);
                    x--;
                    y--;
                }
                else if(CalcLIS(x - 1, y) == _lis[x, y])
                {
                    x--;
                }
                else
                {
                    y--;
                }
            }

            lcsLetters.Reverse();

            return string.Join("", lcsLetters);
        }
    }
}
