using Game.Characters.States.Mental.Emotions;
using Game.Characters.States.Mental.Personality;

namespace Game.Characters.States.Mental
{
	public class MentalState
	{
		public MentalStatus Status { get; set; }
		public Emotion Emotion { get; set; }
		public EmotionSecondary EmotionSecondary { get; set; }

		public PersonalityState PersonalityState { get; set; }

		public MentalState()
		{
			PersonalityState = new PersonalityState();
		}
	}
}