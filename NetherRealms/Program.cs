using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetherRealms
{
	class Demon
	{
		public string Name { get; set; }
		public long Health { get; set; }
		public decimal Damage { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<Demon> allDemons = Console.ReadLine()
				.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => new Demon() { Name = x })
				.ToList();
			foreach (var demon in allDemons)
			{
				demon.Health = CalcHealth(demon);
				demon.Damage = CalcDamage(demon);
			}
			var sortedDemons = allDemons.OrderBy(x => x.Name).ToList();
			foreach (var demon in sortedDemons)
			{
				Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage");
			}
		}

		private static decimal CalcDamage(Demon demon)
		{
			decimal damage = 0.0M;
			var matches = Regex.Matches(demon.Name, @"[\-\+]?\d+(\.\d+)?");
			foreach (Match m in matches)
			{
				damage += decimal.Parse(m.Value);
			}
			foreach (var ch in demon.Name)
			{
				if (ch == '*')
				{
					damage *= 2;
				}
				if (ch == '/')
				{
					damage /= 2;
				}
			}
			return damage;
		}

		private static long CalcHealth(Demon demon)
		{
			string healthString = "";
			var matches = Regex.Matches(demon.Name, @"[^-+\d\.* ,\/]");
			foreach (Match m in matches)
			{
				healthString += m.Value;
			}
			long health = healthString.Select(x => (long)x).Sum();
			return health;
		}
	}
}
