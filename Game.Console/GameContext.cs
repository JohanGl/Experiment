using System.Collections.Generic;
using Game.Characters;

namespace Game.Core
{
	public static class GameContext
	{
		public static List<ICharacter> Characters;

		static GameContext()
		{
			Characters = new List<ICharacter>();
		}
	}
}