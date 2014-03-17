namespace Game.Characters.Common
{
	public class Name
	{
		public string First { get; set; }
		public string Last { get; set; }
		public string Alias { get; set; }

		public string Full
		{
			get
			{
				return string.Join(" ", First, Last);
			}
		}

		public string FullWithAlias
		{
			get
			{
				return string.Join(" ", First, Alias, Last);
			}
		}
	}
}