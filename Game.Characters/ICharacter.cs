using System;
using Game.Characters.Common;
using Game.Characters.Memories;
using Game.Characters.States;

namespace Game.Characters
{
	public interface ICharacter
	{
		Guid Id { get; set; }
		CharacterCommon Common { get; set; }
		CharacterStates States { get; set; }
		CharacterMemory Memory { get; set; }
	}
}