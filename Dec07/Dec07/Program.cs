using Dec07;

var inputLine = File.ReadAllText("input.txt");
Part1(inputLine);

static void Part1(string inputLine)
{
	var permutations = File.ReadAllLines("permutations.txt");
	long maxOutput = long.MinValue;
	foreach (string thisPermutation in permutations)
	{
		var thisOutput = 0L;
		for (int i = 0; i < 5; i++)
		{
			var thisAmplifier = new IntcodeComputer();
			thisAmplifier.SetMemory(inputLine);
			thisAmplifier.AddInput(long.Parse(thisPermutation[i].ToString()));
			thisAmplifier.AddInput(thisOutput);
			thisAmplifier.Run();
			thisOutput = thisAmplifier.GetOutput()[0];
		}
		maxOutput = Math.Max(maxOutput, thisOutput);
	}
	Console.WriteLine($"Part 1: {maxOutput}");
}