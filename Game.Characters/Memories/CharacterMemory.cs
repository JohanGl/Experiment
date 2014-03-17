using System.Collections.Generic;

namespace Game.Characters.Memories
{
	public class CharacterMemory
	{
		public List<IMemory> Memories { get; set; }

		public CharacterMemory()
		{
			Memories = new List<IMemory>();
		}
	}
}