using System.IO;

Console.WriteLine("Hello, World!");
int zeroCount = 0;
int value = 50;
void addValue(string input)
{
    
    string direction = input.Substring(0, 1);
    int newValue = value;
    newValue = int.Parse(input.Substring(1, input.Length - 1));
    Console.WriteLine($"Direction: {direction}, Value: {newValue}");
    
    if (direction == "R")
    {
        newValue = value + newValue;
        while(newValue > 99){
            newValue = newValue - 100;
        }
       
        
    }
    else if (direction == "L")
    {
        newValue = value - newValue;
       while(newValue < 0){
            newValue = (newValue + 100);
        }
    }
    Console.WriteLine("Current Value: " + newValue);
    value = newValue;

}


try
{
    // Read all lines into a string array (one array element per line)
    string[] lines = File.ReadAllLines("input.txt");

    Console.WriteLine($"Read {lines.Length} lines from input.txt:");
    for (int i = 0; i < lines.Length; i++)
    {
        addValue(lines[i]);
        if(value == 0)
        {
            zeroCount++;

        }
    }
}
catch (IOException e)
{
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}

Console.WriteLine("Zero Count: " + zeroCount);
