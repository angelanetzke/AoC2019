using Dec06;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var system = new OrbitSystem(allLines);
	int orbitCount = system.CountOrbits();
	Console.WriteLine($"Part 1: {orbitCount}");
}
