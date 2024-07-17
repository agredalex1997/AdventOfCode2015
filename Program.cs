try {
    using StreamReader reader = new("Day1/input.txt");
    string text = reader.ReadToEnd();
    int floor = 0;
    foreach(char c in text) {
        floor += c == '(' ? 1 : -1;
    }
    Console.WriteLine($"Floor: {floor}");
} catch (Exception e) {
    Console.WriteLine(e.Message);
}