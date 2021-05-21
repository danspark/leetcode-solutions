using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace SingleNumber
{
    public class Tests
    {
        private readonly Random _rng = new(Environment.TickCount);

        [Fact]
        public void SingleNumberArrayShouldReturnSameNumber()
        {
            var number = _rng.Next();
            SingleNumber(new[] {number}).Should().Be(number);
        }

        [Fact]
        public void ShouldReturnSingleNumberOfArray()
        {
            var number = _rng.Next(14, 20);

            SingleNumber(Shuffle(new [] { 13, 12, 11, number, 11, 12, 13 })).Should().Be(number);
        }

        [Theory]
        [InlineData(354,
            new[]
            {
                -336, 513, -560, -481, -174, 101, -997, 40, -527, -784, -283, -336, 513, -560, -481, -174, 101, -997,
                40, -527, -784, -283, 354
            })]
        public void ExampleTestCaseShouldReturnExpectedNumber(int expected, int[] nums)
        {
            SingleNumber(nums).Should().Be(expected);
        }

        private int SingleNumber(int[] nums) => new Solution().SingleNumber(nums);

        private int[] Shuffle(int[] nums) => nums.OrderBy(i => _rng.Next()).ToArray();
    }
}
