using Dec13;

var allText = File.ReadAllText("input.txt");
Part1(allText);

static void Part1(string allText)
{
	var theComputer = new IntcodeComputer();
	theComputer.SetMemory(allText);
	theComputer.Run();
	var theOutput = theComputer.GetOutput();
	var blockCount = 0;
	for (int i = 2; i < theOutput.Count; i += 3)
	{
		if (theOutput[i] == 2)
		{
			blockCount++;
		}
	}
	Console.WriteLine($"Part 1: {blockCount}");
}