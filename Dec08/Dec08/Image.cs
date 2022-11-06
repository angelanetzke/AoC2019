using System.Text.RegularExpressions;

namespace Dec08
{
	internal class Image
	{
		private readonly int WIDTH = 25;
		private readonly int HEIGHT = 6;
		private readonly string[] data;

		public Image(string input)
		{
			int layerCount = input.Length / (WIDTH * HEIGHT);
			data = new string[layerCount];
			for (int i = 0; i < layerCount; i++)
			{
				data[i] = input.Substring(i * WIDTH * HEIGHT, WIDTH * HEIGHT);
			}
		}

		public int GetLayerCount()
		{
			return data.Length;
		}

		public int CountDigits(int layer, int digit)
		{
			return Regex.Matches(data[layer], digit.ToString()).Count;
		}

	}
}
