using System.IO;

Console.WriteLine("Hello, World!");
int zeroCount = 0;
int value = 50;
void addValue(string input)
{
    
    string direction = input.Substring(0, 1);
    int distance = int.Parse(input.Substring(1, input.Length - 1));
    Console.WriteLine($"Direction: {direction}, Distance: {distance}, Start: {value}");

    int wraps = 0;
    int newValue;

    if (direction == "R")
    {
        // First time we hit 0 when rotating right is after (100 - value) clicks,
        // except when starting at 0 where that first hit is after 100 clicks.
        int firstHit = (value == 0) ? 100 : (100 - value);
        if (distance >= firstHit)
        {
            wraps = 1 + (distance - firstHit) / 100;
        }

        newValue = (value + distance) % 100;
    }
    else // "L"
    {
        // First time we hit 0 when rotating left is after value clicks,
        // except when starting at 0 where that first hit is after 100 clicks.
        int firstHit = (value == 0) ? 100 : value;
        if (distance >= firstHit)
        {
            wraps = 1 + (distance - firstHit) / 100;
        }

        // C# % of negative can be negative, normalize to 0..99
        newValue = ((value - distance) % 100 + 100) % 100;
    }

    if (wraps > 0)
    {
        Console.WriteLine($"Wrapped around {wraps} time(s)");
        zeroCount += wraps;
    }

    Console.WriteLine("Current Value: " + newValue);
    value = newValue;

}


try
{
    // Read all lines into a string array (one array element per line)
    string[] lines = File.ReadAllLines("Input.txt");

    Console.WriteLine($"Read {lines.Length} lines from Input.txt:");
    for (int i = 0; i < lines.Length; i++)
    {
        addValue(lines[i]);
        Console.WriteLine($"CurrentCount: {zeroCount}");
        
    }
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}

Console.WriteLine("Zero Count: " + zeroCount);
