using System;

namespace SingleNumber
{
    public class Solution
    {
        public int SingleNumber(int[] nums)
        {
            Array.Sort(nums);

            int previousNumber = nums[0];
            int appearances = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                var currentNumber = nums[i];

                if (previousNumber != currentNumber)
                {
                    if (appearances == 1) break;

                    previousNumber = currentNumber;
                    appearances = 0;
                }

                appearances++;
            }

            return previousNumber;
        }
    }
}