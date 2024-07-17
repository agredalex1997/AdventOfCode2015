try {
    using StreamReader reader = new("Day1/input.txt");
    string text = reader.ReadToEnd();
    int floor = 0;
    int position = 0;
    foreach(char c in text) {
        position += 1;
        floor += c == '(' ? 1 : -1;

        if (floor == -1) {
            Console.WriteLine($"Position: {position}");
            break;
        }
    }
    // Console.WriteLine($"Floor: {floor}");
} catch (Exception e) {
    Console.WriteLine(e.Message);
}