try
{
    using (StreamReader reader = new("Inputs/Day3.txt"))
    {
        string moves = reader.ReadToEnd();

        (int x, int y) position = (0, 0);
        HashSet<(int, int)> visitedPositions = [(0, 0)];

        foreach (var move in moves)
        {
            if (move == '^')
            {
                position.y += 1;
            }
            else if (move == 'v')
            {
                position.y -= 1;
            }
            else if (move == '>')
            {
                position.x += 1;
            }
            else
            {
                position.x -= 1;
            }

            visitedPositions.Add(position);
        }

        Console.WriteLine($"Visited houses: {visitedPositions.Count}");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}