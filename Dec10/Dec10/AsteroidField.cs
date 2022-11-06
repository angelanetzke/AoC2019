namespace Dec10
{
	internal class AsteroidField
	{
		private readonly string[] field;

		public AsteroidField(string[] field)
		{
			this.field = field;
		}

		public int GetMaxViewableAsteroids()
		{
			int max = 0;
			for (int x = 0; x < field[0].Length; x++)
			{
				for (int y = 0; y < field.Length; y++)
				{
					max = Math.Max(max, GetAsteroidsAtLocation(x, y));
				}
			}
			return max;
		}

		private int GetAsteroidsAtLocation(int x, int y)
		{
			if (field[y][x] != '#')
			{
				return 0;
			}
			else
			{
				var foundAsteroids = new HashSet<(int, int)>();
				var minDeltaX = 0 - x;
				var maxDeltaX = field[0].Length - 1 - x;
				var minDeltaY = 0 - y;
				var maxDeltaY = field.Length - 1 - y;
				for (int deltaX = minDeltaX; deltaX <= maxDeltaX; deltaX++)
				{
					for (int deltaY = minDeltaY; deltaY <= maxDeltaY; deltaY++)
					{
						if (deltaX == 0 && deltaY == 0)
						{
							continue;
						}
						else if (!IsInLowestTerms(deltaX, deltaY))
						{
							continue;
						}
						else
						{
							var incrementX = deltaX;
							var incrementY = deltaY;
							var thisDeltaX = deltaX;
							var thisDeltaY = deltaY;							
							while (0 <= x + thisDeltaX && x + thisDeltaX < field[0].Length
								&& 0 <= y + thisDeltaY && y + thisDeltaY < field.Length)
							{
								if (field[y + thisDeltaY][x + thisDeltaX] == '#')
								{
									foundAsteroids.Add((x + thisDeltaX, y + thisDeltaY));
									break;
								}
								thisDeltaX += incrementX;
								thisDeltaY += incrementY;
							}
						}
					}
				}
				return foundAsteroids.Count;
			}
		}

		private static bool IsInLowestTerms(int x, int y)
		{
			if (x == 0 && Math.Abs(y) == 1)
			{
				return true;
			}
			else if (Math.Abs(x) == 1 && y == 0)
			{
				return true;
			}
			else if (x == 0 || y == 0)
			{
				return false;
			}
			else
			{
				var maxDivisor = Math.Min(Math.Abs(x), Math.Abs(y));
				for (int divisor = 2; divisor <= maxDivisor; divisor++)
				{
					if (Math.Abs(x) % divisor == 0 && Math.Abs(y) % divisor == 0)
					{
						return false;
					}
				}
				return true;
			}
		}


	}
}
