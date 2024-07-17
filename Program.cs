try
{
    using (StreamReader reader = new("Inputs/Day2.txt"))
    {
        int totalLength = 0;

        while (reader.Peek() >= 0) {
            string line = reader.ReadLine();
            int[] dimensions = line.Split("x").Select(x => int.Parse(x)).Order().ToArray();
            
            int x = dimensions[0];
            int y = dimensions[1];
            int z = dimensions[2];

            int smallestPerimeter = 2*x + 2*y;
            int bowLength = x*y*z;

            totalLength += smallestPerimeter + bowLength;
        }

        Console.WriteLine($"Total length: {totalLength}");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}