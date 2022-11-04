using Dec02;

var inputLine = File.ReadAllText("input.txt");
Part1(inputLine);

void Part1(string inputLine)
{
	var computer = new IntcodeComputer();
	computer.SetMemory(inputLine);
	computer.SetValue(1, 12L);
	computer.SetValue(2, 2L);
	computer.Run();
	var position0 = computer.GetValue(0);
	Console.WriteLine($"Part 1: {position0}");
}