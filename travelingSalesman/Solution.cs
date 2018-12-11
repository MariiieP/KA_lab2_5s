using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace travelingSalesman
{
    public class Solution
    {
        public int city;
        public int cost;
        public int[,] matrix;
        public int[] remainingcity;
        public int city_left_to_expand;
        public List<Int32> stack;

        public Solution(int number)
        {
            matrix = new int[number,number];
            stack = new List<int>();
        }
    }
}
