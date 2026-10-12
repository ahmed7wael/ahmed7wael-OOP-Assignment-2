namespace Solution
{
    public class Solution
    {
        public bool isVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }
        public int MaxVowels(string s, int k)
        {
            int windowVowels = 0;
            for (int i = 0; i < k; i++)
            {
                if (isVowel(s[i]))
                    windowVowels++;
            }
            int maxVowels = windowVowels;
            for (int i = k; i < s.Length; i++)
            {
                if (isVowel(s[i]))
                    windowVowels++;
                if (isVowel(s[i - k]))
                    windowVowels--;
                maxVowels = Math.Max(maxVowels, windowVowels);
            }
            return maxVowels;
        }
    }
}
