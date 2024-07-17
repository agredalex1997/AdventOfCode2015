try
{
    using (StreamReader reader = new("Inputs/Day2.txt"))
    {
        int TotalArea = 0;

        while (reader.Peek() >= 0) {
            string line = reader.ReadLine();
            int[] dimensions = line.Split("x").Select(x => int.Parse(x)).Order().ToArray();
            
            int x = dimensions[0];
            int y = dimensions[1];
            int z = dimensions[2];

            int boxSurfaceArea = 2*x*y + 2*x*z + 2*y*z;
            // Since the length of the sides is in ascending order, the first 2 positions form the smallest side
            int smallestSideArea = x * y;

            TotalArea += boxSurfaceArea + smallestSideArea;
        }

        Console.WriteLine($"Total area: {TotalArea}");
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}