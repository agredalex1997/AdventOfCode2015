namespace AdventOfCode
{
    class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        internal int X { get; set; }
        internal int Y { get; set; }

        public (int, int) ToTuple() {
            return (X, Y);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                using (StreamReader reader = new("Inputs/Day3.txt"))
                {
                    string moves = reader.ReadToEnd();

                    var santaPosition = new Position(0, 0);
                    var roboSantaPosition = new Position(0, 0);
                    HashSet<(int, int)> visitedPositions = [(0, 0)];

                    for (int i = 0; i < moves.Length; i++)
                    {
                        char move = moves[i];
                        var positionToUpdate = i % 2 == 0 ? santaPosition : roboSantaPosition;

                        UpdatePosition(positionToUpdate, move);
                        visitedPositions.Add(positionToUpdate.ToTuple());
                    }

                    Console.WriteLine($"Visited houses = {visitedPositions.Count}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdatePosition(Position positionToUpdate, char move)
        {
            switch (move)
            {
                case '^':
                    positionToUpdate.Y += 1;
                    break;
                case 'v':
                    positionToUpdate.Y -= 1;
                    break;
                case '>':
                    positionToUpdate.X += 1;
                    break;
                case '<':
                    positionToUpdate.X -= 1;
                    break;
            }
        }
    }
}