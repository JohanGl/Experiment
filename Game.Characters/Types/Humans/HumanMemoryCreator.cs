using Game.Characters.Memories;

namespace Game.Characters.Types.Humans
{
	public class HumanMemoryCreator
	{
		public void CreateMemory(ICharacter self, ICharacter other)
		{
			var memory = new MemoryOfPersonEvent();
			memory.PersonId = other.Id;
			memory.Action = Action.Neutral;
			memory.Strength = 8;

			self.Memory.Memories.Add(memory);
		}
	}
}