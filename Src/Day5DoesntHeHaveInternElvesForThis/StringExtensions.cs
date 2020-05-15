using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day5DoesntHeHaveInternElvesForThis
{
    internal static class StringExtensions
    {
        internal static bool HasAtleastCountOfVowelsIgnoreCase(this string value, int count)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            int totalVowels = 0;
            foreach (char c in value.ToLower())
            {
                if (vowels.Contains(c))
                    totalVowels += 1;
            }
            return totalVowels >= count;
        }

        internal static bool HasLetterAppearingTwiceInRowIgnoreCase(this string value)
        {
            char previousChar = default;
            foreach (char c in value.ToLower())
            {
                char currentChar = c;
                if (previousChar == currentChar)
                    return true;
                previousChar = currentChar;
            }
            return false;
        }

        internal static bool ContainsAnyIgnoreCase(this string s, string[] values)
        {
            string value = s.ToLower();

            foreach (string x in values)
            {
                if (value.Contains(x.ToLower()))
                    return true;
            }
            return false;
        }

        internal static bool HasLetterComboAppearingTwiceWithNoOverlapping(this string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                string combo = s.Substring(i, 2);
                string leftover = s.Substring(i + 2);
                int matches = new Regex(combo).Matches(leftover).Count;
                if (matches == 1)
                {
                    if (combo[0] == combo[1])
                    {
                        if (combo[0] == leftover[0])
                        {
                            return false;
                        }
                        var secondPairIndex = leftover.IndexOf(combo);
                        if (secondPairIndex < leftover.Length - 2)
                        {
                            if (combo[0] == leftover[secondPairIndex + 2])
                                return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        internal static bool Method1(this string s)
        {
            for (int i = 0; i < s.Length - 2; i++)
            {
                char first = s[i];
                char third = s[i + 2];
                if (first == third)
                    return true;
            }

            return false;
        }
    }
}
