namespace Game.Characters.States.Mental.Personality
{
	public class PersonalityState
	{
		public PersonalityType Personality { get; set; }
		public PersonalityType? PersonalitySecondary { get; set; }
		public float Charisma { get; set; }
	}
}