using System.Text.RegularExpressions;

namespace AdventOfCode
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new("Inputs/Day8.txt"))
                {
                    int countStringLiterals = 0;
                    int countInMemory = 0;

                    while (reader.Peek() >= 0)
                    {
                        string? line = reader.ReadLine();
                        countStringLiterals += line.Length;
                        string parsedLine = Regex.Replace(line, "\\\\\\\\", ".");
                        parsedLine = Regex.Replace(parsedLine, "\\\\x..", ".");
                        parsedLine = Regex.Replace(parsedLine, "\\\\\"", ".");
                        parsedLine = Regex.Replace(parsedLine, "\"", string.Empty);
                        countInMemory += parsedLine.Length;
                        Console.WriteLine($"{line} {line.Length}, {parsedLine} {parsedLine.Length}");
                    }

                    Console.WriteLine($"{countStringLiterals} - {countInMemory} = {countStringLiterals - countInMemory}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}