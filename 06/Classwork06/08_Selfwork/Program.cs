using System;

namespace _08_Selfwork
{
	class Program
	{
		static void Main(string[] args)
		{
			var marks = new[]
			{
				new[] {2, 3, 3, 2, 3},
				new[] {2, 4, 5, 3 },
				null,
				new[] {5, 5, 5, 5},
				new[] {4 }
			};
			float[] averageMark = new float[5];
			for (int i = 0, j = 0; i<averageMark.Length; i++)
			{
				averageMark[i] = 0;
				try
				{
					for (j = 0; j < marks[i].Length; j++)
					{
						averageMark[i] += marks[i][j];
					}
				}
				catch (Exception)
				{
					Console.WriteLine($"The average mark for day #{i+1} is N/A");
					continue;
				}
				
				averageMark[i] /= j;
				Console.WriteLine($"The average mark for day #{i+1} is {MathF.Round(averageMark[i], 1)}");
			}

		}
	}
}
