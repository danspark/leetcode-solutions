using System;
using FluentAssertions;
using Xunit;

namespace StringToIntegerAtoi
{
    public class Tests
    {
        private readonly Random _rng = new(Environment.TickCount);

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, int.MaxValue)]
        [InlineData(int.MinValue, 0)]
        public void NumberStringConvertsToNumber(int min, int max)
        {
            var number = _rng.Next(min, max);

            ExecuteAtoi(number.ToString()).Should<int>().Be(number);
        }

        [Fact]
        public void NumberWithLeadingWhitespaceConvertsToNumber()
        {
            var number = _rng.Next();

            ExecuteAtoi($"   {number}").Should<int>().Be(number);
        }

        [Fact]
        public void NumberBiggerThanInt32ConvertsToInt32MaxSize()
        {
            long number = long.MaxValue + _rng.Next(int.MinValue, 0);

            ExecuteAtoi(number.ToString()).Should<int>().Be(int.MaxValue);
        }

        [Fact]
        public void NumberSmallerThanInt32ConvertsToInt32MinSize()
        {
            long number = long.MinValue + _rng.Next(0, int.MaxValue);

            ExecuteAtoi(number.ToString()).Should<int>().Be(int.MinValue);
        }

        [Fact]
        public void NumberWithTrailingLettersConvertsToNumber()
        {
            var number = _rng.Next();

            ExecuteAtoi($"{number} with words").Should<int>().Be(number);
        }

        [Fact]
        public void NumberWithLeadingLettersConvertsToZero()
        {
            var number = _rng.Next();

            ExecuteAtoi($"words and {number}").Should<int>().Be(0);
        }

        [Fact]
        public void NumberWithDotInBetweenShouldConvertToNumberBeforeDot()
        {
            var number = _rng.Next();

            ExecuteAtoi($"{number}.{_rng.Next()}").Should<int>().Be(number);
        }

        [Fact]
        public void NumberWithMultipleLeadingPlusAndMinusShouldConvertToZero()
        {
            ExecuteAtoi($"++-{_rng.Next()}").Should<int>().Be(0);
        }
        private static int ExecuteAtoi(string value) => new Solution().MyAtoi(value);
    }
}