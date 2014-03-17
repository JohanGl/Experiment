using System.Collections.Generic;
using System.IO;
using Game.Characters.Common;
using Game.Core.Random;

namespace Game.Characters.Helpers.Names
{
	public class NameGenerator
	{
		private readonly List<string[]> names;

		public NameGenerator()
		{
			names = new List<string[]>();
			names.Add(File.ReadAllLines("Names/Male.txt"));
			names.Add(File.ReadAllLines("Names/Female.txt"));
			names.Add(File.ReadAllLines("Names/Surnames.txt"));
		}

		public Name Create(Gender gender)
		{
			int index = (gender == Gender.Male) ? 0 : 1;

			var result = new Name
			{
				First = names[index][Randomizer.Random.Next(names[index].Length)],
				Last = names[2][Randomizer.Random.Next(names[2].Length)]
			};

			return result;
		}
	}
}