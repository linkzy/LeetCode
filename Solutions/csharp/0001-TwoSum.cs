//https://leetcode.com/problems/two-sum/submissions/1100465816

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class TwoSum
    {
        private readonly int[] nums;
        private readonly int target;

        public TwoSum()
        {
            // Fill nums array with a million random numbers
            Random rand = new Random();
            nums = Enumerable.Repeat(0, 2000).Select(i => rand.Next(-1000000000, 1000000000)).ToArray();
            target = nums[nums.Length - 2] + nums[nums.Length - 1];
        }

        [Fact]
        public int[] TwoSumHashTable()
        {
            Dictionary<int, int> table = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (table.ContainsKey(complement))
                {
                    return new int[] { table[complement], i };
                }
                table[nums[i]] = i;
            }
            return null;
        }

        [Fact]
        public int[] TwoSumLoop()
        {
            int n = nums.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return null;
        }
    }
}
