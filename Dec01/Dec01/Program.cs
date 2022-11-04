var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

void Part1(string[] allLines)
{
	long sum = 0L;
	foreach (string thisLine in allLines)
	{
		var thisMass = long.Parse(thisLine);
		var thisFuel = thisMass / 3 - 2;
		sum += thisFuel;
	}
	Console.WriteLine($"Part 1: {sum}");
}