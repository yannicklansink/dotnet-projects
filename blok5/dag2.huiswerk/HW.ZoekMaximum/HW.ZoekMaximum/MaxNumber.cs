using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.ZoekMaximum
{
    public class MaxNumber
    {
        private readonly List<int> numbers;
        private readonly int start;
        private readonly int end;

        public int MaxValue { get; set; }
        public int MaxIndex { get; set; }

        public MaxNumber(List<int> numbers, int start, int end)
        {
            this.numbers = numbers;
            this.start = start;
            this.end = end;
        }

        public void FindMax()
        {
            MaxValue = numbers[start];
            MaxIndex = start;

            for (int i = start; i < end; i++)
            {
                if (numbers[i] > MaxValue)
                {
                    MaxValue = numbers[i];
                    MaxIndex = i;
                }
            }
        }
    }
}
