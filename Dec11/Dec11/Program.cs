using Dec11;

var inputLine = File.ReadAllText("input.txt");
Part1(inputLine);

static void Part1(string inputLine)
{
	//(x, y), color (0 = black, 1 = white)
	var theRobot = new Robot();
	var tiles = new Dictionary<(int, int), int>();
	var theComputer = new IntcodeComputer();
	theComputer.SetMemory(inputLine);
	theComputer.AddInput(0L);
	int paintCount = 0;
	IntcodeComputer.EXIT_STATUS currentStatus;
	do
	{
		theComputer.ClearOutput();
		currentStatus = theComputer.Run();
		if (currentStatus == IntcodeComputer.EXIT_STATUS.PAUSE)
		{
			if (!tiles.ContainsKey(theRobot.GetPosition()))
			{
				paintCount++;
			}
			tiles[theRobot.GetPosition()] = (int)theComputer.GetOutput()[0];
			theRobot.Rotate((int)theComputer.GetOutput()[1]);
			theRobot.Move();
			if (tiles.ContainsKey(theRobot.GetPosition()))
			{
				theComputer.AddInput(tiles[theRobot.GetPosition()]);
			}
			else
			{
				theComputer.AddInput(0);
			}			
		}
	} while (currentStatus != IntcodeComputer.EXIT_STATUS.HALT);
	Console.WriteLine($"Part 1: {paintCount}");
}