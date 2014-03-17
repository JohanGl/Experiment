namespace Game.Characters.Common
{
	public class CharacterCommon
	{
		public CharacterType Type { get; set; }
		public Gender Gender { get; set; }
		public float Age { get; set; }
		public float Weight { get; set; }
		public float Height { get; set; }
		public Name Name { get; set; }

		public CharacterCommon()
		{
			Name = new Name();
		}
	}
}