using System;
using Game.Characters.Common;
using Game.Characters.Memories;
using Game.Characters.States;

namespace Game.Characters.Types.Humans
{
	public class Human : ICharacter
	{
		public Guid Id { get; set; }
		public CharacterCommon Common { get; set; }
		public CharacterStates States { get; set; }
		public CharacterMemory Memory { get; set; }

		public Human()
		{
			Common = new CharacterCommon();
			States = new CharacterStates();
			Memory = new CharacterMemory();

			Id = Guid.NewGuid();
			Common.Type = CharacterType.Human;
		}
	}
}