using System;

namespace FindTheDifference
{
    public class Solution
    {
        public char FindTheDifference(string s, string t)
        {
            const int charModifier = 97;
            Span<int> lettersS = stackalloc int[26];
            Span<int> lettersT = stackalloc int[26];

            for (int i = 0; i < s.Length; i++)
            {
                lettersS[s[i] - charModifier]++;
                lettersT[t[i] - charModifier]++;
            }

            lettersT[t[^1] - charModifier]++;

            for (int i = 0; i < 26; i++)
            {
                if (lettersS[i] != lettersT[i]) return (char)(i + charModifier);
            }

            throw new InvalidOperationException("no new letter was added");
        }
    }
}
