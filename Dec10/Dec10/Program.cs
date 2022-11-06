using Dec10;

var allLines = File.ReadAllLines("input.txt");
Part1(allLines);

static void Part1(string[] allLines)
{
	var field = new AsteroidField(allLines);
	int maxAsteroids = field.GetMaxViewableAsteroids();
	Console.WriteLine($"Part 1: {maxAsteroids}");
}
