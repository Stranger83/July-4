using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CharityMarathon
{
	class Program
	{
		static void Main(string[] args)
		{
			int marathonLength = int.Parse(Console.ReadLine()); // integer in the range[0 … 365]
			int runnersCount = int.Parse(Console.ReadLine()); // integer in the range[0 … 2, 147, 483, 647]
			int lapCount = int.Parse(Console.ReadLine()); // integer in the range[0 … 100]
			int trackLength = int.Parse(Console.ReadLine()); // integer in the range[0 … 2, 147, 483, 647]
			int trackCapacity = int.Parse(Console.ReadLine()); // integer in the range[0 … 1000]
			decimal moneyPerKm = decimal.Parse(Console.ReadLine()); // floating point number

			int maxRunners = trackCapacity * marathonLength;
			if (maxRunners < runnersCount)
			{
				runnersCount = maxRunners;
			}
			ulong totalMeters = (ulong)runnersCount * (ulong)lapCount * (ulong)trackLength;
			ulong totalKM = totalMeters / 1000;
			decimal moneyRaised = totalKM * moneyPerKm;
			Console.WriteLine($"Money raised: {moneyRaised:f2}");
		}
	}
}