namespace Dec02
{
	internal class IntcodeComputer
	{
		private long[] memory = Array.Empty<long>();
		private int position;

		public void Run()
		{
			position = 0;
			long opcode;
			do
			{
				opcode = memory[position];
				if (opcode == 1)
				{
					long operand1 = memory[memory[position + 1]];
					long operand2 = memory[memory[position + 2]];
					memory[memory[position + 3]] = operand1 + operand2;
					position += 4;
				}
				else if (opcode == 2)
				{
					long operand1 = memory[memory[position + 1]];
					long operand2 = memory[memory[position + 2]];
					memory[memory[position + 3]] = operand1 * operand2;
					position += 4;
				}
			} while (opcode != 99L);
		}

		public void SetMemory(string commands)
		{
			var commandArray = commands.Split(',');
			memory = new long[commandArray.Length];
			for (int i = 0; i < commandArray.Length; i++)
			{
				memory[i] = long.Parse(commandArray[i]);
			}
		}

		public void SetValue(int position, long value)
		{
			memory[position] = value;
		}
		public long GetValue(int position)
		{
			return memory[position];
		}
	}
}
