using System.Collections.Generic;
using Game.Core.Random;

namespace Game.Narrators
{
	public class NarratorItem
	{
		public string Name { get; set; }
		public Dictionary<string, List<string>> Options { get; set; }

		public NarratorItem()
		{
			Options = new Dictionary<string, List<string>>();
		}

		public string GetRandomLine(string option)
		{
			var index = Randomizer.Random.Next(0, Options[option].Count);
			return Options[option][index];
		}
	}
}