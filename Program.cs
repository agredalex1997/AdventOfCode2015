using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                int niceStrings = 0;

                using (StreamReader reader = new("Inputs/Day5.txt"))
                {
                    while (reader.Peek() >= 0)
                    {
                        string? str = reader.ReadLine();

                        if (str != null && IsNice(str)) {
                            niceStrings += 1;
                        }
                    }

                    Console.WriteLine($"Nice strings: {niceStrings}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static bool IsNice(string str)
        {
            if (CountVowels(str) < 3)
            {
                return false;
            }

            if (!DoesHaveLetterTwiceInRow(str))
            {
                return false;
            }

            if (DoesHaveForbiddenString(str, ["ab", "cd", "pq", "xy"]))
            {
                return false;
            }

            return true;
        }

        private static bool DoesHaveForbiddenString(string str, List<string> forbidden)
        {
            foreach (string forbiddenStr in forbidden)
            {
                if (str.Contains(forbiddenStr))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool DoesHaveLetterTwiceInRow(string str)
        {
            char prevChar = ' ';

            foreach (char character in str)
            {
                if (character == prevChar)
                {
                    return true;
                }

                prevChar = character;
            }

            return false;
        }

        private static int CountVowels(string str)
        {
            List<char> vowels = ['a', 'e', 'i', 'o', 'u'];
            int vowelsCount = 0;

            foreach (char character in str)
            {
                if (vowels.Contains(character))
                {
                    vowelsCount += 1;
                }
            }

            return vowelsCount;
        }
    }
}