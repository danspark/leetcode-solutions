using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace FindTheDifference
{
    public class Tests
    {
        private readonly Random _rng = new Random(Environment.TickCount);

        [Fact]
        public void AddedLetterShouldBeReturned()
        {
            var value = "aofjqiefjoiqejfeq";
            var shuffled = Shuffle(value, 'z');

            FindTheDifference(value, shuffled).Should().Be('z');
        }

        private string Shuffle(string value, char intruder = 'a')
            => new string(value.Append(intruder).OrderBy(v => _rng.Next()).ToArray());

        private char FindTheDifference(string a, string b) => new Solution().FindTheDifference(a, b);
    }
}
