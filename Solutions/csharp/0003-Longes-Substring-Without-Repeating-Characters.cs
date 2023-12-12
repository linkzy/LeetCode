using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class _0003_Longes_Substring_Without_Repeating_Characters
    {

        [Fact]
        public void Can_Find_The_Length_of_the_Longest_SubString()
        {
            string s = "abcabcbb";
            Object.Equals(LengthOfLongestSubstring(s), 3);
        }


        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int maxLength = 0;
            int start = 0;
            Dictionary<char, int> charIndexMap = new Dictionary<char, int>();

            for (int end = 0; end < n; end++)
            {
                if (charIndexMap.ContainsKey(s[end]) && charIndexMap[s[end]] >= start)
                {
                    // If the character is repeated, update the start pointer to the right
                    start = charIndexMap[s[end]] + 1;
                }

                charIndexMap[s[end]] = end;
                maxLength = Math.Max(maxLength, end - start + 1);
            }

            return maxLength;
        }
    }
}
