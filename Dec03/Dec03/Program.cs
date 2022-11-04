var allLines = File.ReadAllLines("input.txt");
var line1 = allLines[0];
var line2 = allLines[1];
Part1(line1, line2);

static void Part1(string line1, string line2)
{
	//(x, y), number of lines that cross that point
	var points = new Dictionary<(int, int), int>();
	var x = 0;
	var y = 0;
	var line1Segments = line1.Split(',');
	foreach (string thisSegment in line1Segments)
	{
		char thisDirection = thisSegment.ToCharArray()[0];
		int thisLength = int.Parse(thisSegment[1..]);
		switch (thisDirection)
		{
			case 'U':
				for (int i = 0; i < thisLength; i++)
				{
					y++;
					points[(x, y)] = 1;
				}
				break;
			case 'D':
				for (int i = 0; i < thisLength; i++)
				{
					y--;
					points[(x, y)] = 1;
				}
				break;
			case 'R':
				for (int i = 0; i < thisLength; i++)
				{
					x++;
					points[(x, y)] = 1;
				}
				break;
			case 'L':
				for (int i = 0; i < thisLength; i++)
				{
					x--;
					points[(x, y)] = 1;
				}
				break;
		}
	}
	x = 0;
	y = 0;
	var line2Segments = line2.Split(',');
	foreach (string thisSegment in line2Segments)
	{
		char thisDirection = thisSegment.ToCharArray()[0];
		int thisLength = int.Parse(thisSegment[1..]);
		switch (thisDirection)
		{
			case 'U':
				for (int i = 0; i < thisLength; i++)
				{
					y++;
					if (points.ContainsKey((x, y)))
					{
						points[(x, y)] = 2;
					}
				}
				break;
			case 'D':
				for (int i = 0; i < thisLength; i++)
				{
					y--;
					if (points.ContainsKey((x, y)))
					{
						points[(x, y)] = 2;
					}
				}
				break;
			case 'R':
				for (int i = 0; i < thisLength; i++)
				{
					x++;
					if (points.ContainsKey((x, y)))
					{
						points[(x, y)] = 2;
					}
				}
				break;
			case 'L':
				for (int i = 0; i < thisLength; i++)
				{
					x--;
					if (points.ContainsKey((x, y)))
					{
						points[(x, y)] = 2;
					}
				}
				break;
		}
	}
	int shortestDistance = int.MaxValue;
	foreach ((int, int) thisPoint in points.Keys)
	{
		if (points[thisPoint] == 2)
		{
			int thisDistance = Math.Abs(thisPoint.Item1) + Math.Abs(thisPoint.Item2);
			shortestDistance = Math.Min(shortestDistance, thisDistance);
		}
	}
	Console.WriteLine($"Part 1: {shortestDistance}");
}
