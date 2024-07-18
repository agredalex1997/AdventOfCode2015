using System.Text;

try
{
    using (StreamReader reader = new("Inputs/Day3.txt"))
    {
        string moves = reader.ReadToEnd();

        (int x, int y) position = (0, 0);
        List<(int x, int y)> visitedPositions = [(0, 0)];
        int minX = 0;
        int maxX = 0;
        int minY = 0;
        int maxY = 0;

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

            if (position.x < minX)
            {
                minX = position.x;
            }
            else if (position.x > maxX)
            {
                maxX = position.x;
            }

            if (position.y < minY)
            {
                minY = position.y;
            }
            else if (position.y > maxY)
            {
                maxY = position.y;
            }
        }

        var distinctVisitedPositions = visitedPositions.ToHashSet();

        Console.WriteLine($"minX: {minX} maxX: {maxX} minY: {minY} maxY: {maxY}");

        List<(int x, int y)> path = new();

        Console.Clear();
        for (int i = minY; i < maxY; i++)
        {
            StringBuilder line = new();

            for (int j = minX; j < maxX; j++)
            {
                line.Append('○');
            }

            line.Append('\n');
            Console.Write(line);
        }

        visitedPositions.ForEach(position =>
        {
            Console.SetCursorPosition(position.x - minX, position.y - minY);
            Console.Write('●');
            Thread.Sleep(25);
        });

        Console.ReadLine();
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}