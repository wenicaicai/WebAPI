using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace WebApi
{
    public class Region
    {
        public static int region(int[] a, int currentSum, int i)
        {
            currentSum += a[i];
            WriteLine($"out {0}", currentSum);
            if (i < 3)
            {
                region(a, currentSum, i+1);
                WriteLine($"in {0}",currentSum);
            }
            WriteLine("Hello, complete.");
            return currentSum;
        }
    }
}
