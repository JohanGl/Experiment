namespace Game.Characters.States.Physical.Limbs.Facial
{
	public class Eye : LimbBase
	{
		public EyeColor Color { get; set; }
	}

	public enum EyeColor
	{
		Green,
		Blue,
		Gray,
		Brown
	}
}