using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoliTheCoder
{
	class Event
	{
		public string Name { get; set; }
		public List<string> Participants { get; set; }
	}
	class Program
	{
		static void Main(string[] args)
		{
			var eventsRegex = new Regex(@"(?<id>\d+)\s+#(?<eventName>\w+)\s*(?<participants>(?:@[a-zA-Z0-9'-]+\s*)*)");
			var events = new Dictionary<int, Event>();

			while (true)
			{
				var line = Console.ReadLine();
				if(line == "Time for Code")
				{
					break;
				}
				var eventMatch = eventsRegex.Match(line);
				if (!eventMatch.Success)
				{
					continue;
				}
				var id = int.Parse(eventMatch.Groups["id"].Value);
				var eventName = eventMatch.Groups["eventName"].Value;
				var participantsStr = eventMatch.Groups["participants"].Value;

				var participants = new List<string>();
				if (participantsStr.Length > 0)
				{
					participants.AddRange(participantsStr
						.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
				}

				if (!events.ContainsKey(id))
				{
					var @event = new Event
					{
						Name = eventName,
						Participants = participants
					};
					events[id] = @event;
				}
				if(events[id].Name == eventName)
				{
					events[id].Participants.AddRange(participants);
				}
			}
			foreach (var @event in events)
			{
				@event.Value.Participants = @event.Value.Participants
					.Distinct()
					.OrderBy(x => x)
					.ToList();
			}
			var sortedEvents = events.OrderByDescending(x => x.Value.Participants.Count)
				.ThenBy(x => x.Value.Name)
				.ToArray();

			foreach (var sortedevent in sortedEvents)
			{
				Console.WriteLine($"{sortedevent.Value.Name} - {sortedevent.Value.Participants.Count}");
				foreach (var participant in sortedevent.Value.Participants)
				{
					Console.WriteLine($"{participant}");
				}
			}
		}
	}
}
