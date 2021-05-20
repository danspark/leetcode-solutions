namespace StringToIntegerAtoi
{
    public class Solution
    {
        public int MyAtoi(string s)
        {
            const char minus = '-';
            const char plus = '+';

            int result = 0;
            bool isNegative = false;
            bool foundNumbers = false;
            for (int i = 0; i < s.Length; i++)
            {
                var chr = s[i];

                if (char.IsWhiteSpace(chr))
                {
                    if (foundNumbers) break;
                    
                    continue;
                }
                if (!char.IsDigit(chr))
                {
                    if (foundNumbers) break;

                    if (chr is minus) isNegative = true;
                    else if (chr is plus) isNegative = false;
                    else break;

                    // '+' or '-' at the end of string OR next character is not a digit
                    if (i == s.Length - 1 || !char.IsDigit(s[i + 1])) break;

                    continue;
                }

                var temp = result * 10;
                if (result != 0 && temp / result != 10)
                {
                    return isNegative ? int.MinValue : int.MaxValue;
                }

                result = temp;

                int sum = (int) char.GetNumericValue(chr);
                temp = result + sum;
                if ((result ^ sum) >= 0 & ((result ^ temp) < 0))
                {
                    return isNegative ? int.MinValue : int.MaxValue;
                }

                result = temp;

                foundNumbers = true;
            }

            return result * (isNegative ? -1 : 1);
        }
    }
}