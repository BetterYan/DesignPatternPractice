using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class ArrayBackedProperties : IEnumerable<int>
    {
        private int[] stats = new int[3];
        private const int strength = 0;

        public int Strength
        {
            get => stats[strength];
            set => stats[strength] = value;
        }

        //some other properties
        public double AverageStat => stats.Average();

        public double SumOfStats => stats.Sum();
        public double MaxStat => stats.Max();

        public IEnumerable<int> Stats => stats;

        public IEnumerator<int> GetEnumerator()
        {
            return stats.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int this[int index]
        {
            get => stats[index];
            set => stats[index] = value;
        }
    }
}