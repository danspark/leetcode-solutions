using System;

namespace FindTheDifference
{
    public class Solution
    {
        public char FindTheDifference(string s, string t)
        {
            const int charModifier = 97;
            Span<int> letters = stackalloc int[26];

            for (int i = 0; i < s.Length; i++)
            {
                letters[s[i] - charModifier]++;
                letters[t[i] - charModifier] += 10000;
            }

            letters[t[^1] - charModifier] += 10000;

            for (int i = 0; i < 26; i++)
            {
                int count = letters[i];
                if (count / 10000 != count % 1000) return (char)(i + charModifier);
            }

            throw new InvalidOperationException("no new letter was added");
        }
    }
}
