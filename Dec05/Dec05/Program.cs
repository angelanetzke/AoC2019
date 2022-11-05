using Dec05;

var inputLine = File.ReadAllText("input.txt");
Part1(inputLine);

static void Part1(string inputLine)
{
	var computer = new IntcodeComputer();
	computer.SetMemory(inputLine);
	computer.SetInput(new long[] { 1 });
	computer.Run();
	long diagnosticCode = computer.GetOutput().Last();
	Console.WriteLine($"Part 1: {diagnosticCode}");	
}