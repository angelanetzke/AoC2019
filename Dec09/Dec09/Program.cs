using Dec09;

var inputLine = File.ReadAllText("input.txt");
Part1(inputLine);

static void Part1(string inputLine)
{
	var computer = new IntcodeComputer();
	computer.SetMemory(inputLine);
	computer.AddInput(1L);
	computer.Run();
	var keycode = computer.GetOutput()[0];
	Console.WriteLine($"Part 1: {keycode}");
}




