namespace AdventOfCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                List<List<int>> grid = new();

                for (int i = 0; i < 1000; i++)
                {
                    grid.Add(Enumerable.Repeat(0, 1000).ToList());
                }

                using (StreamReader reader = new("Inputs/Day6.txt"))
                {
                    while (reader.Peek() >= 0)
                    {
                        string? line = reader.ReadLine();
                        string[] words = line.Split(' ');

                        string command = "";

                        if (words.Length == 5)
                        {
                            command = $"{words[0]} {words[1]}"; // "turn on", "turn of"
                        }
                        else if (words.Length == 4)
                        {
                            command = words[0]; // "toggle"
                        }

                        (int ulx, int uly) = ParseCorner(words[^3]);
                        (int lrx, int lry) = ParseCorner(words[^1]);

                        for (int row = uly; row <= lry; row++)
                        {
                            for (int cell = ulx; cell <= lrx; cell++)
                            {
                                switch (command)
                                {
                                    case "turn on":
                                        grid[row][cell] += 1;
                                        break;
                                    case "turn off":
                                        if (grid[row][cell] != 0) {
                                            grid[row][cell] -= 1;
                                        }
                                        break;
                                    case "toggle":
                                        grid[row][cell] += 2;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                    int litLights = grid.Sum(row => row.Sum());

                    Console.WriteLine($"Total brightness = {litLights}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static (int, int) ParseCorner(string corner)
        {
            string[] coords = corner.Split(',');

            return (int.Parse(coords[0]), int.Parse(coords[1]));
        }
    }
}