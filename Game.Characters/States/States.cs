using Game.Characters.States.Mental;
using Game.Characters.States.Physical;

namespace Game.Characters.States
{
	public class CharacterStates
	{
		public PhysicalState Physical { get; set; }
		public MentalState Mental { get; set; }

		public CharacterStates()
		{
			Physical = new PhysicalState();
			Mental = new MentalState();
		}
	}
}