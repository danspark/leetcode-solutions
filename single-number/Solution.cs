using System;

namespace SingleNumber
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            int solution = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                solution ^= nums[i];
            }

            return solution;
        }
    }
}