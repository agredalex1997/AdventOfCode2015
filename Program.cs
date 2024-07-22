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

                        if (str != null && IsNice(str))
                        {
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
            if (!DoesContainTwoLettersTwiceWithoutOverlapping(str))
            {
                return false;
            }

            if (!DoesContainLetterThatRepeatsWithOneLetterBetween(str))
            {
                return false;
            }

            return true;
        }

        private static bool DoesContainTwoLettersTwiceWithoutOverlapping(string str)
        {
            for (int i = 0; i <= str.Length - 4; i++)
            {
                string currentPair = str.Substring(i, 2);

                if (str.Substring(i + 2).Contains(currentPair))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool DoesContainLetterThatRepeatsWithOneLetterBetween(string str)
        {
            for (int i = 0; i <= str.Length - 3; i++)
            {
                if (str[i] == str[i + 2])
                {
                    return true;
                }
            }

            return false;
        }
    }
}