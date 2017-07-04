using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ladybugs
{
	class Program
	{
		static void Main(string[] args)
		{
			var fieldSize = int.Parse(Console.ReadLine());
			var ladybugIndexes = Console.ReadLine().Split(' ')
				.Select(long.Parse)   // max int
				.ToList();
			var command = Console.ReadLine();

			var fieldWithLadybugs = new int[fieldSize];
			for (int i = 0; i < fieldWithLadybugs.Length; i++)
			{
				if (ladybugIndexes.Contains(i))
				{
					fieldWithLadybugs[i] = 1;
				}
				else
				{
					fieldWithLadybugs[i] = 0;
				}
			}

			while (command != "end")
			{
				var tokens = command.Split(' ');
				var startIndex = int.Parse(tokens[0]);   // max int
				var direction = tokens[1];
				var flyLength = long.Parse(tokens[2]);   // max int

				if (startIndex >= 0 && startIndex < fieldWithLadybugs.Length)
				{
					if (fieldWithLadybugs[startIndex] == 1)
					{
						if (direction == "right")
						{
							FlyRight(startIndex, flyLength, fieldWithLadybugs);
						}
						else
						{
							FlyLeft(startIndex, flyLength, fieldWithLadybugs);
						}
					}
				}
				command = Console.ReadLine();
			}
			Console.WriteLine(string.Join(" ", fieldWithLadybugs));
		}

		private static void FlyLeft(int startIndex, long flyLength, int[] arr)
		{
			if (flyLength == 0)
			{
				return;
			}
			arr[startIndex] = 0;
			for (long i = startIndex; i > 0; i -= flyLength)
			{
				if (i - flyLength < 0)
				{
					return;
				}
				if (arr[i - flyLength] == 0)
				{
					arr[i - flyLength] = 1;
					return;
				}
				else
				{
					continue;
				}
			}
		}

		private static void FlyRight(int startIndex, long flyLength, int[] arr)
		{
			if (flyLength == 0)
			{
				return;
			}
			arr[startIndex] = 0;
			for (long i = startIndex; i < arr.Length; i += flyLength)
			{
				if (i + flyLength >= arr.Length)
				{
					return;
				}
				if (arr[i + flyLength] == 0)
				{
					arr[i + flyLength] = 1;
					return;
				}
				else
				{
					continue;
				}
			}
		}
	}
}
